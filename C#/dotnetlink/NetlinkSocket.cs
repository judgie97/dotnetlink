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
        
        [DllImport("libdotnetlinkconnector.so")]
        private static extern unsafe int addRoute(int sock, uint portID, NetlinkRoute4* route);
        
        [DllImport("libdotnetlinkconnector.so")]
        private static extern unsafe int removeRoute(int sock, uint portID, NetlinkRoute4* route);
        
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
        
        public unsafe void addRoute(Route4 route)
        {
            NetlinkRoute4 nlr = new NetlinkRoute4();
            nlr.destination = Util.ip4touint(route.destination);
            nlr.gateway = Util.ip4touint(route.gateway);
            nlr.netmask = route.netmask;
            nlr.nic = 0;
            nlr.protocol = (byte)route.protocol;

            addRoute(m_sockfd, m_pid, &nlr);
        }
        
        public unsafe void removeRoute(Route4 route)
        {
            NetlinkRoute4 nlr = new NetlinkRoute4();
            nlr.destination = Util.ip4touint(route.destination);
            nlr.gateway = Util.ip4touint(route.gateway);
            nlr.netmask = route.netmask;
            nlr.protocol = (byte) RoutingProtocol.Unspecified;
            nlr.nic = 0;

            removeRoute(m_sockfd, m_pid, &nlr);
        }

    }
}