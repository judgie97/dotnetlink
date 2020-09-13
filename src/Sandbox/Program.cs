using System.Net;
using dotnetlink;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            NetlinkSocket socket = new NetlinkSocket();
            socket.AddIpAddress(new IpAddress(IPAddress.Parse("fe80::1000"), 64, 3));
        }
    }
}