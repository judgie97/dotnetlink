#include <linux/netlink.h>
#include <linux/rtnetlink.h>
#include <ctime>
#include <sys/socket.h>
#include <cstring>
#include <net/if.h>

#include "../Netlink.hpp"
#include "../Socket/SocketOperations.hpp"
#include "../Socket/TLVOperations.hpp"

int setNetworkInterface(int sock, unsigned int portID, unsigned int interfaceIndex, bool up)
{
    struct
    {
        struct nlmsghdr nlh;
        struct ifinfomsg interfacemsg;
        unsigned char buffer[4096];
    } nl_request;

    memset(&nl_request, 0, sizeof(nl_request));

    nl_request.nlh.nlmsg_type = RTM_SETLINK;
    nl_request.nlh.nlmsg_flags = NLM_F_REQUEST;
    nl_request.nlh.nlmsg_len = sizeof(nl_request) - 4096;
    nl_request.nlh.nlmsg_seq = time(NULL);
    nl_request.nlh.nlmsg_pid = portID;

    nl_request.interfacemsg.ifi_family = 0;
    nl_request.interfacemsg.ifi_index = interfaceIndex;
    nl_request.interfacemsg.ifi_type = 0;
    nl_request.interfacemsg.ifi_change = IFF_UP;
    nl_request.interfacemsg.ifi_flags = up ? IFF_UP : 0;

    send(sock, &nl_request, nl_request.nlh.nlmsg_len, 0);

    flushSocket(sock);

    return 1;
}
