#define __KERNEL__
#define __MODULE__

#include "Filtering.h"
#include "FilterTable.h"

#include <linux/netfilter.h>
#include <linux/ip.h>
#include <linux/tcp.h>
#include <linux/udp.h>

unsigned char implicitFilterAction[NF_INET_NUMHOOKS];
extern struct DotNetFilterRule* filterTable;

int ruleMatchesPacket(struct FilterRule* rule, struct sk_buff* skb, const struct nf_hook_state* state)
{
  struct iphdr* iph = ip_hdr(skb);

  if(rule->filterByInboundInterface)
  {
    if(rule->inboundInterface != state->in->ifindex)
      return 0;
  }

  if(rule->filterByOutboundInterface)
  {
    if(rule->outboundInterface != state->out->ifindex)
      return 0;
  }

  if(rule->filterBySourceAddress)
  {
    unsigned int a = rule->sourceAddress & rule->sourceNetmask;
    unsigned int b = iph->saddr & rule->sourceNetmask;

    if(a != b)
      return 0;
  }

  if(rule->filterByDestinationAddress)
  {
    unsigned int a = rule->destinationAddress & rule->destinationNetmask;
    unsigned int b = iph->daddr & rule->destinationNetmask;

    if(a != b)
      return 0;
  }

  if(rule->filterByProtocol)
  {
    if(rule->protocol != iph->protocol)
      return 0;
  }

  if(rule->protocol == IPPROTO_UDP)
  {
    struct udphdr* udp = udp_hdr(skb);

    if(rule->filterBySourcePort)
    {
      if(rule->sourcePort != udp->source)
        return 0;
    }

    if(rule->filterByDestinationPort)
    {
      if(rule->destinationPort != udp->dest)
        return 0;
    }
  }

  if(rule->protocol == IPPROTO_TCP)
  {
    struct tcphdr* tcp = tcp_hdr(skb);

    if(rule->filterBySourcePort)
    {
      if(rule->sourcePort != tcp->source)
        return 0;
    }

    if(rule->filterByDestinationPort)
    {
      if(rule->destinationPort != tcp->dest)
        return 0;
    }
  }

  return 1;
}

unsigned int filterHook(void* p, struct sk_buff* skb, const struct nf_hook_state* state)
{
  if(!skb)
    return NF_ACCEPT;

  if(filterTable == 0)
    return NF_ACCEPT;

  int i;
  for(i = 0; i < ruleCount(); i++)
  {
    if (ruleMatchesPacket(&(filterTable[i].rule), skb, state))
    {
      return filterTable->action;
    }
  }
  return implicitFilterAction[state->hook];
}