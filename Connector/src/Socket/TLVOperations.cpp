#include "TLVOperations.hpp"
#include <linux/rtnetlink.h>
#include <cstring>
#include "../Netlink.hpp"

int addTLVToMessage(struct nlmsghdr* n, int maxLength, int type, const void* data, int attributeLength)
{
  int len = RTA_LENGTH(attributeLength);
  struct rtattr* rta;

  int messageLength = NLMSG_ALIGN(n->nlmsg_len) + RTA_ALIGN(len);
  if(messageLength > maxLength)
  {
    return TLV_BREACHES_MESSAGE_LENGTH;
  }

  rta = ((struct rtattr*) (((unsigned char*) (n)) + NLMSG_ALIGN((n)->nlmsg_len)));
  rta->rta_type = type;
  rta->rta_len = len;

  if(attributeLength)
  {
    memcpy(RTA_DATA(rta), data, attributeLength);
  }

  n->nlmsg_len = NLMSG_ALIGN(n->nlmsg_len) + RTA_ALIGN(len);

  return 0;
}
