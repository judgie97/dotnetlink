using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace dotnettables
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Policy
    {
        [EnumMember(Value = "accept")] ACCEPT,
        [EnumMember(Value = "drop")] DROP
    }
}