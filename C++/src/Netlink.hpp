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

//EXPORTED FUNCTIONS
DNL_API int openNetlinkSocket(unsigned int portID);
DNL_API int requestAllRoutes(int sock, unsigned char** storage);
DNL_API int closeNetlinkSocket(int socket);

//TYPES
struct route4
{
  unsigned int destination;
  unsigned int interface;
  unsigned int gateway;
  unsigned char netmask;
};

