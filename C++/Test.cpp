#include "Test.hpp"
#include <zconf.h>
#include <arpa/inet.h>

int main(void)
{
  int sock = openNetlinkSocket(getpid());

  IPAddress4 a = {inet_addr("192.168.1.5"), 24, 2};
  addIPAddress(sock, getpid(), &a);

  return 0;
}