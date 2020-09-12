using System.Management.Automation;
using System.Net;
using dotnetlink;
using libnl;

namespace dotnetlinkps.Routes
{
    [Cmdlet(VerbsCommon.Add, "Route")]
    public class AddRoute : PSCmdlet
    {
        private NetlinkSocket _socket;

        [Parameter] public IPAddress Destination { get; set; }
        [Parameter] public byte DestinationSubnetMask { get; set; }
        [Parameter] public IPAddress Gateway { get; set; }
        [Parameter] public RoutingProtocol Protocol { get; set; } = RoutingProtocol.STATIC;
        [Parameter] public RoutingTable Table { get; set; } = RoutingTable.MAIN;

        protected override void BeginProcessing()
        {
            _socket = SingletonRepository.getNetlinkSocket();
            _socket.AddRoute(
                new Route4(new Subnet(Destination, DestinationSubnetMask), Gateway, 0, Protocol, Table));
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}