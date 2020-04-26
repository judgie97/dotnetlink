using System;
using dotnettables;
using dotnettables.Matches;
using dotnettables.Statements;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace test.dotnettables.Matches
{
    [TestFixture]
    public class IPVersionMatchTests
    {
        [Test]
        public void ToStringConversionIPv4()
        {
            IPVersionMatch ipv4 = new IPVersionMatch(4);
            Assert.AreEqual("ip version == 4", ipv4.ToString());
        }
        
        [Test]
        public void ToStringConversionIPv6()
        {
            IPVersionMatch ipv6 = new IPVersionMatch(6);
            Assert.AreEqual("ip version == 6", ipv6.ToString());
        }
        
        [Test]
        public void ContructorWithInvalidArgument()
        {
            Exception e = Assert.Throws(typeof(ArgumentException), () => new IPVersionMatch(5));
            Assert.AreEqual("Only IPv4 and IPv6 are supported", e.Message);
        }
        
        [Test]
        public void Deserialize()
        {
            string json = "{\"match\":{\"op\":\"==\",\"left\":{\"payload\":{\"protocol\":\"ip\",\"field\":\"version\"}},\"right\":4}}";

            IPVersionMatch val = JsonConvert.DeserializeObject<IPVersionMatch>(json);
            Assert.NotNull(val);
            Assert.AreEqual(4, val.version);
        }
        
        [Test]
        public void DeserializeInvalidJson()
        {
            string json = "{\"match\":{\"op\":\"<\",\"left\":{\"payload\":{\"protocol\":\"ip\",\"field\":\"version\"}},\"right\":4}}";
            
            Exception e = Assert.Throws(typeof(JSchemaException), () => JsonConvert.DeserializeObject<IPVersionMatch>(json));
            Assert.AreEqual("JSON does not represent a valid IPVersionMatch object", e.Message);
        }
        
        [Test]
        public void Serialize()
        {
            IPVersionMatch ipVersionMatch = new IPVersionMatch(4);
            string ret = JsonConvert.SerializeObject(ipVersionMatch);
            
            string json = "{\"match\":{\"op\":\"==\",\"left\":{\"payload\":{\"protocol\":\"ip\",\"field\":\"version\"}},\"right\":4}}";
            Assert.AreEqual(json, ret);
        }
    }
}