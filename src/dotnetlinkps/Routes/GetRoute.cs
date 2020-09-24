using System;
using System.Linq;
using System.Management.Automation;
using dotnetlink;
using dotnetlinkps.Interfaces;
using libnl;

namespace dotnetlinkps.Routes
{
    [Cmdlet(VerbsCommon.Get, "Route")]
    [OutputType(typeof(RouteDto))]
    public class GetRoute : PSCmdlet
    {
        private Route[] _routes;
        private NetworkInterface[] _interfaces;

        [Parameter(Mandatory = false)] public RoutingTable RoutingTable { get; set; } = RoutingTable.MAIN;

        [Parameter(Mandatory = false)] public RouteScope RouteScope { get; set; } = RouteScope.ANY;

        [Parameter(Mandatory = false)] public int IpVersion { get; set; } = 4;

        protected override void BeginProcessing()
        {
            var socket = SingletonRepository.getNetlinkSocket();
            if (IpVersion == 4)
                _routes = socket.GetRoutingTable();
            else if(IpVersion == 6)
                _routes = socket.GetIpv6RoutingTable();
            else
                throw new NotSupportedException("IP version must be 4 or 6");
            _interfaces = socket.GetNetworkInterfaces();

            if (RoutingTable != RoutingTable.ANY)
                _routes = _routes.Where(r => r.RoutingTable == RoutingTable).ToArray();

            if (RouteScope != RouteScope.ANY)
                _routes = _routes.Where(r => r.Scope == RouteScope).ToArray();

        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }

        private void WriteRoute(Route route)
        {
            RouteDto routeDto = new RouteDto
            {
                Destination =  route.Destination,
                Gateway = route.Gateway,
                Interface = InterfaceDtoUtil.ConvertToDto(route.Nic, _interfaces),
                Protocol = route.Protocol,
                RoutingTable = route.RoutingTable,
                Scope = route.Scope,
                Priority = route.Priority
            };
            WriteObject(routeDto);
        }

        protected override void EndProcessing()
        {
            foreach (var route in _routes)
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