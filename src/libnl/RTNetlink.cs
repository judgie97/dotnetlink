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
        public const int DUMP = (ROOT|MATCH);
        public const int REPLACE = 0x100;
        public const int EXCL = 0x200;
        public const int CREATE = 0x400;
        public const int APPEND = 0x800;

        public const int NONREC = 0x100;
        
        public const int CAPPED = 0x100;
        public const int ACK_TLVS = 0x200;
    }
}