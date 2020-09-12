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
            var networkInterface = interfaces.FirstOrDefault(i => i.Index == nicIndex);
            if (networkInterface == null)
                return null;
            var parent = networkInterface.ParentInterfaceIndex == 0
                ? null
                : ConvertToDto(networkInterface.ParentInterfaceIndex, interfaces);

            return new InterfaceDto()
            {
                Index = networkInterface.Index,
                ParentInterface = parent,
                Name = networkInterface.InterfaceName,
                HardwareAddress = networkInterface.HardwareAddress,
                PromiscuousMode = networkInterface.IsPromiscuousInterface,
                Type = networkInterface.InterfaceType,
                State = networkInterface.IsUp ? InterfaceState.UP : InterfaceState.DOWN,
                LowerUp = networkInterface.IsLowerLayerUp,
                VlanId = networkInterface.InterfaceType == InterfaceType.VLAN
                    ? ((Vlan) networkInterface.InterfaceInformation).VlanId
                    : (ushort?) null
            };
        }
    }
}