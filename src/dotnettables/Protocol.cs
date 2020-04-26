using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace dotnettables
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Protocol
    {
        [EnumMember(Value = "tcp")]
        TCP,
        [EnumMember(Value = "udp")]
        UDP,
        [EnumMember(Value = "icmp")]
        ICMP
    }
}