using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.Remove, "NetworkInterface")]
    public class RemoveNetworkInterface : PSCmdlet
    {
        [Parameter(Position = 0)] public NetworkInterface nic;

        protected override void BeginProcessing()
        {
            NetlinkSocket socket = SingletonRepository.getNetlinkSocket();
            socket.removeNetworkInterface(nic);
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