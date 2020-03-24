using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace dotnetlink
{
    public class Util
    {
        public static uint ip4touint(IPAddress address)
        {
            byte[] bytes = address.GetAddressBytes();

            return ((bytes[3] * 256u + bytes[2]) * 256u + bytes[1]) * 256u + bytes[0];
        }

        public static unsafe string nativeToManagedString(sbyte* native, int maxLength = 50)
        {
            if (native == (sbyte*)0)
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
    }
}