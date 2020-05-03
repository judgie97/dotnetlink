using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace dotnettables.Matches
{
    [JsonConverter(typeof(ConntrackStateMatchSerializer))]
    public class ConntrackStateMatch : IMatch
    {
        public ConntrackState State;

        public override string ToString()
        {
            return "ct_state == " + State;
        }

        public ConntrackStateMatch(ConntrackState State)
        {
            this.State = State;
        }
    }

    public class ConntrackStateMatchSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var match = value as ConntrackStateMatch;
            
            writer.WriteStartObject();
            writer.WritePropertyName("match");
            {
                writer.WriteStartObject();
                writer.WritePropertyName("op");
                serializer.Serialize(writer, "==");
                writer.WritePropertyName("left");
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("ct");
                    {
                        writer.WriteStartObject();
                        writer.WritePropertyName("key");
                        serializer.Serialize(writer, "state");
                        writer.WriteEndObject();
                    }
                    writer.WriteEndObject();
                }
                writer.WritePropertyName("right");
                serializer.Serialize(writer, match.State);
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JSchema schema = JSchema.Parse(JsonSchema.ConntrackSchema);

            JObject conntrackStateMatch = JObject.Load(reader);
            if (conntrackStateMatch.IsValid(schema))
            {
                ConntrackState state = conntrackStateMatch["match"]["right"].ToObject<ConntrackState>();

                return new ConntrackStateMatch(state);
            }
            
            throw new JSchemaException("JSON does not represent a valid ConntrackStateMatch object");
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ConntrackStateMatch).IsAssignableFrom(objectType);
        }
    }
}