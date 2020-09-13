// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public unsafe partial class NetlinkSocket
    {
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
    }
}