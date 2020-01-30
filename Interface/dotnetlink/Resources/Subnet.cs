using System.Net;

namespace dotnetlink
{
    public class Subnet
    {
        public IPAddress NetworkAddress;
        public uint netmask;

        public Subnet(IPAddress ipAddress, uint netmask)
        {
            this.NetworkAddress = ipAddress;
            this.netmask = netmask;
        }
    }
}