using System;

namespace libnl
{
    public static class NLMessageFlag
    {
        public const int REQUEST = 0x01;
        public const int MULTI = 0x02;
        public const int ACK = 0x04;
        public const int ECHO = 0x08;
        public const int DUMP_INTR = 0x10;
        public const int DUMP_FILTERED = 0x20;

        public const int ROOT = 0x100;
        public const int MATCH = 0x200;
        public const int ATOMIC = 0x400;
        public const int DUMP = (ROOT | MATCH);
        public const int REPLACE = 0x100;
        public const int EXCL = 0x200;
        public const int CREATE = 0x400;
        public const int APPEND = 0x800;

        public const int NONREC = 0x100;

        public const int CAPPED = 0x100;
        public const int ACK_TLVS = 0x200;
    }

    public static class AddressFamily
    {
        public const int UNSPEC = 0;
        public const int UNIX = 1;
        public const int LOCAL = 1;
        public const int INET = 2;
        public const int AX25 = 3;
        public const int IPX = 4;
        public const int APPLETALK = 5;
        public const int NETROM = 6;
        public const int BRIDGE = 7;
        public const int ATMPVC = 8;
        public const int X25 = 9;
        public const int INET6 = 10;
        public const int ROSE = 11;
        public const int DECnet = 12;
        public const int NETBEUI = 13;
        public const int SECURITY = 14;
        public const int KEY = 15;
        public const int NETLINK = 16;
        public const int ROUTE = NETLINK;
        public const int PACKET = 17;
        public const int ASH = 18;
        public const int ECONET = 19;
        public const int ATMSVC = 20;
        public const int RDS = 21;
        public const int SNA = 22;
        public const int IRDA = 23;
        public const int PPPOX = 24;
        public const int WANPIPE = 25;
        public const int LLC = 26;
        public const int IB = 27;
        public const int MPLS = 28;
        public const int CAN = 29;
        public const int TIPC = 30;
        public const int BLUETOOTH = 31;
        public const int IUCV = 32;
        public const int RXRPC = 33;
        public const int ISDN = 34;
        public const int PHONET = 35;
        public const int IEEE802154 = 36;
        public const int CAIF = 37;
        public const int ALG = 38;
        public const int NFC = 39;
        public const int VSOCK = 40;
        public const int KCM = 41;
        public const int QIPCRTR = 42;
        public const int SMC = 43;
        public const int XDP = 44;

        public static int Convert(System.Net.Sockets.AddressFamily family)
        {
            switch (family)
            {
                case System.Net.Sockets.AddressFamily.InterNetwork: return INET;
                case System.Net.Sockets.AddressFamily.InterNetworkV6: return INET6;
                default: throw new NotImplementedException();
            }
        }

        public static uint Size(int family)
        {
            switch (family)
            {
                case INET: return 4;
                case INET6: return 16;
                default: throw new NotImplementedException();
            }
        }
    }
}