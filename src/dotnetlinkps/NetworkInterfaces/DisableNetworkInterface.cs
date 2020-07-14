using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps
{
    [Cmdlet(VerbsLifecycle.Disable, "NetworkInterface")]

    public class DisableNetworkInterface : PSCmdlet
    {
        [Parameter(Position = 0)] public NetworkInterface nic;
        protected override void BeginProcessing()
        {
            NetlinkSocket socket = SingletonRepository.getNetlinkSocket();
            socket.setInterfaceState(nic.index, InterfaceState.DOWN);
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