using libnl;

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public static unsafe partial class Connector
    {
        public static Route4[] RequestAllRoutes(nl_sock* socket)
        {
            nl_cache* cache;
            LibNLRoute3.rtnl_route_alloc_cache(socket, AddressFamily.INET, 0, &cache);
            //Check that the number of items is not 0
            int count = LibNL3.nl_cache_nitems(cache);
            if (count == 0)
                return null;

            Route4[] routes = new Route4[count];

            nl_object* current = LibNL3.nl_cache_get_first(cache);
            for (int i = 0; i < count; i++)
            {
                routes[i] = new Route4(current);
                current = LibNL3.nl_cache_get_next(current);
            }

            return routes;
        }

        public static int RemoveRoute(nl_sock* socket, Route4 route4)
        {
            rtnl_route* nlRoute = LibNLRoute3.rtnl_route_alloc();
            LibNLRoute3.rtnl_route_set_table(nlRoute, (uint) RoutingTable.MAIN);

            uint dest = Util.ip4touint(route4.destination.NetworkAddress);
            nl_addr* nlDestination = LibNL3.nl_addr_build(AddressFamily.INET, &dest, 4);
            LibNL3.nl_addr_set_prefixlen(nlDestination, route4.destination.NetmaskCIDR());
            LibNLRoute3.rtnl_route_set_dst(nlRoute, nlDestination);

            uint gateway = Util.ip4touint(route4.gateway);
            nl_addr* nlGateway = LibNL3.nl_addr_build(AddressFamily.INET, &gateway, 4);
            LibNL3.nl_addr_set_prefixlen(nlGateway, 32);

            rtnl_nexthop* rtnlNexthop = LibNLRoute3.rtnl_route_nh_alloc();
            LibNLRoute3.rtnl_route_nh_set_gateway(rtnlNexthop, nlGateway);
            LibNLRoute3.rtnl_route_add_nexthop(nlRoute, rtnlNexthop);

            LibNLRoute3.rtnl_route_set_protocol(nlRoute, (byte) route4.protocol);
            LibNLRoute3.rtnl_route_set_iif(nlRoute, route4.nic);

            return LibNLRoute3.rtnl_route_delete(socket, nlRoute, NLMessageFlag.REQUEST);
        }
        
        public static int AddRoute(nl_sock* socket, Route4 route4)
        {
            rtnl_route* route = LibNLRoute3.rtnl_route_alloc();
            LibNLRoute3.rtnl_route_set_table(route, (uint) RoutingTable.MAIN);

            uint dest = Util.ip4touint(route4.destination.NetworkAddress);
            nl_addr* nlDestination = LibNL3.nl_addr_build(AddressFamily.INET, &dest, 4);
            LibNL3.nl_addr_set_prefixlen(nlDestination, route4.destination.NetmaskCIDR());
            LibNLRoute3.rtnl_route_set_dst(route, nlDestination);

            uint gateway = Util.ip4touint(route4.gateway);
            nl_addr* nlGateway = LibNL3.nl_addr_build(AddressFamily.INET, &gateway, 4);
            LibNL3.nl_addr_set_prefixlen(nlGateway, 32);

            rtnl_nexthop* rtnlNexthop = LibNLRoute3.rtnl_route_nh_alloc();
            LibNLRoute3.rtnl_route_nh_set_gateway(rtnlNexthop, nlGateway);
            LibNLRoute3.rtnl_route_add_nexthop(route, rtnlNexthop);

            LibNLRoute3.rtnl_route_set_protocol(route, (byte) route4.protocol);
            LibNLRoute3.rtnl_route_set_iif(route, route4.nic);

            return LibNLRoute3.rtnl_route_add(socket, route, NLMessageFlag.REQUEST | NLMessageFlag.ATOMIC);
        }
    }
}