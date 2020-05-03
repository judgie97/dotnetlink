using System;
using System.Net;

namespace dotnetlink
{
    public class Subnet
    {
        public IPAddress NetworkAddress { get; set; }
        public uint Netmask { get; set; }

        public Subnet(IPAddress networkAddress, uint netmask)
        {
            NetworkAddress = networkAddress;
            Netmask = netmask;
        }

        public Subnet(IPAddress networkAddress, byte CIDR)
        {
            NetworkAddress = networkAddress;
            Netmask = 0;
            for (byte i = 0; i < CIDR; i++)
            {
                Netmask |= (uint) 1 << i;
            }
        }

        private bool NetmaskBitValue(int bit)
        {
            return (Netmask & 1u << bit) != 0;
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