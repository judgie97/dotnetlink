#include <linux/rtnetlink.h>
#include <cstdio>
#include <cstring>
#include <ctime>
#include <sys/socket.h>
#include "Netlink.hpp"
#include "SocketOperations.hpp"
#include "TLVOperations.hpp"

int addRoute(int sock, unsigned int portID, Route4* route)
{
  struct
  {
    struct nlmsghdr nlh;
    struct rtmsg rtm;
    unsigned char buffer[4096];
  } nl_request;

  memset(&nl_request, 0, sizeof(nl_request));

  nl_request.nlh.nlmsg_type = RTM_NEWROUTE;
  nl_request.nlh.nlmsg_flags = NLM_F_REQUEST | NLM_F_CREATE;
  nl_request.nlh.nlmsg_len = sizeof(nl_request) - 4096;
  nl_request.nlh.nlmsg_seq = time(NULL);
  nl_request.nlh.nlmsg_pid = portID;

  nl_request.rtm.rtm_family = AF_INET;
  nl_request.rtm.rtm_src_len = 0;
  nl_request.rtm.rtm_dst_len = route->netmask;
  nl_request.rtm.rtm_tos = 0;
  nl_request.rtm.rtm_table = RT_TABLE_MAIN;
  nl_request.rtm.rtm_protocol = route->protocol;
  nl_request.rtm.rtm_scope = RT_SCOPE_UNIVERSE;
  nl_request.rtm.rtm_type = RTN_UNICAST;

  unsigned int dst = route->destination;
  unsigned int gw = route->gateway;

  int result = addTLVToMessage(&nl_request.nlh, sizeof(nl_request), RTA_DST, &dst, 4);
  if(result < 0)
    return result;

  result = addTLVToMessage(&nl_request.nlh, sizeof(nl_request), RTA_GATEWAY, &gw, 4);
  if(result < 0)
    return result;

  send(sock, &nl_request, nl_request.nlh.nlmsg_len, 0);

  flushSocket(sock);

  return 1;
}