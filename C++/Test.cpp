#include "Test.hpp"
#include <zconf.h>
#include <iostream>

int main(void)
{
  int sock = openNetlinkSocket(getpid());
  unsigned char* storage;
  int result = requestAllRoutes(sock, &storage);

  std::cout << "Route count: " << result << std::endl;

  return 0;
}