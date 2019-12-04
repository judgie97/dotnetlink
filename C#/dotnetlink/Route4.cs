using System.Net;

namespace dotnetlink
{
    public struct NetlinkRoute4
    {
        public uint destination;
        public uint nic;
        public uint gateway;
        public byte netmask;

        public Route4 toRoute4()
        {
            return new Route4(new IPAddress(destination), netmask, new IPAddress(gateway), nic);
        }
    }

    public class Route4
    {
        public IPAddress destination;
        public IPAddress gateway;
        public byte netmask;
        public uint nic;

        public Route4(IPAddress destination, byte netmask, IPAddress gateway, uint nic)
        {
            this.destination = destination;
            this.netmask = netmask;
            this.gateway = gateway;
            this.nic = nic;
        }
    }
}