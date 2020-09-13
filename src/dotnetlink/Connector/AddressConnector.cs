using System.Linq;
using libnl;

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public static unsafe partial class Connector
    {
        public static int AddIpAddress(nl_sock* socket, IpAddress ipAddress)
        {
            rtnl_addr* addr = LibNLRoute3.rtnl_addr_alloc();
            LibNLRoute3.rtnl_addr_set_ifindex(addr, ipAddress.Nic);
            LibNLRoute3.rtnl_addr_set_scope(addr, 0);

            nl_addr* nlAddr;
            byte[] addressBytes = ipAddress.Address.GetAddressBytes();
            fixed (byte* a = addressBytes)
            {
                nlAddr = LibNL3.nl_addr_build(ipAddress.Family, a, ipAddress.Size());
            }

            LibNL3.nl_addr_set_prefixlen(nlAddr, ipAddress.Netmask);
            LibNLRoute3.rtnl_addr_set_local(addr, nlAddr);

            return LibNLRoute3.rtnl_addr_add(socket, addr, NLMessageFlag.REQUEST | NLMessageFlag.ATOMIC);
        }

        public static int RemoveIpAddress(nl_sock* socket, IpAddress ipAddress)
        {
            rtnl_addr* addr = LibNLRoute3.rtnl_addr_alloc();
            LibNLRoute3.rtnl_addr_set_family(addr, ipAddress.Family);
            LibNLRoute3.rtnl_addr_set_ifindex(addr, ipAddress.Nic);
            LibNLRoute3.rtnl_addr_set_scope(addr, 0);

            nl_addr* nlAddr;
            byte[] addressBytes = ipAddress.Address.GetAddressBytes();
            fixed (byte* a = addressBytes)
            {
                nlAddr = LibNL3.nl_addr_build(ipAddress.Family, a, ipAddress.Size());
            }
            LibNL3.nl_addr_set_prefixlen(nlAddr, ipAddress.Netmask);
            LibNLRoute3.rtnl_addr_set_local(addr, nlAddr);

            return LibNLRoute3.rtnl_addr_delete(socket, addr, NLMessageFlag.REQUEST | NLMessageFlag.ATOMIC);
        }

        public static IpAddress[] RequestAllAddresses(nl_sock* socket)
        {
            nl_cache* cache;
            LibNLRoute3.rtnl_addr_alloc_cache(socket, &cache);
            //Check that the number of items is not 0
            int count = LibNL3.nl_cache_nitems(cache);
            if (count == 0)
                return null;

            IpAddress[] addresses = new IpAddress[count];

            nl_object* current = LibNL3.nl_cache_get_first(cache);
            for (int i = 0; i < count; i++)
            {
                addresses[i] = new IpAddress(current);
                current = LibNL3.nl_cache_get_next(current);
            }

            return addresses.Where(a => a.Address.GetAddressBytes().Length == 4).ToArray();
        }
    }
}