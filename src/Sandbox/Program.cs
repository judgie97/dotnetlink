using System;
using System.Linq;
using System.Net;
using dotnetlink;
using libnl;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            NetlinkSocket socket = new NetlinkSocket();
            Route[] routes = socket.GetIpv6RoutingTable();
            foreach (var r in routes)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine("");

            socket.AddRoute(new Route(new Subnet(IPAddress.Parse("fe81::"), 72), IPAddress.Parse("fe80::1248"), 3,
                RoutingProtocol.STATIC, RoutingTable.MAIN));
            Console.WriteLine("");

            routes = socket.GetIpv6RoutingTable();
            foreach (var r in routes)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine("");

            socket.RemoveRoute(new Route(new Subnet(IPAddress.Parse("fe81::"), 72), IPAddress.Parse("fe80::1248"), 3,
                RoutingProtocol.STATIC, RoutingTable.MAIN));
            Console.WriteLine("");

            routes = socket.GetIpv6RoutingTable();
            foreach (var r in routes)
            {
                Console.WriteLine(r);
            }
        }
    }
}