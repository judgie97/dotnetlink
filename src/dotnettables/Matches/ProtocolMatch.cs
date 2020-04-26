using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace dotnettables.Matches
{
    [JsonConverter(typeof(ProtocolMatchSerializer))]
    public class ProtocolMatch : IMatch
    {
        public Protocol protocol;

        public override string ToString()
        {
            return "protocol == " + protocol;
        }

        public ProtocolMatch(Protocol protocol)
        {
            this.protocol = protocol;
        }
    }
    
    public class ProtocolMatchSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var match = value as ProtocolMatch;
            
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
                        serializer.Serialize(writer, "protocol");
                        writer.WriteEndObject();
                    }
                    writer.WriteEndObject();
                }
                writer.WritePropertyName("right");
                serializer.Serialize(writer, match.protocol);
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            string schemaJson =
                "{\"type\" : \"object\",\"properties\" : {\"match\": {\"type\" : \"object\",\"properties\" : {\"op\" : {\"type\" : \"string\",\"enum\": [\"==\"]},\"left\" : {\"type\" : \"object\",\"properties\": {\"payload\" : {\"type\" : \"object\",\"properties\": {\"protocol\" : {\"type\" : \"string\",\"enum\": [\"ip\"]},\"field\" : {\"type\" : \"string\",\"enum\" : [\"protocol\"]}},\"required\": [\"protocol\", \"field\"]}},\"required\" : [\"payload\"]},\"right\" : {\"type\":\"string\",\"enum\": [\"tcp\", \"udp\", \"icmp\"]}},\"required\" : [\"op\", \"left\", \"right\"]}},\"required\" : [\"match\"]}";
            
            JSchema schema = JSchema.Parse(schemaJson);

            
            JObject ProtocolMatch = JObject.Load(reader);
            if (ProtocolMatch.IsValid(schema))
            {
                Protocol protocol = ProtocolMatch["match"]["right"].ToObject<Protocol>();
                return new ProtocolMatch(protocol);
            }
            
            throw new JSchemaException("JSON does not represent a valid ProtocolMatch object");
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ProtocolMatch).IsAssignableFrom(objectType);
        }
    }
}