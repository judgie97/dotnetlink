#define __KERNEL__
#define __MODULE__

#include "Communication.h"
#include "FilterTable.h"

#include <linux/module.h>
#include <linux/kernel.h>
#include <linux/init.h>
#include <linux/netlink.h>
#include <linux/netfilter.h>
#include <linux/socket.h>
#include <linux/skbuff.h>


#define REQUIRE_CAPABILITIES

//if REQUIRE_CAPABILITIES is defined the module will require that the remote netlink process has the CAP_NET_ADMIN
//capability to perform certain tasks.
#ifndef REQUIRE_CAPABILITIES
#define CAP_NET_ADMIN_CHECK true
#else
#define CAP_NET_ADMIN_CHECK netlink_net_capable(skb, CAP_NET_ADMIN)
#endif

struct sock* nlsocket = 0;
int sequence = 1;

void sendDataToUserSpace(unsigned char* buffer, int dataLength, short messageType, int pid)
{
  int nlmsgLength = dataLength + sizeof(struct nlmsghdr);
  struct sk_buff* skb = alloc_skb(nlmsgLength, GFP_ATOMIC);
  skb_put(skb, nlmsgLength);

  if(skb != 0)
  {
    struct nlmsghdr* nlm = (struct nlmsghdr*) skb->data;

    nlm->nlmsg_len = nlmsgLength;
    nlm->nlmsg_type = messageType;
    nlm->nlmsg_pid = 0;
    nlm->nlmsg_seq = sequence++;
    nlm->nlmsg_flags = 0;

    if(dataLength > 0)
      memmove(NLMSG_DATA(nlm), buffer, dataLength);
    NETLINK_CB(skb).portid = pid;
    NETLINK_CB(skb).dst_group = 0;

    netlink_unicast(nlsocket, skb, pid, MSG_DONTWAIT);
  }
}

void acceptUserMessage(struct sk_buff* skb)
{
  unsigned char* data;
  int dataLength;
  struct nlmsghdr* nlm;
  int pid;
  int type;


  if(!skb)
    return;
  nlm = (struct nlmsghdr*) skb->data;
  pid = nlm->nlmsg_pid;
  type = nlm->nlmsg_type;

  data = NLMSG_DATA(nlm);
  dataLength = nlm->nlmsg_len - 16;

  if(type == DNF_GETRULE)
  {
    struct DotNetFilterRule* storage;
    int dataLength = getRules(&storage) * sizeof(struct DotNetFilterRule);
    sendDataToUserSpace((unsigned char*)storage, dataLength, DNF_GETRULE, pid);
  }

  if(type == DNF_ADDRULE)
  {
    if(CAP_NET_ADMIN_CHECK)
    {
      unsigned int ruleID = addRule((struct DotNetFilterRule*) data);
      sendDataToUserSpace((unsigned char*) &ruleID, sizeof(unsigned int), DNF_ADDRULE, pid);
    }
    else
    {
      unsigned int ruleID = 0;
      printk(KERN_WARNING "dotnetlink > Unauthorised add rule request\n");
      sendDataToUserSpace((unsigned char*) &ruleID, sizeof(unsigned int), DNF_ADDRULE, pid);
    }
  }

  if(type == DNF_DELRULE)
  {
    if(CAP_NET_ADMIN_CHECK)
    {
      if(nlm->nlmsg_len < sizeof(struct nlmsghdr) + sizeof(unsigned int))
      {
        unsigned int status = 0;
        sendDataToUserSpace((unsigned char*) &status, sizeof(unsigned int), DNF_DELRULE, pid);
      }
      else
      {
        unsigned int status = delRule(*(unsigned int*)NLMSG_DATA(nlm));
        sendDataToUserSpace((unsigned char*) &status, sizeof(unsigned int), DNF_DELRULE, pid);
      }
    }
    else
    {
      unsigned int status = 0;
      printk(KERN_WARNING "dotnetlink > Unauthorised delete rule request\n");
      sendDataToUserSpace((unsigned char*) &status, sizeof(unsigned int), DNF_DELRULE, pid);
    }
  }
}

void setupListener(void)
{
  struct netlink_kernel_cfg cfg = {
    .input = acceptUserMessage
  };

  nlsocket = netlink_kernel_create(&init_net, NETLINK_DOTNETFILTER, &cfg);
}

void destroyListener(void)
{
  if(nlsocket)
  {
    netlink_kernel_release(nlsocket);
  }
}
