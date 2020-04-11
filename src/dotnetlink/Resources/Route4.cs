using System.Net;
using System.Runtime.InteropServices;
using libnl;

namespace dotnetlink
{
    public class Route4
    {
        public IPAddress destination;
        public IPAddress gateway;
        public byte netmask;
        public int nic;
        public RoutingProtocol protocol;
        public RoutingTable routingTable;
        public RouteScope scope;
        
        public Route4(IPAddress destination, byte netmask, IPAddress gateway, int nic, RoutingProtocol protocol, RoutingTable routingTable)
        {
            this.destination = destination;
            this.netmask = netmask;
            this.gateway = gateway;
            this.nic = nic;
            this.protocol = protocol;
            this.routingTable = routingTable;
        }

        public unsafe Route4(nl_object* route) : this((rtnl_route*) route)
        {
        }
        
        public unsafe Route4(rtnl_route* route)
        {
            nl_addr* destinationAddress = LibNLRoute3.rtnl_route_get_dst(route);
            netmask = (byte)LibNL3.nl_addr_get_prefixlen(destinationAddress);
            uint destinationIPAddress = *(uint*)LibNL3.nl_addr_get_binary_addr(destinationAddress);
            destination = new IPAddress(destinationIPAddress);
            
            
            rtnl_nexthop* gatewayHop = LibNLRoute3.rtnl_route_nexthop_n(route, 0);
            nic = LibNLRoute3.rtnl_route_nh_get_ifindex(gatewayHop);
            nl_addr* gatewayAddress = LibNLRoute3.rtnl_route_nh_get_gateway(gatewayHop);
            gateway = null;
            if (gatewayAddress != null)
            {
                uint gatewayIPAddress = *(uint*) LibNL3.nl_addr_get_binary_addr(gatewayAddress);
                gateway = new IPAddress(gatewayIPAddress);
            }
            protocol = (RoutingProtocol) LibNLRoute3.rtnl_route_get_protocol(route);

            routingTable = (RoutingTable)LibNLRoute3.rtnl_route_get_table(route);
            scope = (RouteScope)LibNLRoute3.rtnl_route_get_scope(route);
        }
    }
}