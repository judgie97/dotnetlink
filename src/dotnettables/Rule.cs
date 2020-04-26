using System;
using System.Collections.Generic;
using dotnettables.Matches;
using dotnettables.Statements;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dotnettables
{
    [JsonConverter(typeof(RuleSerializer))]
    public class Rule
    {
        public AddressFamily family;
        public uint handle;
        public Expression expression;
        public Chain? chain;

        public override string ToString()
        {
            return expression.ToString();
        }

        public Rule(AddressFamily family, uint handle, Expression? expression)
        {
            this.family = family;
            this.handle = handle;
            this.expression = expression ?? new Expression();
            chain = null;
        }

        public void SetChain(Chain chain)
        {
            this.chain = chain;
        }
    }
    
    public class RuleSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var rule = value as Rule;
            writer.WriteStartObject();
            writer.WritePropertyName("rule");
            {
                writer.WriteStartObject();
                writer.WritePropertyName("family");
                serializer.Serialize(writer, rule.family);
                writer.WritePropertyName("table");
                serializer.Serialize(writer, rule.chain.table.name);
                writer.WritePropertyName("chain");
                serializer.Serialize(writer, rule.chain.name);
                writer.WritePropertyName("handle");
                serializer.Serialize(writer, rule.handle);
                writer.WritePropertyName("family");
                serializer.Serialize(writer, rule.family);
                writer.WritePropertyName("expr");
                serializer.Serialize(writer, rule.expression);
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
            JsonSerializer serializer)
        {
            JObject chainWrapper = JObject.Load(reader);
            JToken o = chainWrapper["rule"];
            
            AddressFamily family =
                (AddressFamily) Enum.Parse(typeof(AddressFamily), o["family"].Value<string>().ToUpper());
            uint handle = o["handle"].Value<uint>();

            Expression e = o.ToObject<Expression>();

            return new Rule(family, handle, e);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Rule).IsAssignableFrom(objectType);
        }
    }
}