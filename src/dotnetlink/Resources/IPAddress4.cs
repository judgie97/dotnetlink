using System.Net;
using System.Runtime.InteropServices;
using libnl;

namespace dotnetlink
{
    public class IPAddress4
    {
        public IPAddress Address { get; set; }
        public byte netmask { get; set; }
        public int nic { get; set; }

        public IPAddress4(IPAddress address, byte netmask, int nic)
        {
            this.Address = address;
            this.netmask = netmask;
            this.nic = nic;
        }

        public unsafe IPAddress4(nl_object* address) : this((rtnl_addr*) address)
        {
        }

        public unsafe IPAddress4(rtnl_addr* address)
        {
            nl_addr* addr = LibNLRoute3.rtnl_addr_get_local(address);
            uint addressLength = LibNL3.nl_addr_get_len(addr);

            byte[] bytes = new byte[addressLength];
            for (uint i = 0; i < addressLength; i++)
            {
                bytes[i] = ((byte*)LibNL3.nl_addr_get_binary_addr(addr))[i];
            }
            this.Address = new IPAddress(bytes);
            this.netmask = (byte) LibNL3.nl_addr_get_prefixlen(addr);
            this.nic = LibNLRoute3.rtnl_addr_get_ifindex(address);
        }
    }
}