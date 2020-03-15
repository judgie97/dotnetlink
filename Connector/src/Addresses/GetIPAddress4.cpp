#include <netlink/socket.h>
#include <netlink/netlink.h>
#include <netlink/genl/genl.h>
#include <vector>
#include <linux/if_addr.h>
#include "../Netlink.hpp"

static int receiveAnAddress(struct nl_msg* msg, void* arg)
{
  std::vector<IPAddress4>* addresses = (std::vector<IPAddress4>*) arg;

  struct nlmsghdr* nlh = nlmsg_hdr(msg);
  struct ifaddrmsg* addressMessage = (struct ifaddrmsg*) NLMSG_DATA(nlh);

  IPAddress4 address;
  address.prefixLength = addressMessage->ifa_prefixlen;
  address.interface = addressMessage->ifa_index;

  struct rtattr* hdr = IFLA_RTA(addressMessage);
  int remaining = nlh->nlmsg_len - NLMSG_LENGTH(sizeof(*addressMessage));

  while(RTA_OK(hdr, remaining))
  {
    if(hdr->rta_type == IFA_LOCAL)
    {
      address.address = *(unsigned int*) RTA_DATA(hdr);
    }
    hdr = RTA_NEXT(hdr, remaining);
  }
  addresses->push_back(address);

  return NL_OK;
}

int requestAllAddresses(struct nl_sock* socket, unsigned char** storage)
{
  struct rtgenmsg rt_hdr = {.rtgen_family = AF_PACKET};

  int ret = nl_send_simple(socket, RTM_GETADDR, NLM_F_REQUEST | NLM_F_DUMP, &rt_hdr, sizeof(rt_hdr));

  //TODO test this return value. Should be 20

  std::vector<IPAddress4> addresses;

  nl_socket_modify_cb(socket, NL_CB_VALID, NL_CB_CUSTOM, receiveAnAddress, (void*) &addresses);
  nl_recvmsgs_default(socket);

  *storage = (unsigned char*) malloc(addresses.size() * sizeof(IPAddress4));
  memcpy(*storage, addresses.data(), addresses.size() * sizeof(IPAddress4));

  return addresses.size();
}