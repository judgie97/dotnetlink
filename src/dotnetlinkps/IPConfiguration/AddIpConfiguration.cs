using System.Linq;
using System.Management.Automation;
using System.Net;
using dotnetlink;

namespace dotnetlinkps.IPConfiguration
{
    [Cmdlet(VerbsCommon.Add, "IPConfiguration")]
    public class AddIpConfiguration : PSCmdlet
    {
        private NetlinkSocket socket;

        [Parameter] public IPAddress Address { get; set; }

        [Parameter] public byte Netmask { get; set; }

        [Parameter] public string Interface { get; set; }

        protected override void BeginProcessing()
        {
            socket = SingletonRepository.getNetlinkSocket();
            var interfaceIndex = socket.GetNetworkInterfaces()
                .First(i => i.InterfaceName.ToLower() == Interface.ToLower()).Index;
            socket.AddIpAddress(new IpAddress(Address, Netmask, interfaceIndex));
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