using System;
using dotnettables.Statements;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace dotnettables.Matches
{
    [JsonConverter(typeof(IPVersionMatchSerializer))]
    public class IPVersionMatch : IMatch
    {
        public byte version;

        public override string ToString()
        {
            return "ip version == " + version;
        }

        public IPVersionMatch(byte version)
        {
            if(version != 4 && version != 6)
                throw new ArgumentException("Only IPv4 and IPv6 are supported");
            this.version = version;
        }
    }
    
    public class IPVersionMatchSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var match = value as IPVersionMatch;
            
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
                        serializer.Serialize(writer, "ip");
                        writer.WritePropertyName("field");
                        serializer.Serialize(writer, "version");
                        writer.WriteEndObject();
                    }
                    writer.WriteEndObject();
                }
                writer.WritePropertyName("right");
                serializer.Serialize(writer, match.version);
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JSchema schema = JSchema.Parse(JsonSchema.IPVersionMatchSchema);

            
            JObject ipVersionMatch = JObject.Load(reader);
            if (ipVersionMatch.IsValid(schema))
            {
                byte version = ipVersionMatch["match"]["right"].ToObject<byte>();
                return new IPVersionMatch(version);
            }
            
            throw new JSchemaException("JSON does not represent a valid IPVersionMatch object");
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IPVersionMatch).IsAssignableFrom(objectType);
        }
    }
}