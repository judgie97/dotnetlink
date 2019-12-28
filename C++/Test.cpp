#include "Test.hpp"
#include <zconf.h>
#include <arpa/inet.h>

int main(void)
{
  int sock = openNetlinkSocket(getpid());
  unsigned char* storage;
  requestAllAddresses(sock, &storage);
  return 0;
}