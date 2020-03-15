#include <linux/netlink.h>
#include <sys/socket.h>
#include <netlink/route/addr.h>
#include "../Netlink.hpp"

int removeIPAddress(struct nl_sock* socket, IPAddress4* address)
{
  struct rtnl_addr* addr = rtnl_addr_alloc();
  rtnl_addr_set_ifindex(addr, address->interface);
  rtnl_addr_set_scope(addr, RT_SCOPE_UNIVERSE);

  struct nl_addr* nlAddr = nl_addr_build(AF_INET, &address->address, 4);
  nl_addr_set_prefixlen(nlAddr, address->prefixLength);
  rtnl_addr_set_local(addr, nlAddr);

  return rtnl_addr_delete(socket, addr, NLM_F_REQUEST | NLM_F_CREATE);
}