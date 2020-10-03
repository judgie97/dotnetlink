using System;
using libnl;

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public static unsafe partial class Connector
    {
        public static int AddInterface(nl_sock* socket, NetworkInterface networkInterface)
        {
            rtnl_link* nlLink = LibNLRoute3.rtnl_link_vlan_alloc();
            LibNLRoute3.rtnl_link_set_link(nlLink, networkInterface.ParentInterfaceIndex);
            var nameBytes = Util.StringToNativeBytes(networkInterface.InterfaceName);
            fixed (byte* name = nameBytes)
            {
                LibNLRoute3.rtnl_link_set_name(nlLink, (char*) name);
            }

            if (networkInterface.InterfaceType == InterfaceType.VLAN)
                LibNLRoute3.rtnl_link_vlan_set_id(nlLink, ((Vlan) (networkInterface.InterfaceInformation)).VlanId);

            if (networkInterface.MaximumTransmissionUnit != 0)
                LibNLRoute3.rtnl_link_set_mtu(nlLink, networkInterface.MaximumTransmissionUnit);

            return LibNLRoute3.rtnl_link_add(socket, nlLink, NLMessageFlag.REQUEST | NLMessageFlag.ATOMIC);
        }

        public static int RemoveInterface(nl_sock* socket, NetworkInterface networkInterface)
        {
            rtnl_link* nlLink = LibNLRoute3.rtnl_link_vlan_alloc();
            LibNLRoute3.rtnl_link_set_ifindex(nlLink, networkInterface.Index);
            LibNLRoute3.rtnl_link_set_link(nlLink, networkInterface.ParentInterfaceIndex);
            fixed (char* name = networkInterface.InterfaceName)
            {
                LibNLRoute3.rtnl_link_set_name(nlLink, name);
            }

            if (networkInterface.InterfaceType == InterfaceType.VLAN)
            {
                LibNLRoute3.rtnl_link_vlan_set_id(nlLink, ((Vlan) (networkInterface.InterfaceInformation)).VlanId);
            }

            return LibNLRoute3.rtnl_link_delete(socket, nlLink);
        }

        public static int SetNetworkInterfaceState(nl_sock* socket, int index, bool up)
        {
            nl_cache* cache;
            int x;
            if ((x = LibNLRoute3.rtnl_link_alloc_cache(socket, AddressFamily.INET, &cache)) < 0)
                throw new NetlinkSocketException(x);
            rtnl_link* original = LibNLRoute3.rtnl_link_get(cache, index);

            rtnl_link* changed = (rtnl_link*) LibNL3.nl_object_clone((nl_object*) original);
            if (up)
            {
                LibNLRoute3.rtnl_link_set_flags(changed, NLInterfaceFlags.UP);
            }
            else
            {
                LibNLRoute3.rtnl_link_unset_flags(changed, NLInterfaceFlags.UP);
            }

            int r = LibNLRoute3.rtnl_link_change(socket, original, changed, NLMessageFlag.REQUEST);
            return r == -10 ? 0 : r;
        }

        public static int SetNetworkInterfaceName(nl_sock* socket, int networkInterfaceIndex, string name)
        {
            nl_cache* cache;
            int x;
            if ((x = LibNLRoute3.rtnl_link_alloc_cache(socket, AddressFamily.INET, &cache)) < 0)
                throw new NetlinkSocketException(x);
            rtnl_link* original = LibNLRoute3.rtnl_link_get(cache, networkInterfaceIndex);

            rtnl_link* changed = (rtnl_link*) LibNL3.nl_object_clone((nl_object*) original);
            var bytes = Util.StringToNativeBytes(name);

            fixed (byte* n = bytes)
                LibNLRoute3.rtnl_link_set_name(changed, (char*) n);

            int r = LibNLRoute3.rtnl_link_change(socket, original, changed, NLMessageFlag.REQUEST);
            return r == -10 ? 0 : r;
        }

        public static int SetNetworkInterfaceMaximumTransmissionUnit(nl_sock* socket, int networkInterfaceIndex,
            uint mtu)
        {
            nl_cache* cache;
            int x;
            if ((x = LibNLRoute3.rtnl_link_alloc_cache(socket, AddressFamily.INET, &cache)) < 0)
                throw new NetlinkSocketException(x);
            rtnl_link* original = LibNLRoute3.rtnl_link_get(cache, networkInterfaceIndex);

            rtnl_link* changed = (rtnl_link*) LibNL3.nl_object_clone((nl_object*) original);
            LibNLRoute3.rtnl_link_set_mtu(changed, mtu);

            int r = LibNLRoute3.rtnl_link_change(socket, original, changed, NLMessageFlag.REQUEST);
            return r == -10 ? 0 : r;
        }

        public static NetworkInterface[] RequestAllNetworkInterfaces(nl_sock* socket)
        {
            nl_cache* cache;
            int x;
            if ((x = LibNLRoute3.rtnl_link_alloc_cache(socket, AddressFamily.INET, &cache)) < 0)
                throw new NetlinkSocketException(x);
            //Check that the number of items is not 0
            int count = LibNL3.nl_cache_nitems(cache);
            if (count == 0)
                return null;

            NetworkInterface[] interfaces = new NetworkInterface[count];

            nl_object* current = LibNL3.nl_cache_get_first(cache);
            for (int i = 0; i < count; i++)
            {
                interfaces[i] = new NetworkInterface(current);
                current = LibNL3.nl_cache_get_next(current);
            }

            return interfaces;
        }

        public static NetworkInterface RequestInterface(nl_sock* socket, String name)
        {
            nl_cache* cache;
            int x;
            if ((x = LibNLRoute3.rtnl_link_alloc_cache(socket, AddressFamily.INET, &cache)) < 0)
                throw new NetlinkSocketException(x);
            //Check that the number of items is not 0
            int count = LibNL3.nl_cache_nitems(cache);
            if (count == 0)
                return null;


            byte[] nameBytes = Util.StringToNativeBytes(name);
            int index;
            fixed (byte* n = nameBytes)
            {
                index = LibNLRoute3.rtnl_link_name2i(cache, n);
            }

            NetworkInterface networkInterface = new NetworkInterface(LibNLRoute3.rtnl_link_get(cache, index));

            return networkInterface;
        }

        public static int SetInterfaceVlanId(nl_sock* socket, int nicIndex, ushort vlanId)
        {
            nl_cache* cache;
            int x;
            if ((x = LibNLRoute3.rtnl_link_alloc_cache(socket, AddressFamily.INET, &cache)) < 0)
                throw new NetlinkSocketException(x);
            rtnl_link* original = LibNLRoute3.rtnl_link_get(cache, nicIndex);

            rtnl_link* changed = (rtnl_link*) LibNL3.nl_object_clone((nl_object*) original);

            LibNLRoute3.rtnl_link_vlan_set_id(changed, vlanId);

            int r = LibNLRoute3.rtnl_link_change(socket, original, changed, NLMessageFlag.REQUEST);
            return r == -10 ? 0 : r;
        }
    }
}