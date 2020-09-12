using System;
using System.Linq;
using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps.Interfaces
{
    [Cmdlet(VerbsCommon.Set, "Interface")]
    public class SetInterface : PSCmdlet
    {
        [Parameter(Mandatory = true)] public string Identity { get; set; }

        [Parameter] public InterfaceState State { get; set; } = InterfaceState.UNSPECIFIED;

        [Parameter] public string NewName { get; set; } = null;
        
        [Parameter] public int VlanId { get; set;} = -1;

        protected override void BeginProcessing()
        {
            var socket = SingletonRepository.getNetlinkSocket();
            var nic = socket.GetNetworkInterfaces().First(n => n.InterfaceName.ToLower() == Identity);
            if (nic == null)
                throw new Exception("An interface cannot be found which matches " + Identity);
            Console.WriteLine(nic.Index);
            Console.WriteLine(State);
            if (VlanId > 0)
            {
                socket.SetInterfaceVlanId(nic.Index, (ushort) VlanId);
            }

            if (State != InterfaceState.UNSPECIFIED)
            {
                socket.SetInterfaceState(nic.Index, State);
            }

            if (NewName != null)
            {
                socket.SetInterfaceName(nic.Index, NewName);
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