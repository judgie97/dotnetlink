using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace dotnettables
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChainType
    {
        [EnumMember(Value = "filter")] FILTER,
        [EnumMember(Value = "nat")] NAT,
        [EnumMember(Value = "route")] ROUTE
    }
}