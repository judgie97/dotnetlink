using System;
using libnl;
// ReSharper disable UnusedMember.Global

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public unsafe partial class NetlinkSocket
    {
        private nl_sock* _sockFd;

        public NetlinkSocket()
        {
            _sockFd = LibNL3.nl_socket_alloc();
            LibNL3.nl_connect(_sockFd, 0);
        }

        ~NetlinkSocket()
        {
            LibNL3.nl_close(_sockFd);
            LibNL3.nl_socket_free(_sockFd);
            _sockFd = (nl_sock*) 0;
        }
    }
}