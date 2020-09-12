using System.Linq;
using libnl;

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public static unsafe partial class Connector
    {
        public static int AddIpAddress(nl_sock* socket, IpAddress4 ipAddress4)
        {
            rtnl_addr* addr = LibNLRoute3.rtnl_addr_alloc();
            LibNLRoute3.rtnl_addr_set_ifindex(addr, ipAddress4.Nic);
            LibNLRoute3.rtnl_addr_set_scope(addr, 0);

            uint address = Util.Ip4ToUnsignedInt(ipAddress4.Address);
            nl_addr* nlAddr = LibNL3.nl_addr_build(AddressFamily.INET, &address, 4);
            LibNL3.nl_addr_set_prefixlen(nlAddr, ipAddress4.Netmask);
            LibNLRoute3.rtnl_addr_set_local(addr, nlAddr);

            return LibNLRoute3.rtnl_addr_add(socket, addr, NLMessageFlag.REQUEST | NLMessageFlag.ATOMIC);
        }

        public static int RemoveIpAddress(nl_sock* socket, IpAddress4 ipAddress4)
        {
            rtnl_addr* addr = LibNLRoute3.rtnl_addr_alloc();
            LibNLRoute3.rtnl_addr_set_family(addr, AddressFamily.INET);
            LibNLRoute3.rtnl_addr_set_ifindex(addr, ipAddress4.Nic);
            LibNLRoute3.rtnl_addr_set_scope(addr, 0);

            uint address = Util.Ip4ToUnsignedInt(ipAddress4.Address);
            nl_addr* nlAddr = LibNL3.nl_addr_build(AddressFamily.INET, &address, 4);
            LibNL3.nl_addr_set_prefixlen(nlAddr, ipAddress4.Netmask);
            LibNLRoute3.rtnl_addr_set_local(addr, nlAddr);

            return LibNLRoute3.rtnl_addr_delete(socket, addr, NLMessageFlag.REQUEST | NLMessageFlag.ATOMIC);
        }

        public static IpAddress4[] RequestAllAddresses(nl_sock* socket)
        {
            nl_cache* cache;
            LibNLRoute3.rtnl_addr_alloc_cache(socket, &cache);
            //Check that the number of items is not 0
            int count = LibNL3.nl_cache_nitems(cache);
            if (count == 0)
                return null;

            IpAddress4[] addresses = new IpAddress4[count];

            nl_object* current = LibNL3.nl_cache_get_first(cache);
            for (int i = 0; i < count; i++)
            {
                addresses[i] = new IpAddress4(current);
                current = LibNL3.nl_cache_get_next(current);
            }

            return addresses.Where(a => a.Address.GetAddressBytes().Length == 4).ToArray();
        }
    }
}