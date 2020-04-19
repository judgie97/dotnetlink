using System.Management.Automation;
using System.Net;
using dotnetlink;
using libnl;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.New, "Route4")]
    public class NewRoute4 : PSCmdlet
    {
        [Parameter]
        public IPAddress Destination;
        
        [Parameter]
        public IPAddress Gateway;
        
        [Parameter]
        public byte Netmask;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }

        protected override void EndProcessing()
        {
            WriteObject(new Route4(new Subnet(Destination, Netmask), Gateway, 0, RoutingProtocol.STATIC, RoutingTable.MAIN));
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}