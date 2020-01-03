#include "Test.hpp"
#include <iostream>
#include <unistd.h>

int main(void)
{
  int sock = openNetlinkSocket(getpid());
  unsigned char* storage;
  std::cout << requestAllNetworkInterfaces(sock, &storage) << std::endl;
  return 0;
}