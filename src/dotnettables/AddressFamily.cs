using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace dotnettables
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AddressFamily
    {
        [EnumMember(Value = "ip")] IP,
        [EnumMember(Value = "ip6")] IP6,
        [EnumMember(Value = "inet")] INET,
        [EnumMember(Value = "arp")] ARP,
        [EnumMember(Value = "bridge")] BRIDGE,
        [EnumMember(Value = "netdev")] NETDEV
    }

}