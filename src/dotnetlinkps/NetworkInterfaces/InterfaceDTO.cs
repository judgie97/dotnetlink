using System;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using dotnetlink;

namespace dotnetlinkps
{
    public class InterfaceDTO
    {
        public int Index { get; set; }
        public int ParentInterfaceIndex { get; set; }
        public String Name { get; set; }
        public PhysicalAddress HardwareAddress { get; set; }
        public InterfaceType Type { get; set; }
        public bool PromiscuousMode { get; set; }
        public InterfaceEncapsulation Encapsulation { get; set; }

        public InterfaceState State { get; set; }
    }
}