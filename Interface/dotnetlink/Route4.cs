using System.Net;

namespace dotnetlink
{
    public struct NetlinkRoute4
    {
        public uint destination;
        public uint nic;
        public uint gateway;
        public byte netmask;
        public byte protocol;

        public Route4 toRoute4()
        {
            return new Route4(new IPAddress(destination), netmask, new IPAddress(gateway), nic, (RoutingProtocol) protocol);
        }
    }

    public class Route4
    {
        public IPAddress destination;
        public IPAddress gateway;
        public byte netmask;
        public uint nic;
        public RoutingProtocol protocol;
        public Route4(IPAddress destination, byte netmask, IPAddress gateway, uint nic, RoutingProtocol protocol)
        {
            this.destination = destination;
            this.netmask = netmask;
            this.gateway = gateway;
            this.nic = nic;
            this.protocol = protocol;
        }
    }
}