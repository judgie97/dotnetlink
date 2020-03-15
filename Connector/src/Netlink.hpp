#pragma once

//Prevent function names being mangled in shared objects
#define DNL_API extern "C"

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

struct nl_sock;
//EXPORTED FUNCTIONS

//SOCKET MANAGEMENT
DNL_API struct nl_sock* openNetlinkSocket();
DNL_API void closeNetlinkSocket(struct nl_sock* socket);

//ROUTING
DNL_API int addRoute(struct nl_sock* socket, Route4* route);
DNL_API int removeRoute(struct nl_sock* socket, Route4* route);
DNL_API int requestAllRoutes(struct nl_sock* socket, unsigned char** storage);

//ADDRESSING
DNL_API int addIPAddress(struct nl_sock* socket, IPAddress4* address);
DNL_API int removeIPAddress(struct nl_sock* socket, IPAddress4* address);
DNL_API int requestAllAddresses(struct nl_sock* socket, unsigned char** storage);

//NETWORK INTERFACES
DNL_API int addInterface(struct nl_sock* socket, NetworkInterface* interface);
DNL_API int removeInterface(struct nl_sock* socket, NetworkInterface* interface);
DNL_API int requestAllNetworkInterfaces(struct nl_sock* socket, unsigned char** storage);
DNL_API int setNetworkInterface(struct nl_sock* socket, unsigned int interfaceIndex, bool up);
