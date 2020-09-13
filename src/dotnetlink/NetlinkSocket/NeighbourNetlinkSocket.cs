// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public unsafe partial class NetlinkSocket
    {
        public Neighbour[] GetArpCache()
        {
            return Connector.GetArpCache(_sockFd);
        }
    }
}