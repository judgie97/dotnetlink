using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace dotnetlink
{
    public class NetlinkSocket
    {
        private static int NETLINK_ROUTE = 0;
        
        [DllImport("libdotnetlinkconnector.so")]
        private static extern int openNetlinkSocket(uint portID, int protocol);

        [DllImport("libdotnetlinkconnector.so")]
        private static extern unsafe int requestAllRoutes(int sock, byte** storage);
        
        [DllImport("libdotnetlinkconnector.so")]
        private static extern int closeNetlinkSocket(int sock);
        
        [DllImport("libdotnetlinkconnector.so")]
        private static extern unsafe int addRoute(int sock, uint portID, NetlinkRoute4* route);
        
        [DllImport("libdotnetlinkconnector.so")]
        private static extern unsafe int removeRoute(int sock, uint portID, NetlinkRoute4* route);
        
        [DllImport("libdotnetlinkconnector.so")]
        private static extern unsafe int addIPAddress(int sock, uint portID, NetlinkIPAddress4* address);
        
        [DllImport("libdotnetlinkconnector.so")]
        private static extern unsafe int removeIPAddress(int sock, uint portID, NetlinkIPAddress4* address);

        [DllImport("libdotnetlinkconnector.so")]
        private static extern unsafe int requestAllAddresses(int sock, byte** storage);
        
        [DllImport("libdotnetlinkconnector.so")]
        private static extern unsafe int requestAllNetworkInterfaces(int sock, byte** storage);
        
        [DllImport("libdotnetlinkconnector.so")]
        private static extern unsafe int setNetworkInterface(int sock, uint portID, uint interfaceIndex, bool up);
        
        [DllImport("libdotnetlinkconnector.so")]
        private static extern unsafe int addInterface(int sock, uint portID, NetlinkInterface* nic);

        
        private int m_sockfd;
        private uint m_pid;
        public NetlinkSocket()
        {
            m_pid = (uint)Process.GetCurrentProcess().Id;
            m_sockfd = openNetlinkSocket(m_pid, NETLINK_ROUTE);
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

        public unsafe void addIPAddress(IPAddress4 address)
        {
            NetlinkIPAddress4 ip4 = new NetlinkIPAddress4();
            ip4.address = Util.ip4touint(address.address);
            ip4.netmask = address.netmask;
            ip4.nic = address.nic;

            addIPAddress(m_sockfd, m_pid, &ip4);
        }
        
        public unsafe void removeIPAddress(IPAddress4 address)
        {
            NetlinkIPAddress4 ip4 = new NetlinkIPAddress4();
            ip4.address = Util.ip4touint(address.address);
            ip4.netmask = address.netmask;
            ip4.nic = address.nic;

            removeIPAddress(m_sockfd, m_pid, &ip4);
        }
        
        public unsafe IPAddress4[] getAddresses()
        {
            byte* netlinkAddresses;
            int count = requestAllAddresses(m_sockfd, &netlinkAddresses);
            byte* currentAddress = netlinkAddresses;
            IPAddress4[] addresses = new IPAddress4[count];
            for (int i = 0; i < count; i++)
            {
                NetlinkIPAddress4 a = (NetlinkIPAddress4) Marshal.PtrToStructure((IntPtr) currentAddress, typeof(NetlinkIPAddress4));
                currentAddress += sizeof(NetlinkIPAddress4);
                addresses[i] = a.toIPAddress4();
            }
            return addresses;
        }
        
        public unsafe NetworkInterface[] getNetworkInterfaces()
        {
            byte* netlinkInterfaces;
            int count = requestAllNetworkInterfaces(m_sockfd, &netlinkInterfaces);
            byte* currentInterface = netlinkInterfaces;
            NetworkInterface[] interfaces = new NetworkInterface[count];
            for (int i = 0; i < count; i++)
            {
                NetlinkInterface a = (NetlinkInterface) Marshal.PtrToStructure((IntPtr) currentInterface, typeof(NetlinkInterface));
                currentInterface += sizeof(NetlinkInterface);
                interfaces[i] = a.toNetworkInterface();
            }
            return interfaces;
        }
        
        public unsafe void setNetworkInterface(NetworkInterface networkInterface, bool up)
        {
            setNetworkInterface(m_sockfd, m_pid, networkInterface.index, up);
        }
        
        public unsafe void addNetworkInterface(NetworkInterface networkInterface)
        {
            NetlinkInterface netlinkInterface = new NetlinkInterface(networkInterface);
            
            addInterface(m_sockfd, m_pid, &netlinkInterface);
        }
    }
}