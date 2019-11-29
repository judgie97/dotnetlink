#include <linux/netlink.h>
#include <sys/socket.h>
#include <cstring>
#include <linux/rtnetlink.h>
#include <ctime>
#include <cerrno>
#include <libnet.h>
#include <vector>
#include "Netlink.hpp"

int openNetlinkSocket(unsigned int portID)
{
  struct sockaddr_nl saddr;

  int sock = socket(AF_NETLINK, SOCK_RAW, NETLINK_ROUTE);
  if(sock < 0)
    return COULD_NOT_OPEN_NETLINK_SOCKET;
  memset(&saddr, 0, sizeof(saddr));
  saddr.nl_family = AF_NETLINK;
  saddr.nl_pid = portID;
  if(bind(sock, (struct sockaddr*)&saddr, sizeof(saddr)) < 0)
    return COULD_NOT_BIND_SOCKET_TO_NETLINK;
  return sock;
}

int receiveMessage(int sock, struct msghdr* header, int flags)
{
  int length;
  do {
    length = recvmsg(sock, header, flags);
  } while(length < 0 && (errno == EINTR || errno == EAGAIN));

  if(length < 0)
    return UNABLE_TO_RECEIVE_FROM_NETLINK;
  if(length == 0)
    return NO_DATA_ON_NETLINK_SOCKET;

  return length;
}


int receiveAllRoutesMessage(int sock, unsigned char** storage)
{
  struct sockaddr_nl nladdr;
  struct iovec iov;
  struct msghdr msg = {
    .msg_name = &nladdr,
    .msg_namelen = sizeof(nladdr),
    .msg_iov = &iov,
    .msg_iovlen = 1
  };

  iov.iov_base = 0;
  iov.iov_len = 0;

  int length = receiveMessage(sock, &msg, MSG_PEEK | MSG_TRUNC);

  if(length <= 0)
    return length;

  char* buffer = new char[length];


  iov.iov_len = length;
  iov.iov_base = buffer;

  length = receiveMessage(sock, &msg, 0);

  if(length < 0)
  {
    delete[] buffer;
    return UNABLE_TO_RECEIVE_FROM_NETLINK;
  }

  struct nlmsghdr* header = (struct nlmsghdr*) buffer;
  int remainingLength = length;

  std::vector<route4> routes;

  while(NLMSG_OK(header, remainingLength))
  {
    if(header->nlmsg_flags & NLM_F_DUMP_INTR)
    {
      delete[] buffer;
      return NETLINK_DUMP_INTERUPTED;
    }
    if(header->nlmsg_type == NLMSG_ERROR)
    {
      delete[] buffer;
      return NETLINK_ERROR;
    }

    if(nladdr.nl_pid != 0)
    {
      header = NLMSG_NEXT(header, remainingLength);
      continue;
    }

    struct rtmsg* routeMessage = (struct rtmsg*)NLMSG_DATA(header);
    struct rtattr* attributes[RTA_MAX + 1];
    memset(attributes, 0, sizeof(attributes));
    struct rtmsg* r = routeMessage;
    int length = header->nlmsg_len - NLMSG_LENGTH(sizeof(*r));
    struct rtattr* rta = RTM_RTA(r);
    while(RTA_OK(rta, length))
    {
      if(rta->rta_type <= RTA_MAX)
      {
        attributes[rta->rta_type] = rta;
      }
      rta = RTA_NEXT(rta, length);
    }
    int routingTable = routeMessage->rtm_table;

    if(r->rtm_family == AF_INET && routingTable == RT_TABLE_MAIN)
    {
      route4 route;
      memset(&route, 0, sizeof(route));
      route.netmask = r->rtm_dst_len;
      if(attributes[RTA_DST])
        route.destination = *(unsigned int *)RTA_DATA(attributes[RTA_DST]);
      if(attributes[RTA_OIF])
        route.interface = *(unsigned int *)RTA_DATA(attributes[RTA_OIF]);
      if(attributes[RTA_GATEWAY])
        route.gateway = *(unsigned int *)RTA_DATA(attributes[RTA_GATEWAY]);

      routes.push_back(route);
    }
    header = NLMSG_NEXT(header, remainingLength);

  }

  unsigned char* answer = new unsigned char[sizeof(route4) * routes.size()];
  memcpy(answer, routes.data(), sizeof(route4) * routes.size());
  *storage = answer;

  receiveMessage(sock, &msg, 0); //flush
  delete[] buffer;
  return routes.size();
}


int requestAllRoutes(int sock, unsigned char** storage)
{
  struct {
    struct nlmsghdr nlh;
    struct rtmsg rtm;
  } nl_request;

  nl_request.nlh.nlmsg_type = RTM_GETROUTE;
  nl_request.nlh.nlmsg_flags = NLM_F_REQUEST | NLM_F_DUMP;
  nl_request.nlh.nlmsg_len = sizeof(nl_request);
  nl_request.nlh.nlmsg_seq = time(NULL);
  nl_request.rtm.rtm_family = AF_INET;
  send(sock, &nl_request, sizeof(nl_request), 0);

  return receiveAllRoutesMessage(sock, storage);
}

int closeNetlinkSocket(int socket)
{
  return close(socket);
}