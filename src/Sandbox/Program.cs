using System;
using System.Threading;
using dotnetlink;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            NetlinkSocket socket = new NetlinkSocket();
            NetworkInterface wlp3s0 = socket.GetNetworkInterface("wlp3s0");
            for (int i = 0; i < 100; i++)
            {
                InterfaceStatistics stats = socket.GetInterfaceStatistics(wlp3s0);
                Thread.Sleep(1000);
            }
        }
    }
}