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
        public int index;
        public int parentInterfaceIndex;
        public String interfaceName;
        public PhysicalAddress hardwareAddress;
        public bool isUp;
        public bool isBroadcastInterface;
        public bool isLoopbackInterface;
        public bool isPointToPointInterface;
        public bool isNBMAInterface;
        public bool isPromiscuousInterface;
        public InterfaceType interfaceType;
        public Object interfaceInformation;

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
            interfaceName = Util.nativeToManagedString((sbyte*)LibNLRoute3.rtnl_link_get_name(link));
            
            nl_addr* hwAddr = LibNLRoute3.rtnl_link_get_addr(link);
            byte* mac = (byte*)LibNL3.nl_addr_get_binary_addr(hwAddr);
            byte[] macBytes = new byte[6];
            for (int i = 0; i < 6; i++)
            {
                macBytes[i] = mac[6];
            }
            hardwareAddress = new PhysicalAddress(macBytes);
            
            isUp = (LibNLRoute3.rtnl_link_get_flags(link) & 1 << 0) == 0;
            isBroadcastInterface = (LibNLRoute3.rtnl_link_get_flags(link) & 1 << 1) != 0;
            isLoopbackInterface = (LibNLRoute3.rtnl_link_get_flags(link) & 1 << 3) != 0;
            isPointToPointInterface = (LibNLRoute3.rtnl_link_get_flags(link) & 1 << 4) != 0;
            isNBMAInterface = !(isBroadcastInterface || isLoopbackInterface || isPointToPointInterface);
            isPromiscuousInterface = (LibNLRoute3.rtnl_link_get_flags(link) & 1 << 8) != 0;
            interfaceType = InterfaceType.PHYSICAL;
            if (isLoopbackInterface)
            {
                interfaceType = InterfaceType.LOOPBACK;
            }

            if (LibNLRoute3.rtnl_link_is_vlan(link) != 0)
            {
                interfaceType = InterfaceType.DOT1Q;
                VLAN info = new VLAN((ushort)LibNLRoute3.rtnl_link_vlan_get_id(link));
                interfaceInformation = info;
            }
        }
    }
}