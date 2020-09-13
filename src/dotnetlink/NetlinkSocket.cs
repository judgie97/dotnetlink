using System;
using libnl;
// ReSharper disable UnusedMember.Global

namespace dotnetlink
{
    public unsafe class NetlinkSocket
    {
        private nl_sock* _sockFd;

        public NetlinkSocket()
        {
            _sockFd = LibNL3.nl_socket_alloc();
            LibNL3.nl_connect(_sockFd, 0);
        }

        ~NetlinkSocket()
        {
            LibNL3.nl_close(_sockFd);
            LibNL3.nl_socket_free(_sockFd);
            _sockFd = (nl_sock*) 0;
        }


        public Route[] GetRoutingTable()
        {
            Route[] routes = Connector.RequestAllRoutes(_sockFd, false);
            return routes;
        }
        
        public Route[] GetIpv6RoutingTable()
        {
            Route[] routes = Connector.RequestAllRoutes(_sockFd, true);
            return routes;
        }

        public void AddRoute(Route route)
        {
            int r = Connector.AddRoute(_sockFd, route);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }

        public void RemoveRoute(Route route)
        {
            int r = Connector.RemoveRoute(_sockFd, route);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }

        public void AddIpAddress(IpAddress address)
        {
            int r = Connector.AddIpAddress(_sockFd, address);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }

        public void RemoveIpAddress(IpAddress address)
        {
            int r = Connector.RemoveIpAddress(_sockFd, address);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }

        public IpAddress[] GetAddresses()
        {
            IpAddress[] addresses = Connector.RequestAllAddresses(_sockFd);
            return addresses;
        }

        public NetworkInterface[] GetNetworkInterfaces()
        {
            NetworkInterface[] interfaces = Connector.RequestAllNetworkInterfaces(_sockFd);
            return interfaces;
        }
        
        public NetworkInterface GetNetworkInterface(string name)
        {
            NetworkInterface networkInterface = Connector.RequestInterface(_sockFd, name);
            return networkInterface;
        }

        public void SetInterfaceState(int index, InterfaceState state)
        {
            int r = Connector.SetNetworkInterfaceState(_sockFd, index, state == InterfaceState.UP);
            if (r < 0)
            {
                Console.WriteLine(r);
                throw new NetlinkSocketException(r);
            }
        }
        
        public void SetInterfaceName(int index, string name)
        {
            int r = Connector.SetNetworkInterfaceName(_sockFd, index, name);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }

        public void SetNetworkInterfaceMaximumTransmissionUnit(int index, uint mtu)
        {
            int r = Connector.SetNetworkInterfaceMaximumTransmissionUnit(_sockFd, index, mtu);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }
        
        public void AddNetworkInterface(NetworkInterface networkInterface)
        {
            int r = Connector.AddInterface(_sockFd, networkInterface);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }

        public void RemoveNetworkInterface(NetworkInterface networkInterface)
        {
            int r = Connector.RemoveInterface(_sockFd, networkInterface);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }

        public void SetInterfaceVlanId(in int nicIndex, ushort vlanId)
        {
            int r = Connector.SetInterfaceVlanId(_sockFd, nicIndex, vlanId);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }

        public InterfaceStatistics GetInterfaceStatistics(NetworkInterface networkInterface)
        {
            return Connector.GetInterfaceStatistics(_sockFd, networkInterface.Index);
        }

        public Neighbour[] GetArpCache()
        {
            return Connector.GetArpCache(_sockFd);
        }
    }
}