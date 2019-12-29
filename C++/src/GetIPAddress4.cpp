#include <linux/netlink.h>
#include <linux/if_addr.h>
#include <linux/rtnetlink.h>
#include <ctime>
#include <sys/socket.h>
#include <vector>
#include <malloc.h>
#include <cstring>

#include "Netlink.hpp"
#include "SocketOperations.hpp"
#include "TLVOperations.hpp"

int receiveAllAddresses(int sock, unsigned char** storage)
{
  struct sockaddr_nl nladdr;
  struct iovec iov;
  struct msghdr msg = {
    .msg_name = &nladdr,
    .msg_namelen = sizeof(nladdr),
    .msg_iov = &iov,
    .msg_iovlen = 1
  };

  iov.iov_base = 0;
  iov.iov_len = 0;

  int length = receiveMessage(sock, &msg, MSG_PEEK | MSG_TRUNC);
  if(length <= 0)
    return length;

  char* buffer = new char[length];
  iov.iov_len = length;
  iov.iov_base = buffer;

  length = receiveMessage(sock, &msg, 0);

  if(length < 0)
  {
    delete[] buffer;
    return UNABLE_TO_RECEIVE_FROM_NETLINK;
  }

  struct nlmsghdr* header = (struct nlmsghdr*) buffer;
  int remainingLength = length;

  std::vector<IPAddress4> addresses;

  while(NLMSG_OK(header, remainingLength))
  {
    if(header->nlmsg_flags & NLM_F_DUMP_INTR)
    {
      delete[] buffer;
      return NETLINK_DUMP_INTERUPTED;
    }
    if(header->nlmsg_type == NLMSG_ERROR)
    {
      delete[] buffer;
      return NETLINK_ERROR;
    }

    if(nladdr.nl_pid != 0)
    {
      header = NLMSG_NEXT(header, remainingLength);
      continue;
    }

    struct ifaddrmsg* addressMessage = (struct ifaddrmsg*) NLMSG_DATA(header);
    IPAddress4 address;
    address.prefixLength = addressMessage->ifa_prefixlen;
    address.interface = addressMessage->ifa_index;

    unsigned char* attributes = ((unsigned char*) header) + sizeof(nlmsghdr) + sizeof(ifaddrmsg);
    struct attribute
    {
      unsigned short length;
      unsigned short type;
      unsigned char value[];
    };
    unsigned int position = sizeof(nlmsghdr) + sizeof(ifaddrmsg);
    attribute* a = (attribute*) attributes;
    while(position < header->nlmsg_len)
    {
      if(a->type == IFA_LOCAL)
      {
        address.address = *(unsigned int*) a->value;
      }
      position += ALIGN_TLV(a->length);
      a = (attribute*) (((unsigned char*) a) + ALIGN_TLV(a->length));
    }
    addresses.push_back(address);
    header = NLMSG_NEXT(header, remainingLength);
  }

  *storage = (unsigned char*) malloc(addresses.size() * sizeof(IPAddress4));
  memcpy(*storage, addresses.data(), addresses.size() * sizeof(IPAddress4));
  flushSocket(sock);
  return addresses.size();
}

int requestAllAddresses(int sock, unsigned char** storage)
{
  struct
  {
    struct nlmsghdr nlh;
    struct ifaddrmsg addrmsg;
  } nl_request;

  nl_request.nlh.nlmsg_type = RTM_GETADDR;
  nl_request.nlh.nlmsg_flags = NLM_F_REQUEST | NLM_F_DUMP;
  nl_request.nlh.nlmsg_len = sizeof(nl_request);
  nl_request.nlh.nlmsg_seq = time(NULL);

  nl_request.addrmsg.ifa_family = AF_INET;
  nl_request.addrmsg.ifa_flags = 0;
  nl_request.addrmsg.ifa_prefixlen = 0;
  nl_request.addrmsg.ifa_scope = RT_SCOPE_UNIVERSE;
  nl_request.addrmsg.ifa_index = 0;

  send(sock, &nl_request, sizeof(nl_request), 0);

  return receiveAllAddresses(sock, storage);
}