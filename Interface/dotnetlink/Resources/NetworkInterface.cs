using System;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace dotnetlink
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public unsafe struct NetlinkInterface
    {
        public uint index;
        public uint parentIndex;
        public fixed byte hardwareAddress[6];
        public fixed byte interfaceName[21];
        public byte isUp;
        public byte isBroadcastInterface;
        public byte isLoopbackInterface;
        public byte isPointToPointInterface;
        public byte isNBMAInterface;
        public byte isPromiscuousInterface;
        public byte interfaceType;
        public fixed byte interfaceInformation[4];

        public NetlinkInterface(NetworkInterface networkInterface)
        {
            index = networkInterface.index;
            parentIndex = networkInterface.parentInterfaceIndex;
            
            for (int i = 0; i < 6; i++)
            {
                hardwareAddress[i] = networkInterface.hardwareAddress.GetAddressBytes()[i];
            }

            for (int i = 0; i < networkInterface.interfaceName.Length && i < 20; i++)
            {
                interfaceName[i] = (byte)networkInterface.interfaceName[i];
                interfaceName[i + 1] = 0;
            }

            isUp = networkInterface.isUp ? (byte)1 : (byte)0;
            isBroadcastInterface = networkInterface.isBroadcastInterface ? (byte)1 : (byte)0;
            isLoopbackInterface = networkInterface.isLoopbackInterface ? (byte)1 : (byte)0;
            isPointToPointInterface = networkInterface.isPointToPointInterface ? (byte)1 : (byte)0;
            isNBMAInterface = networkInterface.isNBMAInterface ? (byte)1 : (byte)0;
            isPromiscuousInterface = networkInterface.isPromiscuousInterface ? (byte)1 : (byte)0;
            interfaceType = (byte) networkInterface.interfaceType;

            if (networkInterface.interfaceType == InterfaceType.PHYSICAL)
            {
            }
            else if (networkInterface.interfaceType == InterfaceType.LOOPBACK)
            {
                
            }
            else if (networkInterface.interfaceType == InterfaceType.DOT1Q)
            {
                VLAN vlanInfo = (VLAN) networkInterface.interfaceInformation;
                fixed (byte* b = interfaceInformation)
                {
                    *(uint*) b = vlanInfo.vlanID;
                }
            }
            else
            {
                throw new InvalidEnumArgumentException("Unknown Interface Type");
            }
        }

        public NetworkInterface toNetworkInterface()
        {
            byte[] hwa = new byte[6]
            {
                hardwareAddress[0], hardwareAddress[1], hardwareAddress[2], hardwareAddress[3], hardwareAddress[4],
                hardwareAddress[5]
            };
            int nameLength = 0;
            for (int i = 0; i < 21; i++)
            {
                if (interfaceName[i] == '\0')
                {
                    nameLength = i;
                    break;
                }
            }

            char[] name = new char[nameLength];
            for (int i = 0; i < nameLength; i++)
            {
                name[i] = (char)interfaceName[i];
            }

            Object interfaceInformation = null;
            
            if (interfaceType == (byte) InterfaceType.DOT1Q)
            {
                VLAN vlan = new VLAN();
                fixed (NetlinkInterface* nli = &this){
                    vlan.vlanID = *(uint*) nli->interfaceInformation;
                }

                interfaceInformation = vlan;
            }


            return new NetworkInterface(index, parentIndex, new String(name), new PhysicalAddress(hwa), isUp > 0,
                isBroadcastInterface > 0, isLoopbackInterface > 0, isPointToPointInterface > 0, isNBMAInterface > 0,
                isPromiscuousInterface > 0, (InterfaceType)interfaceType, interfaceInformation);
        }
    }

    public class NetworkInterface
    {
        public uint index;
        public uint parentInterfaceIndex;
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

        public NetworkInterface(uint index, uint parentInterfaceIndex, String interfaceName, PhysicalAddress hardwareAddress, bool isUp,
            bool isBroadcastInterface,
            bool isLoopbackInterface, bool isPointToPointInterface, bool isNBMAInterface, bool isPromiscuousInterface, InterfaceType interfaceType, Object interfaceInformation)
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
    }
    
    
}