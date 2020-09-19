using System;
using System.Net;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable NonReadonlyMemberInGetHashCode

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

        public bool Contains(Subnet subnet)
        {
            if (NetmaskLength > subnet.NetmaskLength)
                return false;
            byte[] currentBytes = NetworkAddress.GetAddressBytes();
            byte[] otherBytes = subnet.NetworkAddress.GetAddressBytes();


            bool match = true;
            for (int i = 0; i < NetmaskLength; i++)
            {
                int group = i / 8;
                int bit = i % 8;
                int shift = 1 << 7 - bit;
                int x = currentBytes[group] & shift;
                int y = otherBytes[group] & shift;
                if (x != y)
                    match = false;
            }

            return match;
        }

        public override bool Equals(Object obj)
        {
            return Equals(obj as Subnet);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NetworkAddress, NetmaskLength);
        }

        protected bool Equals(Subnet other)
        {
            return NetworkAddress.Equals(other.NetworkAddress) && NetmaskLength == other.NetmaskLength;
        }
    }
}