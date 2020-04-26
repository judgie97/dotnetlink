using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace dotnettables.Matches
{
  [JsonConverter(typeof(IPAddressMatchSerializer))]
    public class IPAddressMatch : IMatch
    {
      public IPAddress address;
      public bool source;
      public byte ipVersion;

      public override string ToString()
      {
        string addr = source ? "saddr" : "daddr";
        return "IPv" + ipVersion + " " + addr + " == " + address.ToString();
      }

      public IPAddressMatch(IPAddress address, bool source = false)
      {
        this.address = address;
        this.source = source;
        ipVersion = (byte)(address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork ? 4 : 6);
      }
    }
    
    public class IPAddressMatchSerializer : JsonConverter
    {
      public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
      {
        var match = value as IPAddressMatch;
            
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
              serializer.Serialize(writer, match.ipVersion == 6 ? "ip6" : "ip");
              writer.WritePropertyName("field");
              serializer.Serialize(writer, match.source ? "saddr" : "daddr");
              writer.WriteEndObject();
            }
            writer.WriteEndObject();
          }
          writer.WritePropertyName("right");
          serializer.Serialize(writer, match.address.ToString());
          writer.WriteEndObject();
        }
        writer.WriteEndObject();
      }

      public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
      {
        string schemaJson =
          "{\"type\": \"object\",\"properties\": {\"match\": {\"type\": \"object\",\"properties\": {\"op\": {\"type\": \"string\",\"enum\": [\"==\"]},\"left\": {\"type\": \"object\",\"properties\": {\"payload\": {\"type\": \"object\",\"properties\": {\"protocol\": {\"type\": \"string\",\"enum\": [\"ip\"]},\"field\": {\"type\": \"string\",\"enum\": [\"saddr\",\"daddr\"]}},\"required\": [\"protocol\",\"field\"]}},\"required\": [\"payload\"]},\"right\": {\"type\": \"string\"}},\"required\": [\"op\",\"left\",\"right\"]}},\"required\": [\"match\"]}";
        JSchema schema = JSchema.Parse(schemaJson);

            
        JObject ipAddressMatch = JObject.Load(reader);
        if (ipAddressMatch.IsValid(schema))
        {
          bool source = ipAddressMatch["match"]["left"]["payload"]["field"].ToString() == "saddr";
          IPAddress address = IPAddress.Parse(ipAddressMatch["match"]["right"].ToString());

          return new IPAddressMatch(address, source);
        }
            
        throw new JSchemaException("JSON does not represent a valid IPAddressMatch object");
      }

      public override bool CanConvert(Type objectType)
      {
        return typeof(IPAddressMatch).IsAssignableFrom(objectType);
      }
    }
}