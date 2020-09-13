using System.Net;
using libnl;
using AddressFamily = System.Net.Sockets.AddressFamily;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public class Route
    {
        public IPAddress Gateway { get; set; }
        public Subnet Destination { get; set; }
        public int Nic { get; set; }
        public RoutingProtocol Protocol { get; set; }
        public RoutingTable RoutingTable { get; set; }
        public RouteScope Scope { get; set; }

        public uint Priority { get; set; }

        public int Family { get; set; }

        public Route(Subnet destination, IPAddress gateway, int nic, RoutingProtocol protocol,
            RoutingTable routingTable)
        {
            Destination = destination;
            Gateway = gateway;
            Nic = nic;
            Protocol = protocol;
            RoutingTable = routingTable;
            Family = gateway.AddressFamily == AddressFamily.InterNetwork
                ? libnl.AddressFamily.INET
                : libnl.AddressFamily.INET6;
        }

        public unsafe Route(nl_object* route) : this((rtnl_route*) route)
        {
        }

        public unsafe Route(rtnl_route* route)
        {
            Destination = null;

            nl_addr* destinationAddress = LibNLRoute3.rtnl_route_get_dst(route);
            byte netmask = (byte) LibNL3.nl_addr_get_prefixlen(destinationAddress);
            uint daddrLen = LibNL3.nl_addr_get_len(destinationAddress);
            if (daddrLen == 4 || daddrLen == 16)
            {
                byte* bytes = (byte*) LibNL3.nl_addr_get_binary_addr(destinationAddress);
                byte[] managedBytes = new byte[daddrLen];
                for (int i = 0; i < daddrLen; i++)
                    managedBytes[i] = bytes[i];
                IPAddress destinationNetwork = new IPAddress(managedBytes);
                Destination = new Subnet(destinationNetwork, netmask);
            }

            if (daddrLen == 0)
                Destination = new Subnet(new IPAddress(0), netmask);

            rtnl_nexthop* gatewayHop = LibNLRoute3.rtnl_route_nexthop_n(route, 0);
            Nic = LibNLRoute3.rtnl_route_nh_get_ifindex(gatewayHop);
            nl_addr* gatewayAddress = LibNLRoute3.rtnl_route_nh_get_gateway(gatewayHop);
            LibNLRoute3.rtnl_route_nh_get_flags(gatewayHop);
            Gateway = null;
            if (gatewayAddress != null)
            {
                uint gaddrLen = LibNL3.nl_addr_get_len(gatewayAddress);
                if (gaddrLen == 4 || gaddrLen == 16)
                {
                    byte* bytes = (byte*) LibNL3.nl_addr_get_binary_addr(gatewayAddress);
                    byte[] managedBytes = new byte[gaddrLen];
                    for (int i = 0; i < gaddrLen; i++)
                        managedBytes[i] = bytes[i];
                    Gateway = new IPAddress(managedBytes);
                }

                if (gaddrLen == 0)
                {
                    Gateway = new IPAddress(0);
                }
            }

            Protocol = (RoutingProtocol) LibNLRoute3.rtnl_route_get_protocol(route);

            RoutingTable = (RoutingTable) LibNLRoute3.rtnl_route_get_table(route);
            Scope = (RouteScope) LibNLRoute3.rtnl_route_get_scope(route);

            Priority = LibNLRoute3.rtnl_route_get_priority(route);
        }

        public override string ToString()
        {
            switch (Scope)
            {
                case RouteScope.UNIVERSE:
                    return Destination + " via " + Gateway;
                case RouteScope.HOST:
                    return Destination + " is local";
                case RouteScope.LINK:
                    return Destination + " is directly attached";
                default:
                    return "Unknown";
            }
        }
    }
}