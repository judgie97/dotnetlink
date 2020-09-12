using System;

namespace dotnetlink
{
    public static class InterfaceBuilder
    {
        public static NetworkInterface Dot1Q(String name, int parentInterface, ushort vlanId)
        {
            return new NetworkInterface(parentInterface, name, InterfaceType.VLAN, new VLAN(vlanId));
        }
    }
}