#include <netlink/socket.h>
#include <netlink/netlink.h>
#include <netlink/route/route.h>
#include "../Netlink.hpp"

int addRoute(struct nl_sock* socket, Route4* route)
{
  struct rtnl_route* nlRoute = rtnl_route_alloc();
  rtnl_route_set_table(nlRoute, RT_TABLE_MAIN);

  struct nl_addr* nlDestination = nl_addr_build(AF_INET, &(route->destination), 4);
  nl_addr_set_prefixlen(nlDestination, route->netmask);
  rtnl_route_set_dst(nlRoute, nlDestination);

  struct nl_addr* nlGateway = nl_addr_build(AF_INET, &(route->gateway), 4);
  nl_addr_set_prefixlen(nlGateway, 32);

  struct rtnl_nexthop* rtnlNexthop = rtnl_route_nh_alloc();
  rtnl_route_nh_set_gateway(rtnlNexthop, nlGateway);
  rtnl_route_add_nexthop(nlRoute, rtnlNexthop);

  rtnl_route_set_protocol(nlRoute, route->protocol);
  rtnl_route_set_iif(nlRoute, route->interface);

  return rtnl_route_add(socket, nlRoute, NLM_F_REQUEST | NLM_F_CREATE);
}