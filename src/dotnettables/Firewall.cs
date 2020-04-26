using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dotnettables
{
    [JsonConverter(typeof(FirewallSerializer))]
    public class Firewall
    {
        public List<Table> tables;

        public Firewall()
        {
            tables = new List<Table>();
        }

        public void AddTable(Table table)
        {
            tables.Add(table);
        }

        public Table? GetTable(string tableName)
        {
            return tables.FirstOrDefault(t => t.name == tableName);
        }
    }

    public class FirewallSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var firewall = value as Firewall;
            writer.WriteStartObject();
            {
                writer.WritePropertyName("nftables");
                writer.WriteStartArray();
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("metainfo");
                    {
                        //{"version": "0.9.2", "release_name": "Scram", "json_schema_version": 1}
                        writer.WriteStartObject();
                        writer.WritePropertyName("version");
                        serializer.Serialize(writer, "0.9.2");
                        writer.WritePropertyName("release_name");
                        serializer.Serialize(writer, "Scram");
                        writer.WritePropertyName("json_schema_version");
                        serializer.Serialize(writer, 1);
                        writer.WriteEndObject();
                    }
                    writer.WriteEndObject();
                    foreach (var table in firewall.tables)
                    {
                        serializer.Serialize(writer, table);
                    }
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
            JsonSerializer serializer)
        {
            JObject o = JObject.Load(reader);

            Firewall f = new Firewall();
            JArray t = o["nftables"] as JArray;

            foreach (var token in t)
            {
                if (token["metainfo"] != null)
                {
                    //this is currently ignored.
                }

                if (token["table"] != null)
                {
                    Table table = token.ToObject<Table>();
                    f.AddTable(table);
                }

                if (token["chain"] != null)
                {
                    Chain chain = token.ToObject<Chain>();
                    f.GetTable(token["chain"]["table"].Value<string>()).AddChain(chain);
                }

                if (token["rule"] != null)
                {
                    Rule rule = token.ToObject<Rule>();
                    f.GetTable(token["rule"]["table"].Value<string>()).GetChain(token["rule"]["chain"].Value<string>())
                        .AddRule(rule);
                }
            }

            return f;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Firewall).IsAssignableFrom(objectType);
        }
    }
}