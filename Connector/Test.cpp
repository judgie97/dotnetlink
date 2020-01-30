#include "Test.hpp"
#include <iostream>
#include <unistd.h>
#include <cstring>
#include <arpa/inet.h>

int main(void)
{
  int nfsock = openNetlinkSocket(getpid(), NETLINK_DOTNETFILTER);

  DotNetFilterRule rule;
  memset(&rule, 0, sizeof(rule));
  rule.rule.filterByProtocol = 1;
  rule.rule.protocol = 1;
  rule.rule.filterByDestinationAddress = 1;
  rule.rule.destinationNetmask = inet_addr("255.255.255.0");
  rule.rule.destinationAddress = inet_addr("127.0.0.0");

  unsigned int ruleID = addNewRule(nfsock, getpid(), &rule);
  std::cout << "New Rule: " << ruleID << std::endl;
  std::cout << "Rule Size: " << sizeof(DotNetFilterRule) << std::endl;

  unsigned char* storage;
  std::cout << "Rules " << requestAllRules(nfsock, getpid(), &storage) << std::endl;
  DotNetFilterRule* rule1 = (DotNetFilterRule*) storage;

  closeNetlinkSocket(nfsock);

  return 0;
}
