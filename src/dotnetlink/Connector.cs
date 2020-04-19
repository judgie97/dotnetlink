using System.Linq;
using libnl;

namespace dotnetlink
{
    public unsafe class Connector
    {
        public static int addRoute(nl_sock* socket, Route4 route4)
        {
            rtnl_route* route = LibNLRoute3.rtnl_route_alloc();
            LibNLRoute3.rtnl_route_set_table(route, (uint)RoutingTable.MAIN);

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

        public static int removeRoute(nl_sock* socket, Route4 route4)
        {
            rtnl_route* nlRoute = LibNLRoute3.rtnl_route_alloc();
            LibNLRoute3.rtnl_route_set_table(nlRoute, (uint)RoutingTable.MAIN);

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

        public static int addIPAddress(nl_sock* socket, IPAddress4 ipAddress4)
        {
            rtnl_addr* addr = LibNLRoute3.rtnl_addr_alloc();
            LibNLRoute3.rtnl_addr_set_ifindex(addr, ipAddress4.nic);
            LibNLRoute3.rtnl_addr_set_scope(addr, 0);

            uint address = Util.ip4touint(ipAddress4.address);
            nl_addr* nlAddr = LibNL3.nl_addr_build(AddressFamily.INET, &address, 4);
            LibNL3.nl_addr_set_prefixlen(nlAddr, ipAddress4.nic);
            LibNLRoute3.rtnl_addr_set_local(addr, nlAddr);

            return LibNLRoute3.rtnl_addr_add(socket, addr, NLMessageFlag.REQUEST | NLMessageFlag.ATOMIC);
        }

        public static int removeIPAddress(nl_sock* socket, IPAddress4 ipAddress4)
        {
            rtnl_addr* addr = LibNLRoute3.rtnl_addr_alloc();
            LibNLRoute3.rtnl_addr_set_ifindex(addr, ipAddress4.nic);
            LibNLRoute3.rtnl_addr_set_scope(addr, 0);

            uint address = Util.ip4touint(ipAddress4.address);
            nl_addr* nlAddr = LibNL3.nl_addr_build(AddressFamily.INET, &address, 4);
            LibNL3.nl_addr_set_prefixlen(nlAddr, ipAddress4.netmask);
            LibNLRoute3.rtnl_addr_set_local(addr, nlAddr);

            return LibNLRoute3.rtnl_addr_delete(socket, addr, NLMessageFlag.REQUEST | NLMessageFlag.ATOMIC);
        }

        public static int addInterface(nl_sock* socket, NetworkInterface networkInterface)
        {
            rtnl_link* nlLink = LibNLRoute3.rtnl_link_vlan_alloc();
            LibNLRoute3.rtnl_link_set_link(nlLink,  networkInterface.parentInterfaceIndex);
            fixed (char* name = networkInterface.interfaceName)
            {
                LibNLRoute3.rtnl_link_set_name(nlLink, name);
            }

            if (networkInterface.interfaceType == InterfaceType.DOT1Q)
            {
                string type = "vlan";
                fixed (char* vlan = type)
                {
                    LibNLRoute3.rtnl_link_set_type(nlLink, vlan);
                    LibNLRoute3.rtnl_link_vlan_set_id(nlLink, ((VLAN)(networkInterface.interfaceInformation)).vlanID);
                }
            }

            return LibNLRoute3.rtnl_link_add(socket, nlLink, NLMessageFlag.REQUEST | NLMessageFlag.ATOMIC);
        }
        
        public static int removeInterface(nl_sock* socket, NetworkInterface networkInterface)
        {
            rtnl_link* nlLink = LibNLRoute3.rtnl_link_vlan_alloc();
            LibNLRoute3.rtnl_link_set_ifindex(nlLink, networkInterface.index);
            LibNLRoute3.rtnl_link_set_link(nlLink, networkInterface.parentInterfaceIndex);
            fixed (char* name = networkInterface.interfaceName)
            {
                LibNLRoute3.rtnl_link_set_name(nlLink, name);
            }
            
            if(networkInterface.interfaceType == InterfaceType.DOT1Q)
            {
                string type = "vlan";
                fixed (char* vlan = type)
                {
                    LibNLRoute3.rtnl_link_set_type(nlLink, vlan);
                    LibNLRoute3.rtnl_link_vlan_set_id(nlLink, ((VLAN)(networkInterface.interfaceInformation)).vlanID);
                }
            }

            return LibNLRoute3.rtnl_link_delete(socket, nlLink);
        }

        public static int setNetworkInterface(nl_sock* socket, int networkInterfaceIndex, bool up)
        {
            nl_cache* cache;
            LibNLRoute3.rtnl_link_alloc_cache(socket, AddressFamily.INET, &cache);
            rtnl_link* original = LibNLRoute3.rtnl_link_get(cache, networkInterfaceIndex);

            rtnl_link* changed = (rtnl_link*) LibNL3.nl_object_clone((nl_object*) original);
            if (up)
            {
                LibNLRoute3.rtnl_link_set_flags(changed, NLMessageFlag.REQUEST);
            }
            else
            {
                LibNLRoute3.rtnl_link_unset_flags(changed, NLMessageFlag.REQUEST);
            }

            return LibNLRoute3.rtnl_link_change(socket, original, changed, NLMessageFlag.REQUEST);
        }

        public static Route4[] requestAllRoutes(nl_sock* socket)
        {
            nl_cache* cache;
            LibNLRoute3.rtnl_route_alloc_cache(socket, AddressFamily.INET, 0, &cache);
            //Check that the number of items is not 0
            int count = LibNL3.nl_cache_nitems(cache);
            if (count == 0)
                return null;

            Route4[] routes = new Route4[count];

            nl_object* current = LibNL3.nl_cache_get_first(cache);
            for(int i = 0; i < count; i++)
            {
                routes[i] = new Route4(current);
                current = LibNL3.nl_cache_get_next(current);
            }

            return routes;
        }
        
        public static IPAddress4[] requestAllAddresses(nl_sock* socket)
        {
            nl_cache* cache;
            LibNLRoute3.rtnl_addr_alloc_cache(socket, &cache);
            //Check that the number of items is not 0
            int count = LibNL3.nl_cache_nitems(cache);
            if (count == 0)
                return null;

            IPAddress4[] addresses = new IPAddress4[count];

            nl_object* current = LibNL3.nl_cache_get_first(cache);
            for(int i = 0; i < count; i++)
            {
                addresses[i] = new IPAddress4(current);
                current = LibNL3.nl_cache_get_next(current);
            }

            return addresses.Where(a => a.address.GetAddressBytes().Length == 4).ToArray();
        }
        
        public static NetworkInterface[] requestAllNetworkInterfaces(nl_sock* socket)
        {
            nl_cache* cache;
            LibNLRoute3.rtnl_link_alloc_cache(socket, AddressFamily.INET, &cache);
            //Check that the number of items is not 0
            int count = LibNL3.nl_cache_nitems(cache);
            if (count == 0)
                return null;

            NetworkInterface[] interfaces = new NetworkInterface[count];

            nl_object* current = LibNL3.nl_cache_get_first(cache);
            for(int i = 0; i < count; i++)
            {
                interfaces[i] = new NetworkInterface(current);
                current = LibNL3.nl_cache_get_next(current);
            }

            return interfaces;
        }
    }
}