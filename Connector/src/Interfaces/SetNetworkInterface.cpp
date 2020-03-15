#include <netlink/route/link/vlan.h>
#include <net/if.h>
#include <iostream>
#include "../Netlink.hpp"

int setNetworkInterface(struct nl_sock* socket, unsigned int interfaceIndex, bool up)
{

  struct nl_cache* cache;
  rtnl_link_alloc_cache(socket, AF_INET, &cache);
  struct rtnl_link* original = rtnl_link_get(cache, interfaceIndex);

  struct rtnl_link* changed = (struct rtnl_link*) nl_object_clone((nl_object*) original);
  if(up)
  {
    rtnl_link_set_flags(changed, IFF_UP);
  }
  else
  {
    rtnl_link_unset_flags(changed, IFF_UP);
  }

  return rtnl_link_change(socket, original, changed, NLM_F_REQUEST);
}
