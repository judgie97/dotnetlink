#pragma once
struct sk_buff;
struct nf_hook_state;
struct FilterRule;

int ruleMatchesPacket(struct FilterRule* rule, struct sk_buff* skb, const struct nf_hook_state* state);
unsigned int filterHook(void* p, struct sk_buff* skb, const struct nf_hook_state* state);
