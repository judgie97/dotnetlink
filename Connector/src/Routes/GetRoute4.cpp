#include <netlink/socket.h>
#include <netlink/netlink.h>
#include <netlink/genl/genl.h>
#include <vector>
#include <net/route.h>
#include <netlink/route/route.h>
#include "../Netlink.hpp"

static int receiveARoute(struct nl_msg* msg, void* arg)
{
  std::vector<Route4>* routes = (std::vector<Route4>*) arg;
  struct nlmsghdr* nlh = nlmsg_hdr(msg);

  struct rtmsg* routeMessage = (struct rtmsg*) NLMSG_DATA(nlh);
  struct rtattr* attributes[RTA_MAX + 1];
  memset(attributes, 0, sizeof(attributes));
  int length = nlh->nlmsg_len - NLMSG_LENGTH(sizeof(*routeMessage));
  struct rtattr* rta = RTM_RTA(routeMessage);
  while(RTA_OK(rta, length))
  {
    if(rta->rta_type <= RTA_MAX)
    {
      attributes[rta->rta_type] = rta;
    }
    rta = RTA_NEXT(rta, length);
  }
  int routingTable = routeMessage->rtm_table;

  if(routeMessage->rtm_family == AF_INET && routingTable == RT_TABLE_MAIN)
  {
    Route4 route;
    memset(&route, 0, sizeof(route));
    route.netmask = routeMessage->rtm_dst_len;
    route.protocol = routeMessage->rtm_protocol;
    if(attributes[RTA_DST])
      route.destination = *(unsigned int*) RTA_DATA(attributes[RTA_DST]);
    if(attributes[RTA_OIF])
      route.interface = *(unsigned int*) RTA_DATA(attributes[RTA_OIF]);
    if(attributes[RTA_GATEWAY])
      route.gateway = *(unsigned int*) RTA_DATA(attributes[RTA_GATEWAY]);

    routes->push_back(route);
  }
  return NL_OK;
}


int requestAllRoutes(struct nl_sock* socket, unsigned char** storage)
{
  struct rtgenmsg rt_hdr = {.rtgen_family = AF_PACKET};

  int ret = nl_send_simple(socket, RTM_GETROUTE, NLM_F_REQUEST | NLM_F_DUMP, &rt_hdr, sizeof(rt_hdr));
  //TODO test this return value. Should be 20

  std::vector<Route4> routes;

  nl_socket_modify_cb(socket, NL_CB_VALID, NL_CB_CUSTOM, receiveARoute, (void*) &routes);
  nl_recvmsgs_default(socket);

  *storage = (unsigned char*) malloc(routes.size() * sizeof(Route4));
  memcpy(*storage, routes.data(), routes.size() * sizeof(Route4));

  return routes.size();
}