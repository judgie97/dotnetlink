using dotnetlink;

namespace dotnetlinkps
{
    public class SingletonRepository
    {
        private static NetlinkSocket m_nlsock = null;

        public static NetlinkSocket getNetlinkSocket()
        {
            if (m_nlsock == null)
                m_nlsock = new NetlinkSocket();
            return m_nlsock;
        }
    }
}