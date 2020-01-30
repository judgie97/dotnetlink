#include "../Netlink.hpp"
#include "../Socket/SocketOperations.hpp"
#include <sys/socket.h>
#include <linux/netlink.h>
#include <cstring>
#include <ctime>

int receiveAllRules(int sockfd, unsigned char** storage)
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

  int length = receiveMessage(sockfd, &msg, MSG_PEEK | MSG_TRUNC);
  if (length <= 0)
    return NO_DATA_ON_NETLINK_SOCKET;

  char* buffer = new char[length];
  iov.iov_len = length;
  iov.iov_base = buffer;

  length = receiveMessage(sockfd, &msg, 0);

  struct nlmsghdr* header = (struct nlmsghdr*) buffer;
  DotNetFilterRule* filterRules = (DotNetFilterRule*) NLMSG_DATA(header);

  int numberOfRules = (length - 16) / sizeof(DotNetFilterRule);
  if(numberOfRules)
  {
    *storage = new unsigned char[numberOfRules * sizeof(DotNetFilterRule)];
    memcpy(*storage, filterRules, numberOfRules * sizeof(DotNetFilterRule));
  }
  delete[] buffer;
  return numberOfRules;
}

int requestAllRules(int sockfd, unsigned int pid, unsigned char** storage)
{
  struct nlmsghdr nlm;
  nlm.nlmsg_type = DNF_GETRULE;
  nlm.nlmsg_flags = 0;
  nlm.nlmsg_len = sizeof(nlm);
  nlm.nlmsg_seq = time(0);
  nlm.nlmsg_pid = pid;

  send(sockfd, &nlm, sizeof(nlm), 0);
  return receiveAllRules(sockfd, storage);
}