#pragma once

//Prevent function names being mangled in shared objects
#define DNL_API extern "C"

//ERROR CODES
#define COULD_NOT_OPEN_NETLINK_SOCKET -4
#define COULD_NOT_BIND_SOCKET_TO_NETLINK -8
#define UNABLE_TO_RECEIVE_FROM_NETLINK -16
#define NO_DATA_ON_NETLINK_SOCKET -32
#define NETLINK_DUMP_INTERUPTED -64
#define NETLINK_ERROR -128
#define TLV_BREACHES_MESSAGE_LENGTH -256
#define CANNOT_CREATE_PHYSICAL_INTERFACE -512
#define UNKNOWN_INTERFACE_TYPE -1024

//Netlink protocols
#define NETLINK_ROUTE 0
#define NETLINK_DOTNETFILTER 25

//DOTNETFILTER MESSAGE TYPES
#define DNF_ADDRULE 150
#define DNF_DELRULE 151
#define DNF_GETRULE 152

#define DNL_STRUCT struct __attribute__((__packed__))

//TYPES
DNL_STRUCT Route4
{
  unsigned int destination;
  unsigned int interface;
  unsigned int gateway;
  unsigned char netmask;
  unsigned char protocol;
};

DNL_STRUCT IPAddress4
{
  unsigned int address;
  unsigned int interface;
  unsigned char prefixLength;
};

#define DNL_IFT_PHYSICAL 0
#define DNL_IFT_LOOPBACK 1
#define DNL_IFT_DOT1Q 2

DNL_STRUCT NetworkInterface
{
  unsigned int index;
  unsigned int parentInterface;
  unsigned char hardwareAddress[6];
  char interfaceName[21];
  bool isUp;
  bool isBroadcastInterface;
  bool isLoopbackInterface;
  bool isPointToPointInterface;
  bool isNBMAInterface;
  bool isPromiscuousInterface;
  unsigned char interfaceType;
  union
  {
    struct
    {
      unsigned int vlanID;
    } vlanData;
  };
};

DNL_STRUCT FilterRule
{
  unsigned char filterByInboundInterface;
  unsigned int inboundInterface;
  unsigned char filterByOutboundInterface;
  unsigned int outboundInterface;
  unsigned char filterBySourceAddress;
  unsigned int sourceAddress;
  unsigned int sourceNetmask;
  unsigned char filterByDestinationAddress;
  unsigned int destinationAddress;
  unsigned int destinationNetmask;
  unsigned char filterByProtocol;
  unsigned char protocol;
  unsigned char filterBySourcePort;
  unsigned short sourcePort;
  unsigned char filterByDestinationPort;
  unsigned short destinationPort;
};

DNL_STRUCT DotNetFilterRule
{
  unsigned int id;
  struct FilterRule rule;
  unsigned char action;
  unsigned int next;
};

//EXPORTED FUNCTIONS
DNL_API int openNetlinkSocket(unsigned int portID, int protocol);
DNL_API int closeNetlinkSocket(int socket);

//ROUTING
DNL_API int addRoute(int sock, unsigned int portID, Route4* route);
DNL_API int removeRoute(int sock, unsigned int portID, Route4* route);
DNL_API int requestAllRoutes(int sock, unsigned char** storage);

//ADDRESSING
DNL_API int addIPAddress(int sock, unsigned int portID, IPAddress4* address);
DNL_API int removeIPAddress(int sock, unsigned int portID, IPAddress4* address);
DNL_API int requestAllAddresses(int sock, unsigned char** storage);

//NETWORK INTERFACES
DNL_API int addInterface(int sock, unsigned int portID, NetworkInterface* interface);
DNL_API int setNetworkInterface(int sock, unsigned int portID, unsigned int interfaceIndex, bool up);
DNL_API int requestAllNetworkInterfaces(int sock, unsigned char** storage);

//FILTER
DNL_API unsigned int addNewRule(int sockfd, unsigned int pid, DotNetFilterRule* rule);
DNL_API unsigned int deleteRule(int sockfd, unsigned int pid, unsigned int rule);
DNL_API int requestAllRules(int sockfd, unsigned int pid, unsigned char** storage);
