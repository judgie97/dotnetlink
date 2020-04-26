using System.Linq;
using System.Management.Automation;
using dotnetlink;
using libnl;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.Get, "Route4")]
    [OutputType(typeof(Route4))]
    public class GetRoute4 : PSCmdlet
    {
        private Route4[] routes;
        
        [Parameter(Mandatory = false)]
        public RoutingTable RoutingTable
        {
            get { return routingTable; }
            set { routingTable = value; }
        }
        private RoutingTable routingTable = RoutingTable.MAIN;
        
        [Parameter(Mandatory = false)]
        public RouteScope RouteScope
        {
            get { return routeScope; }
            set { routeScope = value; }
        }
        private RouteScope routeScope = RouteScope.ANY;
        
        protected override void BeginProcessing()
        {
            NetlinkSocket socket = SingletonRepository.getNetlinkSocket();
            routes = socket.getRoutingTable();

            if (routingTable != RoutingTable.ANY)
                routes = routes.Where(r => r.routingTable == routingTable).ToArray();
            
            if (routeScope != RouteScope.ANY)
                routes = routes.Where(r => r.scope == routeScope).ToArray();

        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }

        protected override void EndProcessing()
        {
            foreach (var route in routes)
            {
                WriteObject(route);
            }
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}