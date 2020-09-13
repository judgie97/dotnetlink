using System.Linq;
using System.Management.Automation;
using dotnetlink;
using dotnetlinkps.Interfaces;

namespace dotnetlinkps.IPConfiguration
{
    [Cmdlet(VerbsCommon.Get, "IPConfiguration")]
    [OutputType(typeof(IpConfigurationDto))]
    public class GetIpConfiguration : PSCmdlet
    {
        private IpAddress[] _addresses;
        private NetworkInterface[] _interfaces;

        protected override void BeginProcessing()
        {
            var socket = SingletonRepository.getNetlinkSocket();
            _addresses = socket.GetAddresses();
            _interfaces = socket.GetNetworkInterfaces();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }

        private void WriteIPConfiguration(IpAddress ipAddress, NetworkInterface networkInterface)
        {
            var interfaceDto = InterfaceDtoUtil.ConvertToDto(networkInterface.Index, _interfaces);

            var ipConfigurationDto = new IpConfigurationDto
            {
                Address =  ipAddress.Address,
                SubnetMask = ipAddress.Netmask,
                Interface =  interfaceDto
            };
            WriteObject(ipConfigurationDto);
        }

        protected override void EndProcessing()
        {
            foreach (var address in _addresses)
            {
                WriteIPConfiguration(address, _interfaces.First(i => i.Index == address.Nic));
            }
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}