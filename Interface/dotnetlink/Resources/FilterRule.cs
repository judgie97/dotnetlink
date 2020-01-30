using System;
using System.Net;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace dotnetlink
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct NetlinkFilterRule
    {
        public uint id;
        public byte filterBySourceInterface;
        public int sourceInterface;
        public byte filterByDestinationInterface;
        public int destinationInterface;
        public byte filterBySourceAddress;
        public uint sourceAddress;
        public uint sourceAddressNetmask;
        public byte filterByDestinationAddress;
        public uint destinationAddress;
        public uint destinationAddressNetmask;
        public byte filterByProtocol;
        public byte protocol;
        public byte filterBySourcePort;
        public ushort sourcePort;
        public byte filterByDestinationPort;
        public ushort destinationPort;
        public byte action;
        public uint next;

        public FilterRule toFilterRule()
        {
            int? rSourceInterface = sourceInterface == 0 ? (int?) null : sourceInterface;
            int? rDestinationInterface = destinationInterface == 0 ? (int?) null : destinationInterface;

            IPAddress sourceIPAddress = null;
            if (filterBySourceAddress > 0)
                sourceIPAddress = new IPAddress(sourceAddress);

            IPAddress destinationIPAddress = null;
            if (filterByDestinationAddress > 0)
                destinationIPAddress = new IPAddress(destinationAddress);

            IPProtocol ipProtocol = IPProtocol.ANY;
            if (filterByProtocol > 0)
                ipProtocol = (IPProtocol) protocol;

            ushort sourceTransportPort = 0;
            if (filterBySourcePort > 0)
                sourceTransportPort = sourcePort;

            ushort destinationTransportPort = 0;
            if (filterByDestinationPort > 0)
                destinationTransportPort = destinationPort;

            return new FilterRule(rSourceInterface, rDestinationInterface, sourceIPAddress, sourceAddressNetmask,
                destinationIPAddress, destinationAddressNetmask, ipProtocol, sourceTransportPort,
                destinationTransportPort, (FilterAction) action, id, next);
        }
    }

    public class FilterRule
    {
        public uint id;
        public int? sourceInterface;
        public int? destinationInterface;
        public Subnet sourceSubnet;
        public Subnet destinationSubnet;
        public IPProtocol protocol;
        public ushort sourcePort;
        public ushort destinationPort;
        public FilterAction action;
        public uint next;

        public FilterRule()
        {
            sourceSubnet = null;
            destinationSubnet = null;
        }

        public FilterRule(int? sourceInterface, int? destinationInterface, IPAddress sourceAddress, uint sourceNetmask,
            IPAddress destinationAddress, uint destinationNetmask, IPProtocol protocol, ushort sourcePort,
            ushort destinationPort,
            FilterAction action, uint id, uint next)
        {
            this.sourceInterface = sourceInterface;
            this.destinationInterface = destinationInterface;
            this.sourceSubnet = new Subnet(sourceAddress, sourceNetmask);
            this.destinationSubnet = new Subnet(destinationAddress, destinationNetmask);
            this.protocol = protocol;
            this.sourcePort = sourcePort;
            this.destinationPort = destinationPort;
            this.action = action;
            this.id = id;
            this.next = next;
        }
    }
}