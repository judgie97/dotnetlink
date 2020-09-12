// ReSharper disable CheckNamespace
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable UnusedMember.Global
namespace dotnetlink
{
    public class Vlan
    {
        public ushort VlanId { get; set; }

        public Vlan()
        {
            VlanId = 0;
        }

        public Vlan(ushort vlanId)
        {
            this.VlanId = vlanId;
        }

        public override string ToString()
        {
            return "VLAN " + VlanId;
        }
    }
}