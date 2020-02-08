#include "Test.hpp"
#include <iostream>
#include <unistd.h>
#include <cstring>
#include <arpa/inet.h>

int main(void)
{
  int nfsock = openNetlinkSocket(getpid(), NETLINK_ROUTE);

  removeInterface(nfsock, getpid(), 5);

  closeNetlinkSocket(nfsock);

  return 0;
}
