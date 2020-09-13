using System.Net;
using libnl;
using AddressFamily = System.Net.Sockets.AddressFamily;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public class IpAddress
    {
        public IPAddress Address { get; set; }
        public byte Netmask { get; set; }
        public int Nic { get; set; }

        public int Family { get; set; }

        public uint Size()
        {
            return (uint) (Family == libnl.AddressFamily.INET ? 4 : 16);
        }

        public IpAddress(IPAddress address, byte netmask, int nic)
        {
            Address = address;
            Netmask = netmask;
            Nic = nic;
            Family = address.AddressFamily == AddressFamily.InterNetwork
                ? libnl.AddressFamily.INET
                : libnl.AddressFamily.INET6;
        }

        public unsafe IpAddress(nl_object* address) : this((rtnl_addr*) address)
        {
        }

        public unsafe IpAddress(rtnl_addr* address)
        {
            nl_addr* addr = LibNLRoute3.rtnl_addr_get_local(address);
            uint addressLength = LibNL3.nl_addr_get_len(addr);

            byte[] bytes = new byte[addressLength];
            for (uint i = 0; i < addressLength; i++)
            {
                bytes[i] = ((byte*) LibNL3.nl_addr_get_binary_addr(addr))[i];
            }

            Address = new IPAddress(bytes);
            Netmask = (byte) LibNL3.nl_addr_get_prefixlen(addr);
            Nic = LibNLRoute3.rtnl_addr_get_ifindex(address);
        }
    }
}