using System.ComponentModel;

namespace dotnetlink
{
    public enum RoutingProtocol
    {
        Unspecified = 0,
        Redirect = 1,
        Kernel = 2,
        Boot = 3,
        Static = 4,
        Gated = 8,
        RouterAdvertisements = 9,
        MRT = 10,
        ZEBRA = 11,
        BIRD = 12,
        DecNet = 13,
        XORP = 14,
        NetSukuku = 15,
        DHCP = 16,
        Multicast = 17,
        Babel = 42,
        BGP = 186,
        ISIS = 187,
        OSPF = 188,
        RIP = 189,
        EIGRP = 192
    }
}