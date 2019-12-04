#include <linux/rtnetlink.h>
#include <cstdio>
#include <cstring>
#include <ctime>
#include <sys/socket.h>
#include "Netlink.hpp"
#include "SocketOperations.hpp"

int addAttributeToMessage(struct nlmsghdr *n, int maxLength, int type, const void* data, int attributeLength)
{
  int len = RTA_LENGTH(attributeLength);
  struct rtattr *rta;

  int messageLength = NLMSG_ALIGN(n->nlmsg_len) + RTA_ALIGN(len);
  if (messageLength > maxLength) {
    return ROUTE_MESSAGE_TOO_LONG;
  }

  rta = ((struct rtattr *) (((unsigned char *) (n)) + NLMSG_ALIGN((n)->nlmsg_len)));
  rta->rta_type = type;
  rta->rta_len = len;

  if (attributeLength) {
    memcpy(RTA_DATA(rta), data, attributeLength);
  }

  n->nlmsg_len = NLMSG_ALIGN(n->nlmsg_len) + RTA_ALIGN(len);

  return 0;
}

int addRoute(int sock, unsigned int portID, route4* route)
{
  struct
  {
    struct nlmsghdr nlh;
    struct rtmsg rtm;
    unsigned char buffer[4096];
  } nl_request;

  memset(&nl_request, 0, sizeof(nl_request));

  nl_request.nlh.nlmsg_type = RTM_NEWROUTE;
  nl_request.nlh.nlmsg_flags = NLM_F_REQUEST|NLM_F_CREATE;
  nl_request.nlh.nlmsg_len = sizeof(nl_request) - 4096;
  nl_request.nlh.nlmsg_seq = time(NULL);
  nl_request.nlh.nlmsg_pid = portID;
  nl_request.rtm.rtm_family = AF_INET;

  nl_request.rtm.rtm_family = AF_INET;
  nl_request.rtm.rtm_src_len = 0;
  nl_request.rtm.rtm_dst_len = route->netmask;
  nl_request.rtm.rtm_tos = 0;
  nl_request.rtm.rtm_table = RT_TABLE_MAIN;
  nl_request.rtm.rtm_protocol = RTPROT_STATIC;
  nl_request.rtm.rtm_scope = RT_SCOPE_UNIVERSE;
  nl_request.rtm.rtm_type = RTN_UNICAST;

  unsigned int dst = route->destination;
  unsigned int gw = route->gateway;

  int result = addAttributeToMessage(&nl_request.nlh, sizeof(nl_request), RTA_DST, &dst, 4);
  if(result < 0)
    return result;

  result = addAttributeToMessage(&nl_request.nlh, sizeof(nl_request), RTA_GATEWAY, &gw, 4);
  if(result < 0)
    return result;

  send(sock, &nl_request, nl_request.nlh.nlmsg_len, 0);

  flushSocket(sock);

  return 1;
}