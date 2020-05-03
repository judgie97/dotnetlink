using System;
using dotnettables;
using dotnettables.Matches;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace test.dotnettables.Matches
{
    [TestFixture]
    public class ConntrackStateMatchTests
    {
        [Test]
        public void ToString()
        {
            ConntrackStateMatch match = new ConntrackStateMatch(ConntrackState.ESTABLISHED);
            Assert.AreEqual("ct_state == ESTABLISHED", match.ToString());
        }
        
        [Test]
        public void Deserialize()
        {
            string json = "{\"match\":{\"op\":\"==\",\"left\":{\"ct\":{\"key\":\"state\"}},\"right\":\"established\"}}";

            ConntrackStateMatch val = JsonConvert.DeserializeObject<ConntrackStateMatch>(json);
            Assert.NotNull(val);
            Assert.AreEqual(ConntrackState.ESTABLISHED, val.State);
        }
        
        [Test]
        public void DeserializeInvalidJson()
        {
            string json = "{\"match\":{\"op\":\"<\",\"left\":{\"ct\":{\"key\":\"state\"}},\"right\":\"established\"}}";
            
            Exception e = Assert.Throws(typeof(JSchemaException), () => JsonConvert.DeserializeObject<ConntrackStateMatch>(json));
            Assert.AreEqual("JSON does not represent a valid ConntrackStateMatch object", e.Message);
        }
        
        [Test]
        public void Serialize()
        {
            ConntrackStateMatch conntrackStateMatch = new ConntrackStateMatch(ConntrackState.ESTABLISHED);
            string ret = JsonConvert.SerializeObject(conntrackStateMatch);
            
            string json = "{\"match\":{\"op\":\"==\",\"left\":{\"ct\":{\"key\":\"state\"}},\"right\":\"established\"}}";
            Assert.AreEqual(json, ret);
        }
    }
}