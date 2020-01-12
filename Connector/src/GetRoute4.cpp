#include <linux/netlink.h>
#include <sys/socket.h>
#include <vector>
#include <linux/rtnetlink.h>
#include <cstring>
#include <ctime>

#include "SocketOperations.hpp"
#include "Netlink.hpp"

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

  std::vector<Route4> routes;

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

    struct rtmsg* routeMessage = (struct rtmsg*) NLMSG_DATA(header);
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
      Route4 route;
      memset(&route, 0, sizeof(route));
      route.netmask = r->rtm_dst_len;
      route.protocol = r->rtm_protocol;
      if(attributes[RTA_DST])
        route.destination = *(unsigned int*) RTA_DATA(attributes[RTA_DST]);
      if(attributes[RTA_OIF])
        route.interface = *(unsigned int*) RTA_DATA(attributes[RTA_OIF]);
      if(attributes[RTA_GATEWAY])
        route.gateway = *(unsigned int*) RTA_DATA(attributes[RTA_GATEWAY]);

      routes.push_back(route);
    }
    header = NLMSG_NEXT(header, remainingLength);

  }

  unsigned char* answer = new unsigned char[sizeof(Route4) * routes.size()];
  memcpy(answer, routes.data(), sizeof(Route4) * routes.size());
  *storage = answer;

  flushSocket(sock);

  delete[] buffer;
  return routes.size();
}

int requestAllRoutes(int sock, unsigned char** storage)
{
  struct
  {
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