using dotnetlink;

namespace dotnetlinkps
{
    internal static class SingletonRepository
    {
        private static NetlinkSocket _netlinkSocket;

        public static NetlinkSocket getNetlinkSocket()
        {
            return _netlinkSocket ??= new NetlinkSocket();
        }

        private static NetfilterSocket _netfilterSocket;

        public static NetfilterSocket getNetfilterSocket()
        {
            return _netfilterSocket ??= new NetfilterSocket();
        }
    }
}