#define __KERNEL__
#define __MODULE__

#include "Hooks.h"
#include "Filtering.h"

#include <linux/netfilter.h>
#include <linux/netfilter_ipv4.h>
#include <linux/tcp.h>
#include <linux/udp.h>

static struct nf_hook_ops netfilterInHook;
static struct nf_hook_ops netfilterForwardHook;
static struct nf_hook_ops netfilterOutHook;

void registerHooks(void)
{
  netfilterInHook.hook = filterHook;
  netfilterInHook.pf = PF_INET;
  netfilterInHook.hooknum = NF_INET_LOCAL_IN;
  netfilterInHook.priority = NF_IP_PRI_FIRST;
  nf_register_net_hook(&init_net, &netfilterInHook);

  netfilterForwardHook.hook = filterHook;
  netfilterForwardHook.pf = PF_INET;
  netfilterForwardHook.hooknum = NF_INET_FORWARD;
  netfilterForwardHook.priority = NF_IP_PRI_FIRST;
  nf_register_net_hook(&init_net, &netfilterForwardHook);

  netfilterOutHook.hook = filterHook;
  netfilterOutHook.pf = PF_INET;
  netfilterOutHook.hooknum = NF_INET_LOCAL_OUT;
  netfilterOutHook.priority = NF_IP_PRI_FIRST;
  nf_register_net_hook(&init_net, &netfilterOutHook);
}

void unregisterHooks(void)
{
  nf_unregister_net_hook(&init_net, &netfilterInHook);
  nf_unregister_net_hook(&init_net, &netfilterOutHook);
}