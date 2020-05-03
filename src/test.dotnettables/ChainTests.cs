using dotnettables;
using Newtonsoft.Json;
using NUnit.Framework;

namespace test.dotnettables
{
    [TestFixture]
    public class ChainSerializationTests
    {
        [Test]
        public void ToStringConversion()
        {
            Chain chain = new Chain("test", AddressFamily.INET, Policy.DROP, ChainType.NAT, Hook.INPUT, 0, 0);
            Assert.AreEqual("test", chain.ToString());
        }

        [Test]
        public void Deserialization()
        {
            string json =
                "{\"chain\":{\"family\":\"inet\",\"table\":\"filter\",\"name\":\"forward\",\"handle\":2,\"type\":\"filter\",\"hook\":\"forward\",\"prio\":0,\"policy\":\"accept\"}}";

            Chain val = JsonConvert.DeserializeObject<Chain>(json);
            Assert.NotNull(val);

            Assert.AreEqual(val.family, AddressFamily.INET);
            Assert.IsNull(val.table);
            Assert.AreEqual("forward", val.name);
            Assert.AreEqual(2, val.handle);
            Assert.AreEqual(Hook.FORWARD, val.hook);
            Assert.AreEqual(0, val.priority);
            Assert.AreEqual(Policy.ACCEPT, val.policy);
        }

        [Test]
        public void Serialization()
        {
            Table table = new Table("filter");
            Chain val = new Chain("forward", AddressFamily.INET, Policy.ACCEPT, ChainType.FILTER, Hook.FORWARD, 0, 2);
            table.AddChain(val);

            string ret = JsonConvert.SerializeObject(val);
            Assert.NotNull(val);

            string json =
                "{\"chain\":{\"family\":\"inet\",\"table\":\"filter\",\"name\":\"forward\",\"handle\":2,\"type\":\"filter\",\"hook\":\"forward\",\"prio\":0,\"policy\":\"accept\"}}";
            Assert.AreEqual(json, ret);
        }
    }
}