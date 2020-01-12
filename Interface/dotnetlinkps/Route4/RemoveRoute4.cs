using System.Management.Automation;
using System.Net;
using dotnetlink;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.Remove, "Route4")]
    public class RemoveRoute4 : PSCmdlet
    {
        private NetlinkSocket socket;
            
        [Parameter]
        public Route4 route;

        protected override void BeginProcessing()
        {
            socket = SingletonRepository.getNetlinkSocket();
            socket.removeRoute(route);
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