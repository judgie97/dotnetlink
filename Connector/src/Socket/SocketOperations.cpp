#include "SocketOperations.hpp"
#include <sys/socket.h>
#include <cerrno>
#include <linux/netlink.h>
#include "../Netlink.hpp"

int receiveMessage(int sock, struct msghdr* header, int flags)
{
  int length;
  do
  {
    length = recvmsg(sock, header, flags);
  } while(length < 0 && (errno == EINTR));

  if(errno == EAGAIN)
    return NO_DATA_ON_NETLINK_SOCKET;

  if(length < 0)
    return UNABLE_TO_RECEIVE_FROM_NETLINK;

  return length;
}

void flushSocket(int sock)
{
  struct sockaddr_nl nladdr;
  struct iovec iov;
  struct msghdr msg = {
    .msg_name = &nladdr,
    .msg_namelen = sizeof(nladdr),
    .msg_iov = &iov,
    .msg_iovlen = 1
  };

  iov.iov_base = 0;
  iov.iov_len = 0;

  while(receiveMessage(sock, &msg, MSG_DONTWAIT) != NO_DATA_ON_NETLINK_SOCKET);
}