using System;
using dotnetlink;

namespace Sandbox
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            NetlinkSocket socket = new NetlinkSocket();
            var addr = socket.GetAddresses();
            foreach (var x in addr)
            {
                Console.WriteLine(x.Address);
            }
        }
    }
}