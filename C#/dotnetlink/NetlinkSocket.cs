using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace dotnetlink
{
    public class NetlinkSocket
    {
        [DllImport("libdotnetlinkconnector.so")]
        private static extern int openNetlinkSocket(uint portID);

        [DllImport("libdotnetlinkconnector.so")]
        private static extern unsafe int requestAllRoutes(int sock, byte** storage);
        
        [DllImport("libdotnetlinkconnector.so")]
        private static extern int closeNetlinkSocket(int sock);
        
        private int m_sockfd;
        private uint m_pid;
        public NetlinkSocket()
        {
            m_pid = (uint)Process.GetCurrentProcess().Id;
            m_sockfd = openNetlinkSocket(m_pid);
        }

        ~NetlinkSocket()
        {
            closeNetlinkSocket(m_sockfd);
        }
        
        public unsafe Route4[] getRoutingTable()
        {
            byte* netlinkRoutes;
            int count = requestAllRoutes(m_sockfd, &netlinkRoutes);
            byte* currentRoute = netlinkRoutes;
            Route4[] routes = new Route4[count];
            for (int i = 0; i < count; i++)
            {
                NetlinkRoute4 r = (NetlinkRoute4) Marshal.PtrToStructure((IntPtr) currentRoute, typeof(NetlinkRoute4));
                currentRoute += sizeof(NetlinkRoute4);
                routes[i] = r.toRoute4();
            }
            return routes;
        }

    }
}