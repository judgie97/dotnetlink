// ReSharper disable once CheckNamespace

namespace dotnetlink
{
    public unsafe partial class NetlinkSocket
    {
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
    }
}