using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using libnl;

namespace dotnetlink
{
    public unsafe class NetlinkSocket
    {
        private nl_sock* m_sockfd;

        public NetlinkSocket()
        {
            m_sockfd = LibNL3.nl_socket_alloc();
            LibNL3.nl_connect(m_sockfd, 0);
        }

        ~NetlinkSocket()
        {
            LibNL3.nl_close(m_sockfd);
            LibNL3.nl_socket_free(m_sockfd);
            m_sockfd = (nl_sock*)0;
        }
        
        
        public Route4[] getRoutingTable()
        {
            Route4[] routes = Connector.requestAllRoutes(m_sockfd);
            return routes;
        }
        
        public void addRoute(Route4 route)
        {
            int r = Connector.addRoute(m_sockfd, route);
            if (r < 0)
            {
                throw new NetlinkSocketException((NetlinkExceptionValue)r);
            }
        }
        
        public void removeRoute(Route4 route)
        {
            int r = Connector.removeRoute(m_sockfd, route);
            if (r < 0)
            {
                throw new NetlinkSocketException((NetlinkExceptionValue)r);
            }
        }

        public void addIPAddress(IPAddress4 address)
        {
            int r = Connector.addIPAddress(m_sockfd, address);
            if (r < 0)
            {
                throw new NetlinkSocketException((NetlinkExceptionValue)r);
            }
        }
        
        public void removeIPAddress(IPAddress4 address)
        {
            int r = Connector.removeIPAddress(m_sockfd, address);
            if (r < 0)
            {
                throw new NetlinkSocketException((NetlinkExceptionValue)r);
            }
        }
        
        public IPAddress4[] getAddresses()
        {
            IPAddress4[] addresses = Connector.requestAllAddresses(m_sockfd);
            return addresses;
        }
        
        public NetworkInterface[] getNetworkInterfaces()
        {
            NetworkInterface[] interfaces = Connector.requestAllNetworkInterfaces(m_sockfd);
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
            int r = Connector.addInterface(m_sockfd, networkInterface);
            if (r < 0)
            {
                throw new NetlinkSocketException((NetlinkExceptionValue)r);
            }
        }
        
        public void removeNetworkInterface(NetworkInterface networkInterface)
        {
            int r = Connector.removeInterface(m_sockfd, networkInterface);
            if (r < 0)
            {
                throw new NetlinkSocketException((NetlinkExceptionValue)r);
            }
        }
    }
}