#include "../Netlink.hpp"
#include <cstring>
#include <linux/rtnetlink.h>
#include <ctime>
#include <sys/socket.h>
#include "../Socket/SocketOperations.hpp"

int removeInterface(int sock, unsigned int portID, unsigned int interfaceIndex)
{
  struct
  {
    struct nlmsghdr nlh;
    struct ifinfomsg interfacemsg;
  } nl_request;

  memset(&nl_request, 0, sizeof(nl_request));

  nl_request.nlh.nlmsg_type = RTM_DELLINK;
  nl_request.nlh.nlmsg_flags = NLM_F_REQUEST;
  nl_request.nlh.nlmsg_len = sizeof(nl_request);
  nl_request.nlh.nlmsg_seq = time(NULL);
  nl_request.nlh.nlmsg_pid = portID;

  nl_request.interfacemsg.ifi_index = interfaceIndex;
  nl_request.interfacemsg.ifi_flags = 0;
  nl_request.interfacemsg.ifi_change = 0;
  nl_request.interfacemsg.ifi_type = 0;
  nl_request.interfacemsg.ifi_family = 0;

  send(sock, &nl_request, nl_request.nlh.nlmsg_len, 0);

  flushSocket(sock);

  return 1;
}