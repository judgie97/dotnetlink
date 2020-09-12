using libnl;
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedMember.Global

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public class InterfaceStatistics
    {
        private readonly ulong[] _stats;

        public InterfaceStatistics(ulong[] statistics)
        {
            _stats = statistics;
        }

        public ulong GetStatistic(rtnl_link_stat_id_t statistic)
        {
            return _stats[(int) statistic];
        }

        public ulong GetPacketsReceived()
        {
            return _stats[(int) rtnl_link_stat_id_t.RTNL_LINK_RX_PACKETS];
        }
        
        public ulong GetPacketsTransmitted()
        {
            return _stats[(int) rtnl_link_stat_id_t.RTNL_LINK_TX_PACKETS];
        }
        
        public ulong GetBytesReceived()
        {
            return _stats[(int) rtnl_link_stat_id_t.RTNL_LINK_RX_BYTES];
        }
        
        public ulong GetBytesTransmitted()
        {
            return _stats[(int) rtnl_link_stat_id_t.RTNL_LINK_TX_BYTES];
        }
    }
}