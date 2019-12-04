#include "Test.hpp"
#include <zconf.h>
#include <iostream>
#include <libnet.h>

int main(void)
{
  int sock = openNetlinkSocket(getpid());
  unsigned char* storage;

  requestAllRoutes(sock, &storage);

  route4 route;
  route.destination = inet_addr("192.168.2.0");
  route.gateway = inet_addr("192.168.1.1");
  route.netmask = 24;
  route.interface = 0;

  addRoute(sock, getpid(), &route);
  return 0;
}