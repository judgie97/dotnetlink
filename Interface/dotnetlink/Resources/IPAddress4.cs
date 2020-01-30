using System.Net;
using System.Runtime.InteropServices;

namespace dotnetlink
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct NetlinkIPAddress4
    {
        public uint address;
        public uint nic;
        public byte netmask;

        public IPAddress4 toIPAddress4()
        {
            return new IPAddress4(new IPAddress(address), netmask, nic);
        }
    }

    public class IPAddress4
    {
        public IPAddress address;
        public byte netmask;
        public uint nic;

        public IPAddress4(IPAddress address, byte netmask, uint nic)
        {
            this.address = address;
            this.netmask = netmask;
            this.nic = nic;
        }
    }
}