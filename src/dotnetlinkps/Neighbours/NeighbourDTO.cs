using System.Net;
using System.Net.NetworkInformation;
using dotnetlink;
using dotnetlinkps.Interfaces;
using libnl;

namespace dotnetlinkps.Neighbours
{
    public class NeighbourDto
    {
        public PhysicalAddress Layer2Address { get; set; }
        public IPAddress Layer3Address { get; set; }
        public ushort VlanId { get; set; }
        public int Family { get; set; }
    }
}