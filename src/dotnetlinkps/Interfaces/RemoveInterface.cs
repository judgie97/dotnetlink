using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps.Interfaces
{
    [Cmdlet(VerbsCommon.Remove, "Interface")]
    public class RemoveInterface : PSCmdlet
    {
        [Parameter(Position = 0)] public NetworkInterface Interface;

        protected override void BeginProcessing()
        {
            var socket = SingletonRepository.getNetlinkSocket();
            socket.RemoveNetworkInterface(Interface);
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