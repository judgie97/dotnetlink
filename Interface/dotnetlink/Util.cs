using System.Net;

namespace dotnetlink
{
    public class Util
    {
        public static uint ip4touint(IPAddress address)
        {
            byte[] bytes = address.GetAddressBytes();

            return ((bytes[3] * 256u + bytes[2]) * 256u + bytes[1]) * 256u + bytes[0];
        }
    }
}