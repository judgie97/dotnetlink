using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps
{
    [Cmdlet(VerbsLifecycle.Enable, "NetworkInterface")]
    public class EnableNetworkInterface : PSCmdlet
    {
        [Parameter(Position = 0)] public NetworkInterface nic;
        protected override void BeginProcessing()
        {
            NetlinkSocket socket = SingletonRepository.getNetlinkSocket();
            socket.setNetworkInterface(nic, true);
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