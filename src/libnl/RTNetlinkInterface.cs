namespace libnl
{
    public static class NLInterfaceFlags
    {
        public const int UP = 1 << 0;
        public const int BROADCAST = 1 << 1;
        public const int DEBUG = 1 << 2;
        public const int LOOPBACK = 1 << 3;
        public const int POINTOPOINT = 1 << 4;
        public const int NOTRAILERS = 1 << 5;
        public const int RUNNING = 1 << 6;
        public const int NOARP = 1 << 7;
        public const int PROMISC = 1 << 8;
        public const int ALLMULTI = 1 << 9;
        public const int MASTER = 1 << 10;
        public const int SLAVE = 1 << 11;
        public const int MULTICAST = 1 << 12;
        public const int PORTSEL = 1 << 13;
        public const int AUTOMEDIA = 1 << 14;
        public const int DYNAMIC = 1 << 15;
        public const int LOWER_UP = 1 << 16;
        public const int DORMANT = 1 << 17;
        public const int ECHO = 1 << 18;
    }

    public enum rtnl_link_stat_id_t
    {
        RTNL_LINK_RX_PACKETS, /*!< Packets received */
        RTNL_LINK_TX_PACKETS, /*!< Packets sent */
        RTNL_LINK_RX_BYTES, /*!< Bytes received */
        RTNL_LINK_TX_BYTES, /*!< Bytes sent */
        RTNL_LINK_RX_ERRORS, /*!< Receive errors */
        RTNL_LINK_TX_ERRORS, /*!< Send errors */
        RTNL_LINK_RX_DROPPED, /*!< Received packets dropped */
        RTNL_LINK_TX_DROPPED, /*!< Packets dropped during transmit */
        RTNL_LINK_RX_COMPRESSED, /*!< Compressed packets received */
        RTNL_LINK_TX_COMPRESSED, /*!< Compressed packets sent */
        RTNL_LINK_RX_FIFO_ERR, /*!< Receive FIFO errors */
        RTNL_LINK_TX_FIFO_ERR, /*!< Send FIFO errors */
        RTNL_LINK_RX_LEN_ERR, /*!< Length errors */
        RTNL_LINK_RX_OVER_ERR, /*!< Over errors */
        RTNL_LINK_RX_CRC_ERR, /*!< CRC errors */
        RTNL_LINK_RX_FRAME_ERR, /*!< Frame errors */
        RTNL_LINK_RX_MISSED_ERR, /*!< Missed errors */
        RTNL_LINK_TX_ABORT_ERR, /*!< Aborted errors */
        RTNL_LINK_TX_CARRIER_ERR, /*!< Carrier errors */
        RTNL_LINK_TX_HBEAT_ERR, /*!< Heartbeat errors */
        RTNL_LINK_TX_WIN_ERR, /*!< Window errors */
        RTNL_LINK_COLLISIONS, /*!< Send collisions */
        RTNL_LINK_MULTICAST, /*!< Multicast */
        RTNL_LINK_IP6_INPKTS, /*!< IPv6 SNMP InReceives */
        RTNL_LINK_IP6_INHDRERRORS, /*!< IPv6 SNMP InHdrErrors */
        RTNL_LINK_IP6_INTOOBIGERRORS, /*!< IPv6 SNMP InTooBigErrors */
        RTNL_LINK_IP6_INNOROUTES, /*!< IPv6 SNMP InNoRoutes */
        RTNL_LINK_IP6_INADDRERRORS, /*!< IPv6 SNMP InAddrErrors */
        RTNL_LINK_IP6_INUNKNOWNPROTOS, /*!< IPv6 SNMP InUnknownProtos */
        RTNL_LINK_IP6_INTRUNCATEDPKTS, /*!< IPv6 SNMP InTruncatedPkts */
        RTNL_LINK_IP6_INDISCARDS, /*!< IPv6 SNMP InDiscards */
        RTNL_LINK_IP6_INDELIVERS, /*!< IPv6 SNMP InDelivers */
        RTNL_LINK_IP6_OUTFORWDATAGRAMS, /*!< IPv6 SNMP OutForwDatagrams */
        RTNL_LINK_IP6_OUTPKTS, /*!< IPv6 SNMP OutRequests */
        RTNL_LINK_IP6_OUTDISCARDS, /*!< IPv6 SNMP OutDiscards */
        RTNL_LINK_IP6_OUTNOROUTES, /*!< IPv6 SNMP OutNoRoutes */
        RTNL_LINK_IP6_REASMTIMEOUT, /*!< IPv6 SNMP ReasmTimeout */
        RTNL_LINK_IP6_REASMREQDS, /*!< IPv6 SNMP ReasmReqds */
        RTNL_LINK_IP6_REASMOKS, /*!< IPv6 SNMP ReasmOKs */
        RTNL_LINK_IP6_REASMFAILS, /*!< IPv6 SNMP ReasmFails */
        RTNL_LINK_IP6_FRAGOKS, /*!< IPv6 SNMP FragOKs */
        RTNL_LINK_IP6_FRAGFAILS, /*!< IPv6 SNMP FragFails */
        RTNL_LINK_IP6_FRAGCREATES, /*!< IPv6 SNMP FragCreates */
        RTNL_LINK_IP6_INMCASTPKTS, /*!< IPv6 SNMP InMcastPkts */
        RTNL_LINK_IP6_OUTMCASTPKTS, /*!< IPv6 SNMP OutMcastPkts */
        RTNL_LINK_IP6_INBCASTPKTS, /*!< IPv6 SNMP InBcastPkts */
        RTNL_LINK_IP6_OUTBCASTPKTS, /*!< IPv6 SNMP OutBcastPkts */
        RTNL_LINK_IP6_INOCTETS, /*!< IPv6 SNMP InOctets */
        RTNL_LINK_IP6_OUTOCTETS, /*!< IPv6 SNMP OutOctets */
        RTNL_LINK_IP6_INMCASTOCTETS, /*!< IPv6 SNMP InMcastOctets */
        RTNL_LINK_IP6_OUTMCASTOCTETS, /*!< IPv6 SNMP OutMcastOctets */
        RTNL_LINK_IP6_INBCASTOCTETS, /*!< IPv6 SNMP InBcastOctets */
        RTNL_LINK_IP6_OUTBCASTOCTETS, /*!< IPv6 SNMP OutBcastOctets */
        RTNL_LINK_ICMP6_INMSGS, /*!< ICMPv6 SNMP InMsgs */
        RTNL_LINK_ICMP6_INERRORS, /*!< ICMPv6 SNMP InErrors */
        RTNL_LINK_ICMP6_OUTMSGS, /*!< ICMPv6 SNMP OutMsgs */
        RTNL_LINK_ICMP6_OUTERRORS, /*!< ICMPv6 SNMP OutErrors */
        RTNL_LINK_ICMP6_CSUMERRORS, /*!< ICMPv6 SNMP InCsumErrors */
        RTNL_LINK_IP6_CSUMERRORS, /*!< IPv6 SNMP InCsumErrors */
        RTNL_LINK_IP6_NOECTPKTS, /*!< IPv6 SNMP InNoECTPkts */
        RTNL_LINK_IP6_ECT1PKTS, /*!< IPv6 SNMP InECT1Pkts */
        RTNL_LINK_IP6_ECT0PKTS, /*!< IPv6 SNMP InECT0Pkts */
        RTNL_LINK_IP6_CEPKTS, /*!< IPv6 SNMP InCEPkts */
        RTNL_LINK_RX_NOHANDLER, /*!< Received packets dropped on inactive device */
        RTNL_LINK_REASM_OVERLAPS, /*!< SNMP ReasmOverlaps */
        __RTNL_LINK_STATS_MAX
    }
}