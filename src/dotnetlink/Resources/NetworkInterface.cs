using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using libnl;

namespace dotnetlink
{
    public class NetworkInterface
    {
        public int index { get; set; }
        public int parentInterfaceIndex { get; set; }
        public String interfaceName { get; set; }
        public PhysicalAddress hardwareAddress { get; set; }
        public bool isUp { get; set; }
        public bool isBroadcastInterface { get; set; }
        public bool isLoopbackInterface { get; set; }
        public bool isPointToPointInterface { get; set; }
        public bool isNBMAInterface { get; set; }
        public bool isPromiscuousInterface { get; set; }
        public InterfaceType interfaceType { get; set; }
        public Object interfaceInformation { get; set; }
        public InterfaceEncapsulation encapsulation { get; set; }

        public NetworkInterface(int index, int parentInterfaceIndex, String interfaceName,
            PhysicalAddress hardwareAddress, bool isUp,
            bool isBroadcastInterface,
            bool isLoopbackInterface, bool isPointToPointInterface, bool isNBMAInterface, bool isPromiscuousInterface,
            InterfaceType interfaceType, Object interfaceInformation)
        {
            this.index = index;
            this.parentInterfaceIndex = parentInterfaceIndex;
            this.interfaceName = interfaceName;
            this.hardwareAddress = hardwareAddress;
            this.isUp = isUp;
            this.isBroadcastInterface = isBroadcastInterface;
            this.isLoopbackInterface = isLoopbackInterface;
            this.isPointToPointInterface = isPointToPointInterface;
            this.isNBMAInterface = isNBMAInterface;
            this.isPromiscuousInterface = isPromiscuousInterface;
            this.interfaceType = interfaceType;
            this.interfaceInformation = interfaceInformation;
        }

        public unsafe NetworkInterface(nl_object* link) : this((rtnl_link*) link)
        {
        }

        public unsafe NetworkInterface(rtnl_link* link)
        {
            index = LibNLRoute3.rtnl_link_get_ifindex(link);
            parentInterfaceIndex = LibNLRoute3.rtnl_link_get_link(link);
            interfaceName = Util.nativeToManagedString((sbyte*) LibNLRoute3.rtnl_link_get_name(link));

            nl_addr* hwAddr = LibNLRoute3.rtnl_link_get_addr(link);
            byte* mac = (byte*) LibNL3.nl_addr_get_binary_addr(hwAddr);
            byte[] macBytes = new byte[6];
            for (int i = 0; i < 6; i++)
            {
                macBytes[i] = mac[i];
            }

            hardwareAddress = new PhysicalAddress(macBytes);

            isUp = (LibNLRoute3.rtnl_link_get_flags(link) & NLInterfaceFlags.UP) == 0;
            isBroadcastInterface = (LibNLRoute3.rtnl_link_get_flags(link) & NLInterfaceFlags.BROADCAST) != 0;
            isLoopbackInterface = (LibNLRoute3.rtnl_link_get_flags(link) & NLInterfaceFlags.LOOPBACK) != 0;
            isPointToPointInterface = (LibNLRoute3.rtnl_link_get_flags(link) & NLInterfaceFlags.POINTOPOINT) != 0;
            isNBMAInterface = !(isBroadcastInterface || isLoopbackInterface || isPointToPointInterface);
            isPromiscuousInterface = (LibNLRoute3.rtnl_link_get_flags(link) & NLInterfaceFlags.PROMISC) != 0;
            interfaceType = InterfaceType.PHYSICAL;

            if (Util.nativeToManagedString((sbyte*) LibNLRoute3.rtnl_link_get_type(link)).Equals("bridge"))
            {
                interfaceType = InterfaceType.BRIDGE;
            }

            if (isLoopbackInterface)
            {
                interfaceType = InterfaceType.LOOPBACK;
            }

            encapsulation = InterfaceEncapsulation.NONE;
            if (LibNLRoute3.rtnl_link_is_vlan(link) != 0)
            {
                encapsulation = InterfaceEncapsulation.DOT1Q;
                VLAN info = new VLAN((ushort) LibNLRoute3.rtnl_link_vlan_get_id(link));
                interfaceInformation = info;
            }
        }
    }
}