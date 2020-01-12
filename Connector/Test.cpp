#include "Test.hpp"
#include <iostream>
#include <unistd.h>

int main(void)
{
  int sock = openNetlinkSocket(getpid());
  setNetworkInterface(sock, getpid(), 2, false);
  return 0;
}