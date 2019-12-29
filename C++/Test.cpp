#include "Test.hpp"
#include <zconf.h>
#include <arpa/inet.h>
#include <iostream>

int main(void)
{
  int sock = openNetlinkSocket(getpid());
  unsigned char* storage;
  std::cout << requestAllNetworkInterfaces(sock, &storage) << std::endl;
  return 0;
}