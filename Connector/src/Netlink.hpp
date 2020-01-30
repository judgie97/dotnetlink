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

//TYPES
struct Route4
{
  unsigned int destination;
  unsigned int interface;
  unsigned int gateway;
  unsigned char netmask;
  unsigned char protocol;
};

struct IPAddress4
{
  unsigned int address;
  unsigned int interface;
  unsigned char prefixLength;
};

struct NetworkInterface
{
  unsigned int index;
  unsigned char hardwareAddress[6];
  unsigned char interfaceName[21];
  bool isUp;
  bool isBroadcastInterface;
  bool isLoopbackInterface;
  bool isPointToPointInterface;
  bool isNBMAInterface;
  bool isPromiscuousInterface;
};

//EXPORTED FUNCTIONS
DNL_API int openNetlinkSocket(unsigned int portID);
DNL_API int closeNetlinkSocket(int socket);

//ROUTING
DNL_API int requestAllRoutes(int sock, unsigned char** storage);
DNL_API int addRoute(int sock, unsigned int portID, Route4* route);
DNL_API int removeRoute(int sock, unsigned int portID, Route4* route);

//ADDRESSING
DNL_API int addIPAddress(int sock, unsigned int portID, IPAddress4* address);
DNL_API int removeIPAddress(int sock, unsigned int portID, IPAddress4* address);
DNL_API int requestAllAddresses(int sock, unsigned char** storage);

//NETWORK INTERFACES
DNL_API int requestAllNetworkInterfaces(int sock, unsigned char** storage);
DNL_API int setNetworkInterface(int sock, unsigned int portID, unsigned int interfaceIndex, bool up);