using System;
using System.Net;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable UnusedMember.Global

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public class Subnet
    {
        public IPAddress NetworkAddress { get; set; }
        public uint Netmask { get; set; }

        public Subnet(String cidr)
        {
            String[] parts = cidr.Split('/');
            if(parts.Length != 2)
                throw new FormatException("Invalid cidr format");
            
            NetworkAddress = IPAddress.Parse(parts[0]);

            Netmask = UInt32.Parse(parts[1]);
        }

        public Subnet(IPAddress networkAddress, uint netmask)
        {
            NetworkAddress = networkAddress;
            Netmask = netmask;
        }

        public Subnet(IPAddress networkAddress, byte cidr)
        {
            NetworkAddress = networkAddress;
            Netmask = 0;
            for (byte i = 0; i < cidr; i++)
            {
                Netmask |= (uint) 1 << i;
            }
        }

        private bool NetmaskBitValue(int bit)
        {
            return (Netmask & 1u << bit) != 0;
        }

        public int NetmaskCidr()
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
            return NetworkAddress + "/" + NetmaskCidr();
        }
    }
}