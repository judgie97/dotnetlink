#include <linux/netlink.h>
#include <sys/socket.h>
#include <cstring>
#include <unistd.h>
#include "../Netlink.hpp"

int openNetlinkSocket(unsigned int portID, int protocol)
{
  struct sockaddr_nl saddr;

  int sock = socket(AF_NETLINK, SOCK_RAW, protocol);
  if(sock < 0)
    return COULD_NOT_OPEN_NETLINK_SOCKET;
  memset(&saddr, 0, sizeof(saddr));
  saddr.nl_family = AF_NETLINK;
  saddr.nl_pid = portID;
  if(bind(sock, (struct sockaddr*) &saddr, sizeof(saddr)) < 0)
    return COULD_NOT_BIND_SOCKET_TO_NETLINK;
  return sock;
}

int closeNetlinkSocket(int socket)
{
  return close(socket);
}