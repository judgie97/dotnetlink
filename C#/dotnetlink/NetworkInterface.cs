using System;
using System.Net.NetworkInformation;

namespace dotnetlink
{
    public unsafe struct NetlinkInterface
    {
        public uint index;
        public fixed byte hardwareAddress[6];
        public fixed byte interfaceName[21];
        public byte isUp;
        public byte isBroadcastInterface;
        public byte isLoopbackInterface;
        public byte isPointToPointInterface;
        public byte isNBMAInterface;
        public byte isPromiscuousInterface;

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

            return new NetworkInterface(index, new String(name), new PhysicalAddress(hwa), isUp > 0,
                isBroadcastInterface > 0, isLoopbackInterface > 0, isPointToPointInterface > 0, isNBMAInterface > 0,
                isPromiscuousInterface > 0);
        }
    }

    public class NetworkInterface
    {
        public uint index;
        public String interfaceName;
        public PhysicalAddress hardwareAddress;
        public bool isUp;
        public bool isBroadcastInterface;
        public bool isLoopbackInterface;
        public bool isPointToPointInterface;
        public bool isNBMAInterface;
        public bool isPromiscuousInterface;

        public NetworkInterface(uint index, String interfaceName, PhysicalAddress hardwareAddress, bool isUp,
            bool isBroadcastInterface,
            bool isLoopbackInterface, bool isPointToPointInterface, bool isNBMAInterface, bool isPromiscuousInterface)
        {
            this.index = index;
            this.interfaceName = interfaceName;
            this.hardwareAddress = hardwareAddress;
            this.isUp = isUp;
            this.isBroadcastInterface = isBroadcastInterface;
            this.isLoopbackInterface = isLoopbackInterface;
            this.isPointToPointInterface = isPointToPointInterface;
            this.isNBMAInterface = isNBMAInterface;
            this.isPromiscuousInterface = isPromiscuousInterface;
        }
    }
}