using System.Net;
using System.Net.NetworkInformation;
using libnl;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public class Neighbour
    {
        public PhysicalAddress Layer2Address { get; set; }
        public IPAddress Layer3Address { get; set; }
        public ushort VlanId { get; set; }

        public int Family { get; set; }

        public unsafe Neighbour(nl_object* neighbour) : this((rtnl_neigh*) neighbour)
        {
        }

        public unsafe Neighbour(rtnl_neigh* neighbour)
        {
            nl_addr* l2Addr = LibNLRoute3.rtnl_neigh_get_lladdr(neighbour);
            byte* mac = (byte*) LibNL3.nl_addr_get_binary_addr(l2Addr);
            byte[] macBytes = new byte[6];
            for (int i = 0; i < 6; i++)
            {
                macBytes[i] = mac[i];
            }
            Layer2Address = new PhysicalAddress(macBytes);


            nl_addr* l3Addr = LibNLRoute3.rtnl_neigh_get_dst(neighbour);
            uint addressLength = LibNL3.nl_addr_get_len(l3Addr);

            byte[] bytes = new byte[addressLength];
            for (uint i = 0; i < addressLength; i++)
            {
                bytes[i] = ((byte*) LibNL3.nl_addr_get_binary_addr(l3Addr))[i];
            }
            Layer3Address = new IPAddress(bytes);

            VlanId = (ushort) LibNLRoute3.rtnl_neigh_get_vlan(neighbour);
            Family = LibNLRoute3.rtnl_neigh_get_family(neighbour);
        }

        public override string ToString()
        {
            return Layer2Address + " - " + Layer3Address;
        }
    }
}