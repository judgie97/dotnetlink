#include <cstring>
#include <linux/netlink.h>
#include <linux/if_addr.h>
#include <linux/rtnetlink.h>
#include <ctime>
#include <sys/socket.h>
#include "Netlink.hpp"
#include "SocketOperations.hpp"
#include "RTMOperations.hpp"

int addIPAddress(int sock, unsigned int portID, IPAddress4* address)
{
    struct
    {
        struct nlmsghdr nlh;
        struct ifaddrmsg addrmsg;
        unsigned char buffer[4096];
    } nl_request;

    memset(&nl_request, 0, sizeof(nl_request));

    nl_request.nlh.nlmsg_type = RTM_NEWADDR;
    nl_request.nlh.nlmsg_flags = NLM_F_REQUEST|NLM_F_CREATE;
    nl_request.nlh.nlmsg_len = sizeof(nl_request) - 4096;
    nl_request.nlh.nlmsg_seq = time(NULL);
    nl_request.nlh.nlmsg_pid = portID;

    nl_request.addrmsg.ifa_family = AF_INET;
    nl_request.addrmsg.ifa_flags = 0;
    nl_request.addrmsg.ifa_prefixlen = address->prefixLength;
    nl_request.addrmsg.ifa_scope = RT_SCOPE_UNIVERSE;
    nl_request.addrmsg.ifa_index = address->interface;

    int result = addAttributeToMessage(&nl_request.nlh, sizeof(nl_request), IFA_ADDRESS, &address->address, 4);
    if(result < 0)
        return result;

    result = addAttributeToMessage(&nl_request.nlh, sizeof(nl_request), IFA_LOCAL, &address->address, 4);
    if(result < 0)
        return result;

    send(sock, &nl_request, nl_request.nlh.nlmsg_len, 0);

    flushSocket(sock);

    return 1;
};