using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace dotnettables
{
    [JsonConverter(typeof(TableSerializer))]
    public class Table
    {
        public AddressFamily family;
        public string name;
        public uint handle;

        public List<Chain> chains;
        public override string ToString()
        {
            return name;
        }

        public Table(string name, AddressFamily family = AddressFamily.INET, uint handle = 0)
        {
            this.name = name;
            this.family = family;
            this.handle = handle;

            chains = new List<Chain>();
        }

        public void AddChain(Chain chain)
        {
            //TODO Validate chain is ok for this table
            chains.Add(chain);
            chain.SetTable(this);
        }

        public Chain? GetChain(string chainName)
        {
            return chains.FirstOrDefault(c => c.name == chainName);
        }

        public void RemoveChain(Chain chain)
        {
            int pos = chains.IndexOf(chain);
            if (pos != -1)
                chains.RemoveAt(pos);
            else
                throw new Exception("Chain does not exist in table");
        }
    }

    public class TableSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var table = value as Table;
            writer.WriteStartObject();
            writer.WritePropertyName("table");
            {
                writer.WriteStartObject();
                writer.WritePropertyName("family");
                serializer.Serialize(writer, table.family);
                writer.WritePropertyName("name");
                serializer.Serialize(writer, table.name);
                writer.WritePropertyName("handle");
                serializer.Serialize(writer, table.handle);
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
            foreach (var chain in table.chains)
            {
                serializer.Serialize(writer, chain);
            }
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
            JsonSerializer serializer)
        {
            JObject tableWrapper = JObject.Load(reader);
            JToken o = tableWrapper["table"];
            string name = o["name"].Value<string>();
            AddressFamily family =
                (AddressFamily) Enum.Parse(typeof(AddressFamily), o["family"].Value<string>().ToUpper());
            uint handle = o["handle"].Value<uint>();

            return new Table(name, family, handle);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Table).IsAssignableFrom(objectType);
        }
    }
}