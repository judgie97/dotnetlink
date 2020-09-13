using System;
using System.Linq;
using System.Net;
using dotnetlink;
using dotnetlink.Extension;

namespace Sandbox
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            NetlinkSocket socket = new NetlinkSocket();
            Neighbour[] arpCache = socket.GetArpCache().Where(n =>
                    (n.Layer3Address.IsIpv6Address() && !n.Layer3Address.IsIPv6Multicast) ||
                    (n.Layer3Address.IsIpv4Address() && !n.Layer3Address.IsIpv4ClassD()))
                .ToArray();
            foreach (var a in arpCache)
            {
                Console.WriteLine(a);
                IPAddress address = a.Layer3Address;
                Console.WriteLine();
            }
        }
    }
}