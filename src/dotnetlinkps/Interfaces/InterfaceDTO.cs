using System;
using System.Linq;
using System.Net.NetworkInformation;
using dotnetlink;
using NetworkInterface = dotnetlink.NetworkInterface;

namespace dotnetlinkps.Interfaces
{
    public class InterfaceDto
    {
        public int Index { get; set; }
        public InterfaceDto ParentInterface { get; set; }
        public String Name { get; set; }
        public PhysicalAddress HardwareAddress { get; set; }
        public InterfaceType Type { get; set; }
        public bool PromiscuousMode { get; set; }
        public InterfaceState State { get; set; }

        public bool LowerUp { get; set; }

        public ushort? VlanId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public static class InterfaceDtoUtil
    {
        public static InterfaceDto ConvertToDto(int nicIndex, NetworkInterface[] interfaces)
        {
            var networkInterface = interfaces.FirstOrDefault(i => i.index == nicIndex);
            if (networkInterface == null)
                return null;
            var parent = networkInterface.parentInterfaceIndex == 0
                ? null
                : ConvertToDto(networkInterface.parentInterfaceIndex, interfaces);

            return new InterfaceDto()
            {
                Index = networkInterface.index,
                ParentInterface = parent,
                Name = networkInterface.interfaceName,
                HardwareAddress = networkInterface.hardwareAddress,
                PromiscuousMode = networkInterface.isPromiscuousInterface,
                Type = networkInterface.interfaceType,
                State = networkInterface.isUp ? InterfaceState.UP : InterfaceState.DOWN,
                LowerUp = networkInterface.isLowerLayerUp,
                VlanId = networkInterface.interfaceType == InterfaceType.VLAN
                    ? ((VLAN) networkInterface.interfaceInformation).vlanID
                    : (ushort?) null
            };
        }
    }
}