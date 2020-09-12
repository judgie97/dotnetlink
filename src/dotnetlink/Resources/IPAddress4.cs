using System.Net;
using libnl;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public class IpAddress4
    {
        public IPAddress Address { get; set; }
        public byte Netmask { get; set; }
        public int Nic { get; set; }

        public IpAddress4(IPAddress address, byte netmask, int nic)
        {
            this.Address = address;
            this.Netmask = netmask;
            this.Nic = nic;
        }

        public unsafe IpAddress4(nl_object* address) : this((rtnl_addr*) address)
        {
        }

        public unsafe IpAddress4(rtnl_addr* address)
        {
            nl_addr* addr = LibNLRoute3.rtnl_addr_get_local(address);
            uint addressLength = LibNL3.nl_addr_get_len(addr);

            byte[] bytes = new byte[addressLength];
            for (uint i = 0; i < addressLength; i++)
            {
                bytes[i] = ((byte*)LibNL3.nl_addr_get_binary_addr(addr))[i];
            }
            this.Address = new IPAddress(bytes);
            this.Netmask = (byte) LibNL3.nl_addr_get_prefixlen(addr);
            this.Nic = LibNLRoute3.rtnl_addr_get_ifindex(address);
        }
    }
}