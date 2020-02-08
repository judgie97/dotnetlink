#include "Test.hpp"
#include <iostream>
#include <unistd.h>
#include <cstring>
#include <arpa/inet.h>

int main(void)
{
  int nfsock = openNetlinkSocket(getpid(), NETLINK_ROUTE);

  NetworkInterface interface;

  interface.interfaceType = DNL_IFT_DOT1Q;
  interface.vlanData.vlanID = 100;
  

  closeNetlinkSocket(nfsock);

  return 0;
}
