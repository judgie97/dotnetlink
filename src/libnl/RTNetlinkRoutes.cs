namespace libnl
{
    public enum RoutingTable
    {
        ANY = -1,
        UNSPEC = 0,
        COMPAT=252,
        DEFAULT=253,
        MAIN=254,
        LOCAL=255
    }
    
    public enum RouteScope {
        ANY = -1,
        UNIVERSE=0,
        SITE=200,
        LINK=253,
        HOST=254,
        NOWHERE=255
    };
    
    public enum RoutingProtocol
    {
        ANY = -1,
        UNSPECIFIED = 0,
        REDIRECT = 1,
        KERNEL = 2,
        BOOT = 3,
        STATIC = 4,
        GATED = 8,
        ROUTER_ADVERTISEMENTS = 9,
        MRT = 10,
        ZEBRA = 11,
        BIRD = 12,
        DEC_NET = 13,
        XORP = 14,
        NET_SUKUKU = 15,
        DHCP = 16,
        MULTICAST = 17,
        BABEL = 42,
        BGP = 186,
        ISIS = 187,
        OSPF = 188,
        RIP = 189,
        EIGRP = 192
    }
}