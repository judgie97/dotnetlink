using System.Net;
using libnl;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public class Route4
    {
        public IPAddress Gateway { get; set; }
        public Subnet Destination { get; set; }
        public int Nic { get; set; }
        public RoutingProtocol Protocol { get; set; }
        public RoutingTable RoutingTable { get; set; }
        public RouteScope Scope { get; set; }

        public uint Priority { get; set; }

        public Route4(Subnet destination, IPAddress gateway, int nic, RoutingProtocol protocol,
            RoutingTable routingTable)
        {
            Destination = destination;
            Gateway = gateway;
            Nic = nic;
            Protocol = protocol;
            RoutingTable = routingTable;
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
            Destination = new Subnet(destinationNetwork, netmask);

            rtnl_nexthop* gatewayHop = LibNLRoute3.rtnl_route_nexthop_n(route, 0);
            Nic = LibNLRoute3.rtnl_route_nh_get_ifindex(gatewayHop);
            nl_addr* gatewayAddress = LibNLRoute3.rtnl_route_nh_get_gateway(gatewayHop);
            Gateway = null;
            if (gatewayAddress != null)
            {
                uint gatewayIpAddress = *(uint*) LibNL3.nl_addr_get_binary_addr(gatewayAddress);
                Gateway = new IPAddress(gatewayIpAddress);
            }

            Protocol = (RoutingProtocol) LibNLRoute3.rtnl_route_get_protocol(route);

            RoutingTable = (RoutingTable) LibNLRoute3.rtnl_route_get_table(route);
            Scope = (RouteScope) LibNLRoute3.rtnl_route_get_scope(route);

            Priority = LibNLRoute3.rtnl_route_get_priority(route);
        }
    }
}