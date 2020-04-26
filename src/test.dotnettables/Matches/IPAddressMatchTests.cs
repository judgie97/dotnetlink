using System;
using System.Net;
using dotnettables;
using dotnettables.Matches;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace test.dotnettables.Matches
{
    [TestFixture]
    public class IPAddressMatchTests
    {
        [Test]
        public void ToStringConversionIPv4Destination()
        {
            IPAddressMatch match = new IPAddressMatch(IPAddress.Parse("1.2.3.4"), false);
            Assert.AreEqual("IPv4 daddr == 1.2.3.4", match.ToString());
        }
        
        [Test]
        public void ToStringConversionIPv4Source()
        {
            IPAddressMatch match = new IPAddressMatch(IPAddress.Parse("1.2.3.4"), true);
            Assert.AreEqual("IPv4 saddr == 1.2.3.4", match.ToString());
        }
        
        [Test]
        public void DeserializeSource()
        {
            string json = "{\"match\":{\"op\":\"==\",\"left\":{\"payload\":{\"protocol\":\"ip\",\"field\":\"saddr\"}},\"right\":\"1.2.3.4\"}}";

            IPAddressMatch val = JsonConvert.DeserializeObject<IPAddressMatch>(json);
            Assert.NotNull(val);
            Assert.AreEqual(IPAddress.Parse("1.2.3.4"), val.address);
            Assert.AreEqual(4, val.ipVersion);
            Assert.AreEqual(true, val.source);
        }
        
        [Test]
        public void DeserializeDestination()
        {
            string json = "{\"match\":{\"op\":\"==\",\"left\":{\"payload\":{\"protocol\":\"ip\",\"field\":\"daddr\"}},\"right\":\"1.2.3.4\"}}";

            IPAddressMatch val = JsonConvert.DeserializeObject<IPAddressMatch>(json);
            Assert.NotNull(val);
            Assert.AreEqual(IPAddress.Parse("1.2.3.4"), val.address);
            Assert.AreEqual(4, val.ipVersion);
            Assert.AreEqual(false, val.source);
        }
        
        [Test]
        public void DeserializeInvalidJson()
        {
            string json = "{\"match\":{\"op\":\"<\",\"left\":{\"payload\":{\"protocol\":\"ip\",\"field\":\"saddr\"}},\"right\":\"1.2.3.4\"}}";
            
            Exception e = Assert.Throws(typeof(JSchemaException), () => JsonConvert.DeserializeObject<IPAddressMatch>(json));
            Assert.AreEqual("JSON does not represent a valid IPAddressMatch object", e.Message);
        }
        
        [Test]
        public void Serialize()
        {
            IPAddressMatch ipAddressMatch = new IPAddressMatch(IPAddress.Parse("1.2.3.4"), true);
            string ret = JsonConvert.SerializeObject(ipAddressMatch);
            
            string json = "{\"match\":{\"op\":\"==\",\"left\":{\"payload\":{\"protocol\":\"ip\",\"field\":\"saddr\"}},\"right\":\"1.2.3.4\"}}";
            Assert.AreEqual(json, ret);
        }
    }
}