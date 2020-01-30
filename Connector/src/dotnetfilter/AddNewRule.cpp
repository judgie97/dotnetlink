#include "../Netlink.hpp"
#include "../Socket/SocketOperations.hpp"
#include <linux/netlink.h>
#include <ctime>
#include <sys/socket.h>
#include <cstring>
#include <iostream>


unsigned int receiveNewRule(int sockfd)
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
  unsigned int ruleID = *(unsigned int*) NLMSG_DATA(header);
  delete[] buffer;

  return ruleID;
}

unsigned int addNewRule(int sockfd, unsigned int pid, DotNetFilterRule* rule)
{
  struct
  {
    nlmsghdr nlm;
    DotNetFilterRule rule;
  } message;

  message.nlm.nlmsg_type = DNF_ADDRULE;
  message.nlm.nlmsg_flags = 0;
  message.nlm.nlmsg_len = sizeof(message);
  message.nlm.nlmsg_seq = time(0);
  message.nlm.nlmsg_pid = pid;

  memcpy(&message.rule, rule, sizeof(DotNetFilterRule));
  unsigned int bytes = send(sockfd, &message, sizeof(message), 0);

  return receiveNewRule(sockfd);
}
