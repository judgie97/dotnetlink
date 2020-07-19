using System;
using System.Linq;
using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps.Interfaces
{
    [Cmdlet(VerbsCommon.Add, "Interface")]
    public class AddInterface : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public String Name { get; set; }

        [Parameter] public int VlanId { get; set; } = -1;
        [Parameter] public String Parent { get; set; }


        protected override void BeginProcessing()
        {
            var socket = SingletonRepository.getNetlinkSocket();
            if (VlanId > 0 && Parent == null)
                throw new Exception("Parent interface must be specified when creating a Vlan interface");

            var parentInterface =
                socket.getNetworkInterfaces().First(i => i.interfaceName.ToLower() == Parent.ToLower());
            if (parentInterface == null)
                throw new Exception("Parent interface could not be found");
            var networkInterface = new NetworkInterface(parentInterface.index, Name, InterfaceType.BRIDGE,
                new VLAN((ushort) VlanId));
            socket.addNetworkInterface(networkInterface);
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