using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace dotnettables
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Hook
    {
        [EnumMember(Value = "ingress")] INGRESS,
        [EnumMember(Value = "prerouting")] PREROUTING,
        [EnumMember(Value = "input")] INPUT,
        [EnumMember(Value = "forward")] FORWARD,
        [EnumMember(Value = "output")] OUTPUT,
        [EnumMember(Value = "postrouting")] POSTROUTING
    }
}