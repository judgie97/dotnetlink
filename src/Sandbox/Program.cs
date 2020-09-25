using System;
using System.Net;
using dotnetlink;

namespace Sandbox
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            NetlinkSocket socket = new NetlinkSocket();
            Route r = socket.GetRoute(new Subnet(IPAddress.Parse("192.168.2.200"), 25));
            Console.WriteLine("Test");
        }
    }
}