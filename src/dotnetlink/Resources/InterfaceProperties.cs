namespace dotnetlink
{
    public enum InterfaceType
    {
        PHYSICAL,
        LOOPBACK,
        BRIDGE
    }

    public enum InterfaceEncapsulation
    {
        NONE,
        DOT1Q
    }
    
    public enum InterfaceState
    {
        UNSPECIFIED,
        UP,
        DOWN
    }
}