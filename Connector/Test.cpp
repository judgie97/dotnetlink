#include <iostream>
#include <arpa/inet.h>
#include <netlink/errno.h>
#include <linux/rtnetlink.h>
#include <cstring>
#include "src/Netlink.hpp"
#include "Test.hpp"

int main(void)
{
  struct nl_sock* socket = openNetlinkSocket();

  unsigned char* data;

  setNetworkInterface(socket, 2, true);

  closeNetlinkSocket(socket);
  return 0;
}
