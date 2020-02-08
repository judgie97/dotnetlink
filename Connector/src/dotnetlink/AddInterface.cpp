#include "../Netlink.hpp"
#include "../Socket/SocketOperations.hpp"
#include "../Socket/TLVOperations.hpp"

#include <linux/netlink.h>
#include <linux/rtnetlink.h>
#include <cstring>
#include <ctime>
#include <sys/socket.h>

int addInterface(int sock, unsigned int portID, NetworkInterface* interface)
{
  if(interface->interfaceType == DNL_IFT_PHYSICAL)
    return CANNOT_CREATE_PHYSICAL_INTERFACE;

  struct
  {
    struct nlmsghdr nlh;
    struct ifinfomsg interfacemsg;
    unsigned char buffer[4096];
  } nl_request;

  memset(&nl_request, 0, sizeof(nl_request));

  nl_request.nlh.nlmsg_type = RTM_NEWLINK;
  nl_request.nlh.nlmsg_flags = NLM_F_REQUEST | NLM_F_CREATE;
  nl_request.nlh.nlmsg_len = sizeof(nl_request) - 4096;
  nl_request.nlh.nlmsg_seq = time(NULL);
  nl_request.nlh.nlmsg_pid = portID;

  nl_request.interfacemsg.ifi_family = 0;
  nl_request.interfacemsg.ifi_index = 0;
  nl_request.interfacemsg.ifi_type = 0;
  nl_request.interfacemsg.ifi_change = 0;
  nl_request.interfacemsg.ifi_flags = 0;

  int link = interface->parentInterface;
  addTLVToMessage(&nl_request.nlh, sizeof(nl_request), IFLA_LINK, &link, 4);

  int nameLen = strnlen(interface->interfaceName, 21);
  addTLVToMessage(&nl_request.nlh, sizeof(nl_request), IFLA_IFNAME, interface->interfaceName, nameLen);


  if(interface->interfaceType == DNL_IFT_DOT1Q)
  {
    addTLVToMessage(&nl_request.nlh, sizeof(nl_request), IFLA_LINKINFO, interface->interfaceName, 0, 24);

    char vlan[4] = {'v', 'l', 'a', 'n'};
    addTLVToMessage(&nl_request.nlh, sizeof(nl_request), IFLA_INFO_KIND, vlan, 4);

    unsigned char vlanData[8] = {0x06, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00};
    ((unsigned int*) vlanData)[1] = interface->vlanData.vlanID;
    addTLVToMessage(&nl_request.nlh, sizeof(nl_request), IFLA_INFO_DATA, vlanData, 8);
  }
  else
  {
    return UNKNOWN_INTERFACE_TYPE;
  }
  send(sock, &nl_request, nl_request.nlh.nlmsg_len, 0);

  flushSocket(sock);

  return 1;
}