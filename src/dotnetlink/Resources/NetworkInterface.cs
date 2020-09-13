using System;
using System.Net.NetworkInformation;
using libnl;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

// ReSharper disable once CheckNamespace
namespace dotnetlink
{
    public class NetworkInterface
    {
        public int Index { get; set; }
        public int ParentInterfaceIndex { get; set; }
        public String InterfaceName { get; set; }
        public PhysicalAddress HardwareAddress { get; set; }
        public bool IsUp { get; set; }
        public bool IsLowerLayerUp { get; set; }
        public bool IsBroadcastInterface { get; set; }
        public bool IsLoopbackInterface { get; set; }
        public bool IsPointToPointInterface { get; set; }
        public bool IsNbmaInterface { get; set; }
        public bool IsPromiscuousInterface { get; set; }
        public InterfaceType InterfaceType { get; set; }
        public object InterfaceInformation { get; set; }
        
        public uint MaximumTransmissionUnit { get; set; }

        public NetworkInterface(int parentInterfaceIndex, String interfaceName, InterfaceType interfaceType,
            Object interfaceInformation) :
            this(0, parentInterfaceIndex, interfaceName, PhysicalAddress.None, false, false, false, false, false, false,
                false,
                interfaceType, interfaceInformation)
        {
        }

        public NetworkInterface(int index, int parentInterfaceIndex, String interfaceName,
            PhysicalAddress hardwareAddress, bool isUp, bool isLowerLayerUp,
            bool isBroadcastInterface,
            bool isLoopbackInterface, bool isPointToPointInterface, bool isNbmaInterface, bool isPromiscuousInterface,
            InterfaceType interfaceType, Object interfaceInformation)
        {
            Index = index;
            ParentInterfaceIndex = parentInterfaceIndex;
            InterfaceName = interfaceName;
            HardwareAddress = hardwareAddress;
            IsUp = isUp;
            IsLowerLayerUp = isLowerLayerUp;
            IsBroadcastInterface = isBroadcastInterface;
            IsLoopbackInterface = isLoopbackInterface;
            IsPointToPointInterface = isPointToPointInterface;
            IsNbmaInterface = isNbmaInterface;
            IsPromiscuousInterface = isPromiscuousInterface;
            InterfaceType = interfaceType;
            InterfaceInformation = interfaceInformation;
        }

        public unsafe NetworkInterface(nl_object* link) : this((rtnl_link*) link)
        {
        }

        public unsafe NetworkInterface(rtnl_link* link)
        {
            Index = LibNLRoute3.rtnl_link_get_ifindex(link);
            ParentInterfaceIndex = LibNLRoute3.rtnl_link_get_link(link);
            InterfaceName = Util.NativeToManagedString((sbyte*) LibNLRoute3.rtnl_link_get_name(link));

            sbyte* typeStringNative = (sbyte*) LibNLRoute3.rtnl_link_get_type(link);
            string type = Util.NativeToManagedString(typeStringNative);

            switch (type)
            {
                case "":
                    InterfaceType = InterfaceType.PHYSICAL;
                    break;
                case "vlan":
                    InterfaceType = InterfaceType.VLAN;
                    break;
                case "bridge":
                    InterfaceType = InterfaceType.BRIDGE;
                    break;
                case "veth":
                    InterfaceType = InterfaceType.VETH;
                    break;
                default: throw new NotSupportedException("Interface type " + type + " not supported");
            }

            nl_addr* hwAddr = LibNLRoute3.rtnl_link_get_addr(link);
            if (hwAddr != null)
            {
                byte* mac = (byte*) LibNL3.nl_addr_get_binary_addr(hwAddr);
                byte[] macBytes = new byte[6];
                for (int i = 0; i < 6; i++)
                {
                    macBytes[i] = mac[i];
                }

                HardwareAddress = new PhysicalAddress(macBytes);
            }

            var linkFlags = LibNLRoute3.rtnl_link_get_flags(link);
            IsUp = (linkFlags & NLInterfaceFlags.UP) != 0;
            IsLowerLayerUp = (linkFlags & NLInterfaceFlags.LOWER_UP) != 0;
            IsBroadcastInterface = (linkFlags & NLInterfaceFlags.BROADCAST) != 0;
            IsLoopbackInterface = (linkFlags & NLInterfaceFlags.LOOPBACK) != 0;
            IsPointToPointInterface = (linkFlags & NLInterfaceFlags.POINTOPOINT) != 0;
            IsNbmaInterface = !(IsBroadcastInterface || IsLoopbackInterface || IsPointToPointInterface);
            IsPromiscuousInterface = (linkFlags & NLInterfaceFlags.PROMISC) != 0;

            if (InterfaceType == InterfaceType.PHYSICAL && IsLoopbackInterface)
            {
                InterfaceType = InterfaceType.LOOPBACK;
            }

            if (InterfaceType == InterfaceType.VLAN)
            {
                var info = new Vlan((ushort) LibNLRoute3.rtnl_link_vlan_get_id(link));
                InterfaceInformation = info;
            }

            MaximumTransmissionUnit = LibNLRoute3.rtnl_link_get_mtu(link);
        }
    }
}