using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace dotnettables.Matches
{
    [JsonConverter(typeof(ICMPTypeMatchSerializer))]
    public class ICMPTypeMatch : IMatch
    {
        public byte type;

        public override string ToString()
        {
            return "icmp type == " + type;
        }

        public ICMPTypeMatch(byte type)
        {
            this.type = type;
        }
    }

    public class ICMPTypeMatchSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var match = value as ICMPTypeMatch;

            writer.WriteStartObject();
            writer.WritePropertyName("match");
            {
                writer.WriteStartObject();
                writer.WritePropertyName("op");
                serializer.Serialize(writer, "==");
                writer.WritePropertyName("left");
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("payload");
                    {
                        writer.WriteStartObject();
                        writer.WritePropertyName("protocol");
                        serializer.Serialize(writer, "icmp");
                        writer.WritePropertyName("field");
                        serializer.Serialize(writer, "type");
                        writer.WriteEndObject();
                    }
                    writer.WriteEndObject();
                }
                writer.WritePropertyName("right");
                serializer.Serialize(writer, match.type);
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
            JsonSerializer serializer)
        {
            JSchema schema = JSchema.Parse(JsonSchema.ICMPTypeSchema);

            
            JObject icmpTypeMatch = JObject.Load(reader);
            if (icmpTypeMatch.IsValid(schema))
            {
                byte type = icmpTypeMatch["match"]["right"].ToObject<byte>();
                return new ICMPTypeMatch(type);
            }
            
            throw new JSchemaException("JSON does not represent a valid ICMPTypeMatch object");
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ICMPTypeMatch).IsAssignableFrom(objectType);
        }
    }
}