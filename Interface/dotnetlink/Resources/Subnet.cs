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

        private bool NetmaskBitValue(int bit)
        {
            return (netmask & 1u << bit) != 0;
        }

        public int NetmaskCIDR()
        {
            int i = 0;
            while (i < 32 && NetmaskBitValue(i))
            {
                i++;
            }
            return i;
        }

        public override string ToString()
        {
            return NetworkAddress + "/" + NetmaskCIDR();
        }
    }
}