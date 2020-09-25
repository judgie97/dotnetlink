// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public unsafe partial class NetlinkSocket
    {
        public Route[] GetRoutingTable()
        {
            Route[] routes = Connector.RequestAllRoutes(_sockFd, false);
            return routes;
        }
        
        public Route GetRoute(Subnet destinationSubnet)
        {
            return Connector.RequestRoute(_sockFd, destinationSubnet);
        }
        
        public Route[] GetIpv6RoutingTable()
        {
            Route[] routes = Connector.RequestAllRoutes(_sockFd, true);
            return routes;
        }

        public void AddRoute(Route route)
        {
            int r = Connector.AddRoute(_sockFd, route);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }

        public void RemoveRoute(Route route)
        {
            int r = Connector.RemoveRoute(_sockFd, route);
            if (r < 0)
            {
                throw new NetlinkSocketException(r);
            }
        }
    }
}