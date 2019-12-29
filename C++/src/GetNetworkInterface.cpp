#include <linux/netlink.h>
#include <linux/if_link.h>
#include <linux/rtnetlink.h>
#include <ctime>
#include <sys/socket.h>
#include <vector>
#include <malloc.h>
#include <cstring>
#include <net/if.h>
#include <iostream>

#include "Netlink.hpp"
#include "SocketOperations.hpp"
#include "TLVOperations.hpp"


int receiveSomeNetworkInterfaces(int sock, std::vector<NetworkInterface> &interfaces)
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

  int length = receiveMessage(sock, &msg, MSG_PEEK | MSG_TRUNC | MSG_DONTWAIT);

  if(length <= 0)
    return length;

  char* buffer = new char[length];


  iov.iov_len = length;
  iov.iov_base = buffer;

  length = receiveMessage(sock, &msg, 0);

  if(length <= 0)
  {
    delete[] buffer;
    return UNABLE_TO_RECEIVE_FROM_NETLINK;
  }

  struct nlmsghdr* header = (struct nlmsghdr*) buffer;
  int remainingLength = length;
  int count = 0;
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
    if(header->nlmsg_type == NLMSG_DONE)
      return count;

    if(nladdr.nl_pid != 0)
    {
      header = NLMSG_NEXT(header, remainingLength);
      continue;
    }

    struct ifinfomsg* infoMessage = (struct ifinfomsg*) NLMSG_DATA(header);
    NetworkInterface interface;
    interface.index = infoMessage->ifi_index;
    interface.isBroadcastInterface = infoMessage->ifi_flags & IFF_BROADCAST;
    interface.isLoopbackInterface = infoMessage->ifi_flags & IFF_LOOPBACK;
    interface.isPointToPointInterface = infoMessage->ifi_flags & IFF_POINTOPOINT;
    interface.isNBMAInterface = !(interface.isBroadcastInterface || interface.isLoopbackInterface ||
                                  interface.isPointToPointInterface);
    interface.isPromiscuousInterface = infoMessage->ifi_flags & IFF_PROMISC;


    unsigned char* attributes = ((unsigned char*) header) + sizeof(nlmsghdr) + sizeof(ifinfomsg);
    struct attribute
    {
      unsigned short length;
      unsigned short type;
      unsigned char value[];
    };
    unsigned int position = sizeof(nlmsghdr) + sizeof(ifinfomsg);
    attribute* a = (attribute*) attributes;
    while(position < header->nlmsg_len)
    {
      if(a->type == IFLA_ADDRESS)
      {
        memcpy(interface.hardwareAddress, a->value, 6);
      }
      if(a->type == IFLA_OPERSTATE)
      {
        interface.isUp = a->value[0];
      }
      position += ALIGN_TLV(a->length);
      a = (attribute*) (((unsigned char*) a) + ALIGN_TLV(a->length));
    }
    if(interface.index > 0)
    {
      interfaces.push_back(interface);
      count++;
    }
    header = NLMSG_NEXT(header, remainingLength);
  }

  return count;
}

int receiveAllNetworkInterfaces(int sock, unsigned char** storage)
{
  std::vector<NetworkInterface> interfaces;

  int status;
  do
  {
    status = receiveSomeNetworkInterfaces(sock, interfaces);
  } while(status > 0);

  *storage = (unsigned char*) malloc(interfaces.size() * sizeof(NetworkInterface));
  memcpy(*storage, interfaces.data(), interfaces.size() * sizeof(NetworkInterface));
  flushSocket(sock);
  return interfaces.size();
}

int requestAllNetworkInterfaces(int sock, unsigned char** storage)
{
  struct
  {
    struct nlmsghdr nlh;
    struct ifinfomsg infomsg;
  } nl_request;

  nl_request.nlh.nlmsg_type = RTM_GETLINK;
  nl_request.nlh.nlmsg_flags = NLM_F_REQUEST | NLM_F_DUMP;
  nl_request.nlh.nlmsg_len = sizeof(nl_request);
  nl_request.nlh.nlmsg_seq = time(NULL);

  nl_request.infomsg.ifi_family = AF_UNSPEC;
  nl_request.infomsg.__ifi_pad = 0;
  nl_request.infomsg.ifi_type = 0;
  nl_request.infomsg.ifi_index = 0;
  nl_request.infomsg.ifi_flags = 0;
  nl_request.infomsg.ifi_change = 0xFFFFFFFF;
  send(sock, &nl_request, sizeof(nl_request), 0);

  return receiveAllNetworkInterfaces(sock, storage);
}