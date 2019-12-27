#include "Test.hpp"
#include <zconf.h>
#include <arpa/inet.h>

int main(void)
{
  int sock = openNetlinkSocket(getpid());

  IPAddress4 a = {inet_addr("192.168.1.5"), 2, 24};
  removeIPAddress(sock, getpid(), &a);

  return 0;
}