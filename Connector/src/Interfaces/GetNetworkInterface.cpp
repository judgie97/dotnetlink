#include <netlink/socket.h>
#include <netlink/netlink.h>
#include <netlink/genl/genl.h>
#include <vector>
#include <net/if.h>
#include "../Netlink.hpp"

static int receiveAnInterface(struct nl_msg* msg, void* arg)
{
  std::vector<NetworkInterface>* interfaces = (std::vector<NetworkInterface>*) arg;

  struct nlmsghdr* nlh = nlmsg_hdr(msg);
  struct ifinfomsg* iface = (struct ifinfomsg*) NLMSG_DATA(nlh);

  NetworkInterface interface;
  interface.index = iface->ifi_index;
  interface.isBroadcastInterface = iface->ifi_flags & IFF_BROADCAST;
  interface.isLoopbackInterface = iface->ifi_flags & IFF_LOOPBACK;
  interface.isPointToPointInterface = iface->ifi_flags & IFF_POINTOPOINT;
  interface.isUp = iface->ifi_flags & IFF_UP;
  interface.isNBMAInterface = !(interface.isBroadcastInterface || interface.isLoopbackInterface ||
                                interface.isPointToPointInterface);
  interface.isPromiscuousInterface = iface->ifi_flags & IFF_PROMISC;
  interface.parentInterface = 0;
  interface.interfaceType = DNL_IFT_LOOPBACK;
  memset(interface.interfaceName, 0, 21);


  struct rtattr* hdr = IFLA_RTA(iface);
  int remaining = nlh->nlmsg_len - NLMSG_LENGTH(sizeof(*iface));

  while(RTA_OK(hdr, remaining))
  {
    if(hdr->rta_type == IFLA_ADDRESS)
    {
      memcpy(interface.hardwareAddress, RTA_DATA(hdr), 6);
    }
    if(hdr->rta_type == IFLA_IFNAME)
    {
      int nameLength = hdr->rta_len - 4;
      memcpy(interface.interfaceName, RTA_DATA(hdr), nameLength < 21 ? nameLength : 20);
    }
    if(hdr->rta_type == IFLA_LINK)
    {
      interface.parentInterface = *(unsigned int*) RTA_DATA(hdr);
    }

    if(hdr->rta_type == IFLA_LINKINFO)
    {
      rtattr* b = (rtattr*) RTA_DATA(hdr);

      unsigned int count = 4;
      while(count < hdr->rta_len)
      {
        if(b->rta_type == IFLA_INFO_KIND)
        {
          if(strncmp((char*) RTA_DATA(b), "vlan", b->rta_len - 4) == 0)
            interface.interfaceType = DNL_IFT_DOT1Q;
        }
        if(b->rta_type == IFLA_INFO_DATA)
        {
          if(interface.interfaceType == DNL_IFT_DOT1Q)
          {
            interface.vlanData.vlanID = ((unsigned int*) RTA_DATA(b))[3];
          }
        }
        count += RTA_ALIGN(b->rta_len);
        b = (rtattr*) (((unsigned char*) b) + RTA_ALIGN(b->rta_len));
      }
    }
    hdr = RTA_NEXT(hdr, remaining);
  }

  interfaces->push_back(interface);

  return NL_OK;

}

int requestAllNetworkInterfaces(struct nl_sock* socket, unsigned char** storage)
{
  struct rtgenmsg rt_hdr = {.rtgen_family = AF_PACKET};

  int ret = nl_send_simple(socket, RTM_GETLINK, NLM_F_REQUEST | NLM_F_DUMP, &rt_hdr, sizeof(rt_hdr));

  //TODO test this return value. Should be 20

  std::vector<NetworkInterface> interfaces;

  nl_socket_modify_cb(socket, NL_CB_VALID, NL_CB_CUSTOM, receiveAnInterface, (void*) &interfaces);
  nl_recvmsgs_default(socket);

  *storage = (unsigned char*) malloc(interfaces.size() * sizeof(NetworkInterface));
  memcpy(*storage, interfaces.data(), interfaces.size() * sizeof(NetworkInterface));

  return interfaces.size();
}