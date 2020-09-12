using System;
using libnl;
// ReSharper disable MemberCanBePrivate.Global

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public static unsafe partial class Connector
    {
        public static InterfaceStatistics GetInterfaceStatistics(nl_sock* socket, int interfaceIndex)
        {
            nl_cache* cache;
            LibNLRoute3.rtnl_link_alloc_cache(socket, AddressFamily.INET, &cache);
            //Check that the number of items is not 0
            int count = LibNL3.nl_cache_nitems(cache);
            if (count == 0)
                return null;
            rtnl_link* link = LibNLRoute3.rtnl_link_get(cache, interfaceIndex);
            rtnl_link_stat_id_t[] values = (rtnl_link_stat_id_t[]) Enum.GetValues(typeof(rtnl_link_stat_id_t));

            ulong[] statistics = new ulong[values.Length - 1];
            for (int i = 0; i < values.Length - 1; i++)
            {
                statistics[i] = LibNLRoute3.rtnl_link_get_stat(link, values[i]);
            }
            return new InterfaceStatistics(statistics);
        }
    }
}