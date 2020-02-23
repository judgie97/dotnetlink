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
    }
}