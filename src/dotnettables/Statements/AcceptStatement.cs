using System;
using dotnettables.Matches;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace dotnettables.Statements
{
    [JsonConverter(typeof(AcceptStatementSerializer))]
    public class AcceptStatement : IStatement
    {
        public override string ToString()
        {
            return "accept";
        }
    }
    
    public class AcceptStatementSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var statement = value as AcceptStatement;
            
            writer.WriteStartObject();
            writer.WritePropertyName("accept");
            serializer.Serialize(writer, null);
            writer.WriteEndObject();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JSchema schema = JSchema.Parse(JsonSchema.AcceptStatementSchema);
            
            JObject acceptWrapper = JObject.Load(reader);
            if (acceptWrapper.IsValid(schema))
            {
                return new AcceptStatement();
            }
            
            throw new JSchemaException("JSON does not represent a valid AcceptStatement object");
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(AcceptStatement).IsAssignableFrom(objectType);
        }
    }
}