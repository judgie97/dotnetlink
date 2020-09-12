using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps.Routes
{
    [Cmdlet(VerbsCommon.Remove, "Route")]
    public class RemoveRoute : PSCmdlet
    {
        private NetlinkSocket _socket;

        [Parameter] public Route4 Route { get; set; }

        protected override void BeginProcessing()
        {
            _socket = SingletonRepository.getNetlinkSocket();
            _socket.RemoveRoute(Route);
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