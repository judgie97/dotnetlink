namespace libnl
{
    public enum RoutingTable
    {
        ANY = -1,
        RT_TABLE_UNSPEC = 0,
        RT_TABLE_COMPAT=252,
        RT_TABLE_DEFAULT=253,
        RT_TABLE_MAIN=254,
        RT_TABLE_LOCAL=255
    }
    
    public enum RouteScope {
        ANY = -1,
        RT_SCOPE_UNIVERSE=0,
        RT_SCOPE_SITE=200,
        RT_SCOPE_LINK=253,
        RT_SCOPE_HOST=254,
        RT_SCOPE_NOWHERE=255
    };
}