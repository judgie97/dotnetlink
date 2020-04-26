using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace dotnettables.Matches
{
    [JsonConverter(typeof(PortMatchSerializer))]
    public class PortMatch : IMatch
    {
        public bool source;
        public ushort port;
        public Protocol protocol;

        public override string ToString()
        {        
            string portType = source ? "sport" : "dport";
            return protocol + " " + portType + " == " + port;
        }

        public PortMatch(ushort port, Protocol protocol, bool source = false)
        {
            if(protocol != Protocol.TCP && protocol != Protocol.UDP)
                throw new Exception("Port Match does not support " + protocol);
            this.port = port;
            this.protocol = protocol;
            this.source = source;
        }
    }

    public class PortMatchSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var match = value as PortMatch;
            
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
                        serializer.Serialize(writer, match.protocol);
                        writer.WritePropertyName("field");
                        serializer.Serialize(writer, match.source ? "sport" : "dport");
                        writer.WriteEndObject();
                    }
                    writer.WriteEndObject();
                }
                writer.WritePropertyName("right");
                serializer.Serialize(writer, match.port);
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            string schemaJson =
                "{\"type\": \"object\",\"properties\": {\"match\": {\"type\": \"object\",\"properties\": {\"op\": {\"type\": \"string\",\"enum\": [\"==\"]},\"left\": {\"type\": \"object\",\"properties\": {\"payload\": {\"type\": \"object\",\"properties\": {\"protocol\": {\"type\": \"string\",\"enum\": [\"tcp\",\"udp\"]},\"field\": {\"type\": \"string\",\"enum\": [\"sport\",\"dport\"]}},\"required\": [\"protocol\",\"field\"]}},\"required\": [\"payload\"]},\"right\": {\"type\": \"integer\"}},\"required\": [\"op\",\"left\",\"right\"]}},\"required\": [\"match\"]}";
            JSchema schema = JSchema.Parse(schemaJson);

            
            JObject portMatch = JObject.Load(reader);
            if (portMatch.IsValid(schema))
            {
                Protocol protocol = portMatch["match"]["left"]["payload"]["protocol"].ToObject<Protocol>();
                bool source = portMatch["match"]["left"]["payload"]["field"].ToString() == "sport";
                ushort port = portMatch["match"]["right"].ToObject<ushort>() ;

                return new PortMatch(port, protocol, source);
            }
            
            throw new JSchemaException("JSON does not represent a valid PortMatch object");
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(PortMatch).IsAssignableFrom(objectType);
        }
    }
}