using System;
using System.Collections.Generic;
using dotnettables.Matches;
using dotnettables.Statements;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace dotnettables
{
    [JsonConverter(typeof(ExpressionSerializer))]
    public class Expression
    {
        public List<IMatch> matches;
        public List<IStatement> statements;

        public override string ToString()
        {
            string output = "";
            foreach (var m in matches)
            {
                if (output != "")
                    output += " && ";
                output += m.ToString();
            }
            foreach (var s in statements)
            {
                if (output != "")
                    output += " then ";
                output += s.ToString();
            }
            return output;
        }

        public Expression()
        {
            matches = new List<IMatch>();
            statements = new List<IStatement>();
        }

        public void AddMatch(IMatch match)
        {
            matches.Add(match);
        }
        
        public void AddStatement(IStatement statement)
        {
            statements.Add(statement);
        }
    }
    
    public class ExpressionSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var expression = value as Expression;
            
            writer.WriteStartArray();
            foreach (var match in expression.matches)
            {
                serializer.Serialize(writer, match);
            }
            foreach (var statement in expression.statements)
            {
                serializer.Serialize(writer, statement);
            }
            writer.WriteEndArray();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JObject o = JObject.Load(reader);
            Expression expression = new Expression();
            JArray a = o["expr"] as JArray;
            foreach (var t in a)
            {
                if (t["accept"] != null)
                {
                    expression.AddStatement(t.ToObject<AcceptStatement>());
                    continue;
                }
                if (t["drop"] != null)
                {
                    expression.AddStatement(t.ToObject<DropStatement>());
                    continue;
                }
                if (t["match"] != null)
                {
                    JObject match = t as JObject;
                    try
                    {
                        expression.AddMatch(match.ToObject<IPVersionMatch>());
                        continue;
                    }
                    catch (JSchemaException e)
                    {
                    }
                    try
                    {
                        expression.AddMatch(match.ToObject<ProtocolMatch>());
                        continue;
                    }
                    catch (JSchemaException e)
                    {
                    }
                    try
                    {
                        expression.AddMatch(match.ToObject<PortMatch>());
                        continue;
                    }
                    catch (JSchemaException e)
                    {
                    }
                    try
                    {
                        expression.AddMatch(match.ToObject<ICMPTypeMatch>());
                        continue;
                    }
                    catch (JSchemaException e)
                    {
                    }
                    try
                    {
                        expression.AddMatch(match.ToObject<IPAddressMatch>());
                        continue;
                    }
                    catch (JSchemaException e)
                    {
                    }
                    throw new NotSupportedException("Unknown Match");
                }
                throw new NotSupportedException("Unknown Statement");
            }
            return expression;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Expression).IsAssignableFrom(objectType);
        }
    }
}