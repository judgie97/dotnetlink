using System.Net;
using System.Runtime.InteropServices;
using libnl;

namespace dotnetlink
{
    public class Route4
    {
        public IPAddress gateway { get; set; }
        public Subnet destination { get; set; }
        public int nic { get; set; }
        public RoutingProtocol protocol { get; set; }
        public RoutingTable routingTable { get; set; }
        public RouteScope scope { get; set; }
        
        public uint priority { get; set; }

        public Route4(Subnet destination, IPAddress gateway, int nic, RoutingProtocol protocol,
            RoutingTable routingTable)
        {
            this.destination = destination;
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
            byte netmask = (byte) LibNL3.nl_addr_get_prefixlen(destinationAddress);
            uint destinationIpAddress = *(uint*) LibNL3.nl_addr_get_binary_addr(destinationAddress);
            IPAddress destinationNetwork = new IPAddress(destinationIpAddress);
            destination = new Subnet(destinationNetwork, netmask);

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

            routingTable = (RoutingTable) LibNLRoute3.rtnl_route_get_table(route);
            scope = (RouteScope) LibNLRoute3.rtnl_route_get_scope(route);
            
            priority = LibNLRoute3.rtnl_route_get_priority(route);
        }
    }
}