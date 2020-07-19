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
        private IPAddress4[] _addresses;
        private NetworkInterface[] _interfaces;

        protected override void BeginProcessing()
        {
            var socket = SingletonRepository.getNetlinkSocket();
            _addresses = socket.getAddresses();
            _interfaces = socket.getNetworkInterfaces();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }

        private void WriteIPConfiguration(IPAddress4 ipAddress4, NetworkInterface networkInterface)
        {
            var interfaceDto = InterfaceDtoUtil.ConvertToDto(networkInterface.index, _interfaces);

            var ipConfigurationDto = new IpConfigurationDto
            {
                Address =  ipAddress4.Address,
                SubnetMask = ipAddress4.netmask,
                Interface =  interfaceDto
            };
            WriteObject(ipConfigurationDto);
        }

        protected override void EndProcessing()
        {
            foreach (var address in _addresses)
            {
                WriteIPConfiguration(address, _interfaces.First(i => i.index == address.nic));
            }
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}