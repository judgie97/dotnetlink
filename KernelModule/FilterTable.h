#pragma once

struct __attribute__((__packed__)) FilterRule
{
  unsigned char filterByInboundInterface;
  unsigned int inboundInterface;
  unsigned char filterByOutboundInterface;
  unsigned int outboundInterface;
  unsigned char filterBySourceAddress;
  unsigned int sourceAddress;
  unsigned int sourceNetmask;
  unsigned char filterByDestinationAddress;
  unsigned int destinationAddress;
  unsigned int destinationNetmask;
  unsigned char filterByProtocol;
  unsigned char protocol;
  unsigned char filterBySourcePort;
  unsigned short sourcePort;
  unsigned char filterByDestinationPort;
  unsigned short destinationPort;
};

struct __attribute__((__packed__)) DotNetFilterRule
{
  unsigned int id;
  struct FilterRule rule;
  unsigned char action;
  unsigned int next;
};

void destroyFilterTable(void);
unsigned int addRule(struct DotNetFilterRule* rule);
unsigned int delRule(unsigned int rule);
int getRules(struct DotNetFilterRule** rules);
unsigned int ruleCount(void);
