using System.Linq;
using System.Management.Automation;
using System.Net;
using dotnetlink;

namespace dotnetlinkps.IPConfiguration
{
    [Cmdlet(VerbsCommon.Remove, "IPConfiguration")]
    public class RemoveIpConfiguration : PSCmdlet
    {
        private NetlinkSocket _socket;

        [Parameter] public IPAddress Address { get; set; }
        [Parameter] public byte Netmask { get; set; }
        [Parameter] public string Interface { get; set; }

        protected override void BeginProcessing()
        {
            _socket = SingletonRepository.getNetlinkSocket();
            var nicIndex = _socket.GetNetworkInterfaces().First(i => i.InterfaceName.ToLower() == Interface.ToLower()).Index;
            _socket.RemoveIpAddress(new IpAddress(Address, Netmask, nicIndex));
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
