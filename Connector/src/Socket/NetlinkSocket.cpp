#include <netlink/socket.h>
#include <netlink/netlink.h>
#include "../Netlink.hpp"


struct nl_sock* openNetlinkSocket()
{
  struct nl_sock* socket = nl_socket_alloc();
  nl_connect(socket, NETLINK_ROUTE);

  return socket;
}

void closeNetlinkSocket(struct nl_sock* socket)
{
  nl_close(socket);
  nl_socket_free(socket);
}