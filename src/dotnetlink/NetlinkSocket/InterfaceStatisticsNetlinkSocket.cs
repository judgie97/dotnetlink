// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public unsafe partial class NetlinkSocket
    {
        public InterfaceStatistics GetInterfaceStatistics(NetworkInterface networkInterface)
        {
            return Connector.GetInterfaceStatistics(_sockFd, networkInterface.Index);
        }
    }
}