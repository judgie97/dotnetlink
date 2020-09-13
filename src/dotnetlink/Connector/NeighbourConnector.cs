using libnl;

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public static unsafe partial class Connector
    {
        public static Neighbour[] GetArpCache(nl_sock* socket)
        {
            nl_cache* cache;
            LibNLRoute3.rtnl_neigh_alloc_cache(socket, &cache);
            
            int count = LibNL3.nl_cache_nitems(cache);
            if (count == 0)
                return null;

            Neighbour[] neighbours = new Neighbour[count];

            nl_object* current = LibNL3.nl_cache_get_first(cache);
            for (int i = 0; i < count; i++)
            {
                neighbours[i] = new Neighbour(current);
                current = LibNL3.nl_cache_get_next(current);
            }

            return neighbours;
        }
    }
}