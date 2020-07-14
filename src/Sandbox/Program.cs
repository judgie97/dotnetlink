using System;
using dotnetlink;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            NetlinkSocket socket = new NetlinkSocket();
            socket.setInterfaceState(2, InterfaceState.UP);
        }
    }
}