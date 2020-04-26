using System;
using dotnettables;
using dotnettables.Matches;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace test.dotnettables.Matches
{
    [TestFixture]
    public class ProtocolMatchTests
    {
        [Test]
        public void ToStringTcp()
        {
            ProtocolMatch match = new ProtocolMatch(Protocol.TCP);
            Assert.AreEqual("protocol == TCP", match.ToString());
        }
        
        [Test]
        public void ToStringUDP()
        {
            ProtocolMatch match = new ProtocolMatch(Protocol.UDP);
            Assert.AreEqual("protocol == UDP", match.ToString());
        }
        
        [Test]
        public void ToStringIcmp()
        {
            ProtocolMatch match = new ProtocolMatch(Protocol.ICMP);
            Assert.AreEqual("protocol == ICMP", match.ToString());
        }
        
        [Test]
        public void Deserialize()
        {
            string json = "{\"match\":{\"op\":\"==\",\"left\":{\"payload\":{\"protocol\":\"ip\",\"field\":\"protocol\"}},\"right\":\"tcp\"}}";

            ProtocolMatch val = JsonConvert.DeserializeObject<ProtocolMatch>(json);
            Assert.NotNull(val);
            Assert.AreEqual(Protocol.TCP, val.protocol);
        }
        
        [Test]
        public void DeserializeInvalidJson()
        {
            string json = "{\"match\":{\"op\":\"<\",\"left\":{\"payload\":{\"protocol\":\"ip\",\"field\":\"protocol\"}},\"right\":\"tcp\"}}";
            
            Exception e = Assert.Throws(typeof(JSchemaException), () => JsonConvert.DeserializeObject<PortMatch>(json));
            Assert.AreEqual("JSON does not represent a valid PortMatch object", e.Message);
        }
        
        [Test]
        public void Serialize()
        {
            ProtocolMatch protocolMatch = new ProtocolMatch(Protocol.TCP);
            string ret = JsonConvert.SerializeObject(protocolMatch);
            
            string json = "{\"match\":{\"op\":\"==\",\"left\":{\"payload\":{\"protocol\":\"ip\",\"field\":\"protocol\"}},\"right\":\"tcp\"}}";
            Assert.AreEqual(json, ret);
        }
    }
}