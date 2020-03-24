using System.Net;
using System.Runtime.InteropServices;
using libnl;

namespace dotnetlink
{
    public class IPAddress4
    {
        public IPAddress address;
        public byte netmask;
        public int nic;

        public IPAddress4(IPAddress address, byte netmask, int nic)
        {
            this.address = address;
            this.netmask = netmask;
            this.nic = nic;
        }

        public unsafe IPAddress4(nl_object* address) : this((rtnl_addr*) address)
        {
        }

        public unsafe IPAddress4(rtnl_addr* address)
        {
            nl_addr* addr = LibNLRoute3.rtnl_addr_get_local(address);
            this.address = new IPAddress(*(uint*)LibNL3.nl_addr_get_binary_addr(addr));
            this.netmask = (byte) LibNL3.nl_addr_get_prefixlen(addr);
            this.nic = LibNLRoute3.rtnl_addr_get_ifindex(address);
        }
    }
}