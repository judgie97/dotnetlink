namespace libnl
{
    public static class NLInterfaceFlags
    {
        public const int UP = 1<<0;
        public const int BROADCAST = 1<<1;
        public const int DEBUG = 1<<2;
        public const int LOOPBACK = 1<<3;
        public const int POINTOPOINT = 1<<4;
        public const int NOTRAILERS = 1<<5;
        public const int RUNNING = 1<<6;
        public const int NOARP = 1<<7;
        public const int PROMISC = 1<<8;
        public const int ALLMULTI = 1<<9;
        public const int MASTER = 1<<10;
        public const int SLAVE = 1<<11;
        public const int MULTICAST = 1<<12;
        public const int PORTSEL = 1<<13;
        public const int AUTOMEDIA = 1<<14;
        public const int DYNAMIC = 1<<15;
        public const int LOWER_UP = 1<<16;
        public const int DORMANT = 1<<17;
        public const int ECHO = 1<<18;
    }
}