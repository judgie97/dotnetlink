// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public static class InterfaceBuilder
    {
        public static NetworkInterface Dot1Q(string name, int parentInterface, ushort vlanId)
        {
            return new NetworkInterface(parentInterface, name, InterfaceType.VLAN, new Vlan(vlanId));
        }
    }
}