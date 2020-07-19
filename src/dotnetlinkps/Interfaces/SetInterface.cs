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
            var nic = socket.getNetworkInterfaces().First(n => n.interfaceName.ToLower() == Identity);
            if (nic == null)
                throw new Exception("An interface cannot be found which matches " + Identity);
            Console.WriteLine(nic.index);
            Console.WriteLine(State);
            if (VlanId > 0)
            {
                socket.setInterfaceVlanID(nic.index, (ushort) VlanId);
            }

            if (State != InterfaceState.UNSPECIFIED)
            {
                socket.setInterfaceState(nic.index, State);
            }

            if (NewName != null)
            {
                socket.setInterfaceName(nic.index, NewName);
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