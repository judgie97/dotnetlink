using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dotnettables
{
    [JsonConverter(typeof(ChainSerializer))]
    public class Chain
    {
        public AddressFamily family;
        public string name;
        public uint handle;
        public ChainType type;
        public Hook hook;
        public int priority;
        public Policy policy;
        public Table? table;

        public List<Rule> rules;

        public override string ToString()
        {
            return name;
        }

        public Chain(string name, AddressFamily family, Policy policy, ChainType type, Hook hook, int priority,
            uint handle = 0)
        {
            this.name = name;
            this.family = family;
            this.policy = policy;
            this.type = type;
            this.hook = hook;
            this.priority = priority;
            this.handle = handle;
            table = null;

            rules = new List<Rule>();
        }

        public void AddRule(Rule rule)
        {
            //TODO Validate the rule is suitable for this chain

            rules.Add(rule);
            rule.SetChain(this);
        }

        public void SetTable(Table table)
        {
            this.table = table;
        }
    }

    public class ChainSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var chain = value as Chain;
            writer.WriteStartObject();
            writer.WritePropertyName("chain");
            {
                writer.WriteStartObject();
                writer.WritePropertyName("family");
                serializer.Serialize(writer, chain.family);
                writer.WritePropertyName("table");
                serializer.Serialize(writer, chain.table.name);
                writer.WritePropertyName("name");
                serializer.Serialize(writer, chain.name);
                writer.WritePropertyName("handle");
                serializer.Serialize(writer, chain.handle);
                writer.WritePropertyName("type");
                serializer.Serialize(writer, chain.type);
                writer.WritePropertyName("hook");
                serializer.Serialize(writer, chain.hook);
                writer.WritePropertyName("prio");
                serializer.Serialize(writer, chain.priority);
                writer.WritePropertyName("policy");
                serializer.Serialize(writer, chain.policy);
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
            foreach (var rule in chain.rules)
            {
                serializer.Serialize(writer, rule);
            }
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
            JsonSerializer serializer)
        {
            JObject chainWrapper = JObject.Load(reader);
            JToken o = chainWrapper["chain"];
            
            string name = o["name"].Value<string>();
            AddressFamily family =
                (AddressFamily) Enum.Parse(typeof(AddressFamily), o["family"].Value<string>().ToUpper());
            uint handle = o["handle"].Value<uint>();
            Policy policy = (Policy) Enum.Parse(typeof(Policy), o["policy"].Value<string>().ToUpper());
            ChainType chainType = (ChainType) Enum.Parse(typeof(ChainType), o["type"].Value<string>().ToUpper());
            Hook hook = (Hook) Enum.Parse(typeof(Hook), o["hook"].Value<string>().ToUpper());
            int priority = o["prio"].Value<int>();

            return new Chain(name, family, policy, chainType, hook, priority, handle);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Chain).IsAssignableFrom(objectType);
        }
    }
}