using System;
using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.Set, "Interface")]
    public class SetInterface : PSCmdlet
    {
        [Parameter(Mandatory = true)] public int Identity { get; set; }

        [Parameter] public InterfaceState State { get; set; } = InterfaceState.UNSPECIFIED;

        protected override void BeginProcessing()
        {
            NetlinkSocket socket = SingletonRepository.getNetlinkSocket();
            if (State != InterfaceState.UNSPECIFIED)
            {
                socket.setInterfaceState(Identity, State);
            }
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