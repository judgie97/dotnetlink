using System;
using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.Get, "Route4")]
    public class GetRoute4 : PSCmdlet
    {
        private Route4[] routes;
        
        protected override void BeginProcessing()
        {
            NetlinkSocket socket = SingletonRepository.getNetlinkSocket();
            routes = socket.getRoutingTable();
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