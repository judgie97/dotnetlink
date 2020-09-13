using System;
using libnl;

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public static unsafe partial class Connector
    {
        public static Route[] RequestAllRoutes(nl_sock* socket, bool ipv6)
        {
            nl_cache* cache;
            LibNLRoute3.rtnl_route_alloc_cache(socket, ipv6 ? AddressFamily.INET6 : AddressFamily.INET, 0, &cache);
            //Check that the number of items is not 0
            int count = LibNL3.nl_cache_nitems(cache);
            if (count == 0)
                return null;

            Route[] routes = new Route[count];

            nl_object* current = LibNL3.nl_cache_get_first(cache);
            for (int i = 0; i < count; i++)
            {
                routes[i] = new Route(current);
                current = LibNL3.nl_cache_get_next(current);
            }

            return routes;
        }

        public static int RemoveRoute(nl_sock* socket, Route route)
        {
            rtnl_route* nlRoute = LibNLRoute3.rtnl_route_alloc();
            LibNLRoute3.rtnl_route_set_table(nlRoute, (uint) RoutingTable.MAIN);
            LibNLRoute3.rtnl_route_set_family(nlRoute,
                (byte) (route.Family == AddressFamily.INET
                    ? System.Net.Sockets.AddressFamily.InterNetwork
                    : System.Net.Sockets.AddressFamily.InterNetworkV6));

            nl_addr* nlDestination;
            byte[] destinationBytes = route.Destination.NetworkAddress.GetAddressBytes();
            fixed (byte* d = destinationBytes)
                nlDestination = LibNL3.nl_addr_build(route.Family, d, (uint) destinationBytes.Length);

            LibNL3.nl_addr_set_prefixlen(nlDestination, (int) route.Destination.NetmaskLength);
            LibNLRoute3.rtnl_route_set_dst(nlRoute, nlDestination);

            nl_addr* nlGateway;
            byte[] gatewayBytes = route.Gateway.GetAddressBytes();
            fixed (byte* g = gatewayBytes)
                nlGateway = LibNL3.nl_addr_build(route.Family, g, (uint) gatewayBytes.Length);

            LibNL3.nl_addr_set_prefixlen(nlGateway, gatewayBytes.Length * 8);

            rtnl_nexthop* rtnlNextHop = LibNLRoute3.rtnl_route_nh_alloc();
            LibNLRoute3.rtnl_route_nh_set_ifindex(rtnlNextHop, route.Nic);
            LibNLRoute3.rtnl_route_nh_set_gateway(rtnlNextHop, nlGateway);
            LibNLRoute3.rtnl_route_add_nexthop(nlRoute, rtnlNextHop);

            LibNLRoute3.rtnl_route_set_protocol(nlRoute, (byte) route.Protocol);

            return LibNLRoute3.rtnl_route_delete(socket, nlRoute, NLMessageFlag.REQUEST);
        }

        public static int AddRoute(nl_sock* socket, Route route)
        {
            rtnl_route* nlRoute = LibNLRoute3.rtnl_route_alloc();
            LibNLRoute3.rtnl_route_set_family(nlRoute,
                (byte) (route.Family == AddressFamily.INET
                    ? System.Net.Sockets.AddressFamily.InterNetwork
                    : System.Net.Sockets.AddressFamily.InterNetworkV6));
            LibNLRoute3.rtnl_route_set_table(nlRoute, (uint) RoutingTable.MAIN);

            nl_addr* nlDestination;
            byte[] destinationBytes = route.Destination.NetworkAddress.GetAddressBytes();
            fixed (byte* d = destinationBytes)
                nlDestination = LibNL3.nl_addr_build(route.Family, d, (uint) destinationBytes.Length);

            LibNL3.nl_addr_set_prefixlen(nlDestination, (int) route.Destination.NetmaskLength);
            LibNLRoute3.rtnl_route_set_dst(nlRoute, nlDestination);

            nl_addr* nlGateway;
            byte[] gatewayBytes = route.Gateway.GetAddressBytes();
            fixed (byte* g = gatewayBytes)
                nlGateway = LibNL3.nl_addr_build(route.Family, g, (uint) gatewayBytes.Length);
            
            LibNL3.nl_addr_set_prefixlen(nlGateway, route.Family == AddressFamily.INET ? 32 : 128);

            rtnl_nexthop* rtnlNextHop = LibNLRoute3.rtnl_route_nh_alloc();
            LibNLRoute3.rtnl_route_nh_set_gateway(rtnlNextHop, nlGateway);
            LibNLRoute3.rtnl_route_nh_set_ifindex(rtnlNextHop, route.Nic);
            LibNLRoute3.rtnl_route_add_nexthop(nlRoute, rtnlNextHop);

            LibNLRoute3.rtnl_route_set_protocol(nlRoute, (byte) route.Protocol);

            return LibNLRoute3.rtnl_route_add(socket, nlRoute, NLMessageFlag.REQUEST | NLMessageFlag.ATOMIC);
        }
    }
}