using System;
using dotnettables.Statements;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace test.dotnettables.Statements
{
    [TestFixture]
    public class AcceptStatementTests
    {
        [Test]
        public void ToStringConversion()
        {
            AcceptStatement acceptStatement = new AcceptStatement();
            Assert.AreEqual("accept", acceptStatement.ToString());
        }

        [Test]
        public void Deserialize()
        {
            string json = "{\"accept\":null}";

            AcceptStatement val = JsonConvert.DeserializeObject<AcceptStatement>(json);
            Assert.NotNull(val);
        }
        
        [Test]
        public void DeserializeWithoutAcceptKey()
        {
            string json = "{}";

            Exception e = Assert.Throws(typeof(JSchemaException), () => JsonConvert.DeserializeObject<AcceptStatement>(json));
            Assert.AreEqual("JSON does not represent a valid AcceptStatement object", e.Message);
        }
        
        [Test]
        public void Serialize()
        {
            AcceptStatement acceptStatement = new AcceptStatement();
            string ret = JsonConvert.SerializeObject(acceptStatement);
            
            string json = "{\"accept\":null}";
            Assert.AreEqual(json, ret);
        }
    }
}