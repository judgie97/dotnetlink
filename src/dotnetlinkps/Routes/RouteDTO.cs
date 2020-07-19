using System.Net;
using dotnetlink;
using dotnetlinkps.Interfaces;
using libnl;

namespace dotnetlinkps.Routes
{
    public class RouteDto
    {
        public IPAddress Gateway { get; set; }
        public Subnet Destination { get; set; }
        public InterfaceDto Interface { get; set; }
        public RoutingProtocol Protocol { get; set; }
        public RoutingTable RoutingTable { get; set; }
        public RouteScope Scope { get; set; }
        public uint Priority { get; set; }
        
        public override string ToString()
        {
            return Destination + " via " + Gateway;
        }
    }
}