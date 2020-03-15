#include <netlink/socket.h>
#include <netlink/netlink.h>
#include <netlink/route/link.h>
#include <netlink/route/link/vlan.h>
#include "../Netlink.hpp"

int addInterface(struct nl_sock* socket, NetworkInterface* interface)
{
  struct rtnl_link* nlLink = rtnl_link_vlan_alloc();
  rtnl_link_set_link(nlLink, interface->parentInterface);
  rtnl_link_set_name(nlLink, interface->interfaceName);

  if(interface->interfaceType == DNL_IFT_DOT1Q)
  {
    rtnl_link_set_type(nlLink, "vlan");
    rtnl_link_vlan_set_id(nlLink, interface->vlanData.vlanID);
  }

  return rtnl_link_add(socket, nlLink, NLM_F_REQUEST | NLM_F_CREATE);
}