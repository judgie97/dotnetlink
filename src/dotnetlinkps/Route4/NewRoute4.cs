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
        public IPAddress destination;
        
        [Parameter]
        public IPAddress gateway;
        
        [Parameter]
        public byte netmask;

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
            WriteObject(new Route4(destination, netmask, gateway, 0, (RoutingProtocol) 4, RoutingTable.RT_TABLE_MAIN));
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}