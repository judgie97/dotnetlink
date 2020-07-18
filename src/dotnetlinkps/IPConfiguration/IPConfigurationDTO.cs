using System.Net;
using dotnetlinkps.Interfaces;

namespace dotnetlinkps.IPConfiguration
{
    public class IpConfigurationDto
    {
        public IPAddress Address { get; set; }
        public byte SubnetMask { get; set; }
        public InterfaceDto Interface { get; set; }

        public override string ToString()
        {
            return Address + "/" + SubnetMask;
        }
    }
}