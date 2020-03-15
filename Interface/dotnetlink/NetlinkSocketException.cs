using System;

namespace dotnetlink
{
    public enum NetlinkExceptionValue
    {
        COULD_NOT_OPEN_NETLINK_SOCKET = -4,
        COULD_NOT_BIND_SOCKET_TO_NETLINK = -8,
        UNABLE_TO_RECEIVE_FROM_NETLINK = -16,
        NO_DATA_ON_NETLINK_SOCKET = -32,
        NETLINK_DUMP_INTERUPTED = -64,
        NETLINK_ERROR = -128,
        TLV_BREACHES_MESSAGE_LENGTH = -256,
        CANNOT_CREATE_PHYSICAL_INTERFACE = -512,
        UNKNOWN_INTERFACE_TYPE = -1024
    }

    public class NetlinkSocketException : Exception
    {
        public NetlinkExceptionValue exceptionValue { get; set; }
        
        public NetlinkSocketException(NetlinkExceptionValue exceptionValue)
        {
            this.exceptionValue = exceptionValue;
        }
    }
}