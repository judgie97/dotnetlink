using System;
using dotnetlink;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            NetlinkSocket socket = new NetlinkSocket();
            Route4[] routes = socket.getRoutingTable();
            Console.WriteLine();
        }
    }
}