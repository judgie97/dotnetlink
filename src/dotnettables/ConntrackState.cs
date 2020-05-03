using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace dotnettables
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConntrackState
    {
        [EnumMember(Value = "invalid")] INVALID,
        [EnumMember(Value = "established")] ESTABLISHED,
        [EnumMember(Value = "related")] RELATED,
        [EnumMember(Value = "new")] NEW,
        [EnumMember(Value = "ingress")] UNTRACKED
    }
}