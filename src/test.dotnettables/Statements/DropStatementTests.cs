using System;
using dotnettables.Statements;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace test.dotnettables.Statements
{
    [TestFixture]
    public class DropStatementTests
    {
        [Test]
        public void ToStringConversion()
        {
            DropStatement dropStatement = new DropStatement();
            Assert.AreEqual("drop", dropStatement.ToString());
        }
        
        [Test]
        public void Deserialize()
        {
            string json = "{\"drop\":null}";

            DropStatement val = JsonConvert.DeserializeObject<DropStatement>(json);
            Assert.NotNull(val);
        }
        
        [Test]
        public void DeserializeWithoutAcceptKey()
        {
            string json = "{}";

            Exception e = Assert.Throws(typeof(JSchemaException), () => JsonConvert.DeserializeObject<DropStatement>(json));
            Assert.AreEqual("JSON does not represent a valid DropStatement object", e.Message);
        }
        
        [Test]
        public void Serialize()
        {
            DropStatement dropStatement = new DropStatement();
            string ret = JsonConvert.SerializeObject(dropStatement);
            
            string json = "{\"drop\":null}";
            Assert.AreEqual(json, ret);
        }
    }
}