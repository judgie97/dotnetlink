using System;
using dotnettables.Matches;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace test.dotnettables.Matches
{
    [TestFixture]
    public class ICMPTypeMatchTests
    {
        [Test]
        public void ToStringConversion()
        {
            ICMPTypeMatch match = new ICMPTypeMatch(4);
            Assert.AreEqual("icmp type == 4", match.ToString());
        }
        
        [Test]
        public void Deserialize()
        {
            string json = "{\"match\":{\"op\":\"==\",\"left\":{\"payload\":{\"protocol\":\"icmp\",\"field\":\"type\"}},\"right\":4}}";

            ICMPTypeMatch val = JsonConvert.DeserializeObject<ICMPTypeMatch>(json);
            Assert.NotNull(val);
            Assert.AreEqual(4, val.type);
        }
        
        [Test]
        public void DeserializeInvalidJson()
        {
            string json = "{\"match\":{\"op\":\"<\",\"left\":{\"payload\":{\"protocol\":\"icmp\",\"field\":\"type\"}},\"right\":4}}";
            
            Exception e = Assert.Throws(typeof(JSchemaException), () => JsonConvert.DeserializeObject<ICMPTypeMatch>(json));
            Assert.AreEqual("JSON does not represent a valid ICMPTypeMatch object", e.Message);
        }
        
        [Test]
        public void Serialize()
        {
            ICMPTypeMatch icmpTypeMatch = new ICMPTypeMatch(4);
            string ret = JsonConvert.SerializeObject(icmpTypeMatch);
            
            string json = "{\"match\":{\"op\":\"==\",\"left\":{\"payload\":{\"protocol\":\"icmp\",\"field\":\"type\"}},\"right\":4}}";
            Assert.AreEqual(json, ret);
        }
    }
}