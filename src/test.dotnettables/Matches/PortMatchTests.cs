using System;
using dotnettables;
using dotnettables.Matches;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace test.dotnettables.Matches
{
    [TestFixture]
    public class PortMatchTests
    {
        [Test]
        public void ToStringConversionTcpSource()
        {
            PortMatch portMatch = new PortMatch(8080, Protocol.TCP, true);
            Assert.AreEqual("TCP sport == 8080", portMatch.ToString());
        }
        
        [Test]
        public void ToStringConversionTcpDestination()
        {
            PortMatch portMatch = new PortMatch(8080, Protocol.TCP, false);
            Assert.AreEqual("TCP dport == 8080", portMatch.ToString());
        }
        
        [Test]
        public void ToStringConversionUdpSource()
        {
            PortMatch portMatch = new PortMatch(8080, Protocol.UDP, true);
            Assert.AreEqual("UDP sport == 8080", portMatch.ToString());
        }
        
        [Test]
        public void ToStringConversionUdpDestination()
        {
            PortMatch portMatch = new PortMatch(8080, Protocol.UDP, false);
            Assert.AreEqual("UDP dport == 8080", portMatch.ToString());
        }
        
        [Test]
        public void DeserializeSource()
        {
            string json = "{\"match\":{\"op\":\"==\",\"left\":{\"payload\":{\"protocol\":\"tcp\",\"field\":\"sport\"}},\"right\":1729}}";

            PortMatch val = JsonConvert.DeserializeObject<PortMatch>(json);
            Assert.NotNull(val);
            Assert.AreEqual(1729, val.port);
            Assert.AreEqual(Protocol.TCP, val.protocol);
            Assert.AreEqual(true, val.source);
        }
        
        [Test]
        public void DeserializeDestination()
        {
            string json = "{\"match\":{\"op\":\"==\",\"left\":{\"payload\":{\"protocol\":\"tcp\",\"field\":\"dport\"}},\"right\":1729}}";

            PortMatch val = JsonConvert.DeserializeObject<PortMatch>(json);
            Assert.NotNull(val);
            Assert.AreEqual(1729, val.port);
            Assert.AreEqual(Protocol.TCP, val.protocol);
            Assert.AreEqual(false, val.source);
        }
        
        [Test]
        public void DeserializeInvalidJson()
        {
            string json = "{\"match\":{\"op\":\"<\",\"left\":{\"payload\":{\"protocol\":\"tcp\",\"field\":\"sport\"}},\"right\":1729}}";
            
            Exception e = Assert.Throws(typeof(JSchemaException), () => JsonConvert.DeserializeObject<PortMatch>(json));
            Assert.AreEqual("JSON does not represent a valid PortMatch object", e.Message);
        }
        
        [Test]
        public void Serialize()
        {
            PortMatch portMatch = new PortMatch(1729, Protocol.TCP, true);
            string ret = JsonConvert.SerializeObject(portMatch);
            
            string json = "{\"match\":{\"op\":\"==\",\"left\":{\"payload\":{\"protocol\":\"tcp\",\"field\":\"sport\"}},\"right\":1729}}";
            Assert.AreEqual(json, ret);
        }
    }
}