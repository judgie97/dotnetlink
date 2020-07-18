using System.Linq;
using System.Management.Automation;
using dotnetlink;
using dotnetlinkps.Interfaces;
using libnl;

namespace dotnetlinkps.Routes
{
    [Cmdlet(VerbsCommon.Get, "Route")]
    [OutputType(typeof(RouteDto))]
    public class GetRoute4 : PSCmdlet
    {
        private Route4[] routes;
        private NetworkInterface[] interfaces;

        [Parameter(Mandatory = false)] public RoutingTable RoutingTable { get; set; } = RoutingTable.MAIN;

        [Parameter(Mandatory = false)] public RouteScope RouteScope { get; set; } = RouteScope.ANY;

        protected override void BeginProcessing()
        {
            NetlinkSocket socket = SingletonRepository.getNetlinkSocket();
            routes = socket.getRoutingTable();
            interfaces = socket.getNetworkInterfaces();

            if (RoutingTable != RoutingTable.ANY)
                routes = routes.Where(r => r.routingTable == RoutingTable).ToArray();

            if (RouteScope != RouteScope.ANY)
                routes = routes.Where(r => r.scope == RouteScope).ToArray();

        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }

        private void WriteRoute(Route4 route)
        {
            RouteDto routeDto = new RouteDto
            {
                Destination =  route.destination,
                Gateway = route.gateway,
                Interface = InterfaceDtoUtil.ConvertToDto(route.nic, interfaces),
                Protocol = route.protocol,
                RoutingTable = route.routingTable,
                Scope = route.scope,
                Priority = route.priority
            };
            WriteObject(routeDto);
        }

        protected override void EndProcessing()
        {
            foreach (var route in routes)
            {
                WriteRoute(route);
            }
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}