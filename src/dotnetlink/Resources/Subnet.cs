using System;
using System.Net;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public class Subnet
    {
        public IPAddress NetworkAddress { get; set; }
        public uint NetmaskLength { get; set; }

        public Subnet(String cidr)
        {
            String[] parts = cidr.Split('/');
            if(parts.Length != 2)
                throw new FormatException("Invalid cidr format");
            
            NetworkAddress = IPAddress.Parse(parts[0]);

            NetmaskLength = UInt32.Parse(parts[1]);
        }

        public Subnet(IPAddress networkAddress, byte cidr)
        {
            NetworkAddress = networkAddress;
            NetmaskLength = cidr;
        }

        private bool NetmaskBitValue(int bit)
        {
            return bit < NetmaskLength;
        }

        public override string ToString()
        {
            return NetworkAddress + "/" + NetmaskLength;
        }
    }
}