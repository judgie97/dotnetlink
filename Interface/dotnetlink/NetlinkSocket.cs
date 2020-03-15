using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace dotnetlink
{
    public unsafe class NetlinkSocket
    {
        private void* m_sockfd;

        public NetlinkSocket()
        {
            m_sockfd = Connector.openNetlinkSocket();
        }

        ~NetlinkSocket()
        {
            Connector.closeNetlinkSocket(m_sockfd);
        }
        
        public Route4[] getRoutingTable()
        {
            byte* netlinkRoutes;
            int count = Connector.requestAllRoutes(m_sockfd, &netlinkRoutes);
            if (count < 0)
            {
                throw new NetlinkSocketException((NetlinkExceptionValue)count);
            }
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
        
        public void addRoute(Route4 route)
        {
            NetlinkRoute4 nlr = new NetlinkRoute4();
            nlr.destination = Util.ip4touint(route.destination);
            nlr.gateway = Util.ip4touint(route.gateway);
            nlr.netmask = route.netmask;
            nlr.nic = 0;
            nlr.protocol = (byte)route.protocol;

            int r = Connector.addRoute(m_sockfd, &nlr);
            if (r < 0)
            {
                throw new NetlinkSocketException((NetlinkExceptionValue)r);
            }
        }
        
        public void removeRoute(Route4 route)
        {
            NetlinkRoute4 nlr = new NetlinkRoute4();
            nlr.destination = Util.ip4touint(route.destination);
            nlr.gateway = Util.ip4touint(route.gateway);
            nlr.netmask = route.netmask;
            nlr.protocol = (byte) RoutingProtocol.Unspecified;
            nlr.nic = 0;

            int r = Connector.removeRoute(m_sockfd, &nlr);
            if (r < 0)
            {
                throw new NetlinkSocketException((NetlinkExceptionValue)r);
            }
        }

        public void addIPAddress(IPAddress4 address)
        {
            NetlinkIPAddress4 ip4 = new NetlinkIPAddress4();
            ip4.address = Util.ip4touint(address.address);
            ip4.netmask = address.netmask;
            ip4.nic = address.nic;

            int r = Connector.addIPAddress(m_sockfd, &ip4);
            if (r < 0)
            {
                throw new NetlinkSocketException((NetlinkExceptionValue)r);
            }
        }
        
        public void removeIPAddress(IPAddress4 address)
        {
            NetlinkIPAddress4 ip4 = new NetlinkIPAddress4();
            ip4.address = Util.ip4touint(address.address);
            ip4.netmask = address.netmask;
            ip4.nic = address.nic;

            int r = Connector.removeIPAddress(m_sockfd, &ip4);
            if (r < 0)
            {
                throw new NetlinkSocketException((NetlinkExceptionValue)r);
            }
        }
        
        public IPAddress4[] getAddresses()
        {
            byte* netlinkAddresses;
            int count = Connector.requestAllAddresses(m_sockfd, &netlinkAddresses);
            if (count < 0)
            {
                throw new NetlinkSocketException((NetlinkExceptionValue)count);
            }
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
        
        public NetworkInterface[] getNetworkInterfaces()
        {
            byte* netlinkInterfaces;
            int count = Connector.requestAllNetworkInterfaces(m_sockfd, &netlinkInterfaces);
            if (count < 0)
            {
                throw new NetlinkSocketException((NetlinkExceptionValue)count);
            }
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
        
        public void setNetworkInterface(NetworkInterface networkInterface, bool up)
        {
            int r = Connector.setNetworkInterface(m_sockfd, networkInterface.index, up);
            if (r < 0)
            {
                throw new NetlinkSocketException((NetlinkExceptionValue)r);
            }
        }
        
        public void addNetworkInterface(NetworkInterface networkInterface)
        {
            NetlinkInterface netlinkInterface = new NetlinkInterface(networkInterface);
            
            int r = Connector.addInterface(m_sockfd, &netlinkInterface);
            if (r < 0)
            {
                throw new NetlinkSocketException((NetlinkExceptionValue)r);
            }
        }
        
        public void removeNetworkInterface(NetworkInterface networkInterface)
        {
            int r = Connector.removeInterface(m_sockfd, networkInterface.index);
            if (r < 0)
            {
                throw new NetlinkSocketException((NetlinkExceptionValue)r);
            }
        }
    }
}