// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public enum InterfaceType
    {
        PHYSICAL,
        LOOPBACK,
        BRIDGE,
        VLAN,
        VETH
    }
    
    public enum InterfaceState
    {
        UNSPECIFIED,
        UP,
        DOWN
    }
}