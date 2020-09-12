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
            m_sockfd = (nl_sock*) 0;
        }


        public Route4[] getRoutingTable()
        {
            Route4[] routes = Connector.RequestAllRoutes(m_sockfd);
            return routes;
        }

        public void addRoute(Route4 route)
        {
            int r = Connector.AddRoute(m_sockfd, route);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }

        public void removeRoute(Route4 route)
        {
            int r = Connector.RemoveRoute(m_sockfd, route);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }

        public void addIPAddress(IPAddress4 address)
        {
            int r = Connector.AddIpAddress(m_sockfd, address);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }

        public void removeIPAddress(IPAddress4 address)
        {
            int r = Connector.RemoveIpAddress(m_sockfd, address);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }

        public IPAddress4[] getAddresses()
        {
            IPAddress4[] addresses = Connector.RequestAllAddresses(m_sockfd);
            return addresses;
        }

        public NetworkInterface[] getNetworkInterfaces()
        {
            NetworkInterface[] interfaces = Connector.RequestAllNetworkInterfaces(m_sockfd);
            return interfaces;
        }
        
        public NetworkInterface getNetworkInterface(String name)
        {
            NetworkInterface networkInterface = Connector.RequestInterface(m_sockfd, name);
            return networkInterface;
        }

        public void setInterfaceState(int index, InterfaceState state)
        {
            int r = Connector.SetNetworkInterfaceState(m_sockfd, index, state == InterfaceState.UP);
            if (r < 0)
            {
                Console.WriteLine(r);
                throw new NetlinkSocketException(r);
            }
        }

        public void setInterfaceName(int index, String name)
        {
            int r = Connector.SetNetworkInterfaceName(m_sockfd, index, name);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }

        public void addNetworkInterface(NetworkInterface networkInterface)
        {
            int r = Connector.AddInterface(m_sockfd, networkInterface);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }

        public void removeNetworkInterface(NetworkInterface networkInterface)
        {
            int r = Connector.RemoveInterface(m_sockfd, networkInterface);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }

        public void setInterfaceVlanID(in int nicIndex, ushort vlanId)
        {
            int r = Connector.SetInterfaceVlanId(m_sockfd, nicIndex, vlanId);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }
    }
}