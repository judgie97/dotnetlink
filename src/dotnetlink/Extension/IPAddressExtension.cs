using System.Net;
using System.Net.Sockets;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace dotnetlink.Extension
{
    // ReSharper disable once InconsistentNaming
    public static class IPAddressExtension
    {
        public static bool IsIpv4Address(this IPAddress address)
        {
            return address.AddressFamily == AddressFamily.InterNetwork;
        }
        
        public static bool IsIpv6Address(this IPAddress address)
        {
            return address.AddressFamily == AddressFamily.InterNetworkV6;
        }

        public static bool IsIpv4ClassA(this IPAddress address)
        {
            if (!address.IsIpv4Address()) 
                return false;
            var addressByte = address.GetAddressBytes()[0];
            return addressByte < 128;
        }

        public static bool IsIpv4ClassB(this IPAddress address)
        {
            if (!address.IsIpv4Address()) 
                return false;
            var addressByte = address.GetAddressBytes()[0];
            return 128 <= addressByte && addressByte < 192;
        }

        public static bool IsIpv4ClassC(this IPAddress address)
        {
            if (!address.IsIpv4Address()) 
                return false;
            var addressByte = address.GetAddressBytes()[0];
            return 192 <= addressByte && addressByte < 224;
        }

        public static bool IsIpv4ClassD(this IPAddress address)
        {
            if (!address.IsIpv4Address()) 
                return false;
            var addressByte = address.GetAddressBytes()[0];
            return 224 <= addressByte && addressByte < 240;
        }

        public static bool IsIpv4ClassE(this IPAddress address)
        {
            if (!address.IsIpv4Address()) 
                return false;
            var addressByte = address.GetAddressBytes()[0];
            return 240 <= addressByte;
        }
    }
}