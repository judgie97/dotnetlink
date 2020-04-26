using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace dotnettables.Statements
{
    [JsonConverter(typeof(DropStatementSerializer))]
    public class DropStatement : IStatement
    {
        public override string ToString()
        {
            return "drop";
        }
    }
    
    public class DropStatementSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var statement = value as AcceptStatement;
            
            writer.WriteStartObject();
            writer.WritePropertyName("drop");
            serializer.Serialize(writer, null);
            writer.WriteEndObject();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            string schemaJson = "{\"type\": \"object\",\"properties\": {\"drop\": {\"type\": \"null\"}},\"required\": [\"drop\"]}";
            JSchema schema = JSchema.Parse(schemaJson);

            
            JObject dropWrapper = JObject.Load(reader);
            if (dropWrapper.IsValid(schema))
            {
                return new DropStatement();
            }
            
            throw new JSchemaException("JSON does not represent a valid DropStatement object");
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(DropStatement).IsAssignableFrom(objectType);
        }
    }
}