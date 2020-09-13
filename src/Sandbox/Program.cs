using System;
using dotnetlink;

namespace Sandbox
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            NetlinkSocket socket = new NetlinkSocket();
            socket.SetNetworkInterfaceMaximumTransmissionUnit(3, 1400);
            Console.WriteLine("MTU CHANGED");
        }
    }
}