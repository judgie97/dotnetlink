using System;
using System.Net;
using System.Text;

namespace dotnetlink
{
    public static class Util
    {
        public static uint Ip4ToUnsignedInt(IPAddress address)
        {
            byte[] bytes = address.GetAddressBytes();

            return ((bytes[3] * 256u + bytes[2]) * 256u + bytes[1]) * 256u + bytes[0];
        }

        public static unsafe string NativeToManagedString(sbyte* native, int maxLength = 50)
        {
            if (native == (sbyte*) 0)
            {
                return "";
            }

            int i = 0;
            while (native[i] != '\0')
            {
                if (i > maxLength)
                {
                    throw new Exception("Native String is longer than the max length");
                }

                i++;
            }

            return new string(native, 0, i, Encoding.UTF8);
        }

        public static byte[] StringToNativeBytes(String str)
        {
            var bytes = Encoding.Unicode.GetBytes(str + "\0");
            var rawBytes = new byte[bytes.Length / 2];
            for (int i = 0; i < rawBytes.Length; i++)
            {
                rawBytes[i] = bytes[2 * i];
            }

            return rawBytes;
        }
    }
}