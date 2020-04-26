using System;
using dotnettables;
using Newtonsoft.Json;
using NUnit.Framework;

namespace test.dotnettables
{
    [TestFixture]
    public class TableTests
    {
        [Test]
        public void Deserialization()
        {
            string json = "{\"table\":{\"family\":\"inet\",\"name\":\"filter\",\"handle\": 1}}";
            Table val = JsonConvert.DeserializeObject<Table>(json);

            Assert.AreEqual("filter", val.name);
            Assert.AreEqual(AddressFamily.INET, val.family);
            Assert.AreEqual(1, val.handle);
        }

        [Test]
        public void Serialization()
        {
            Table table = new Table("filter", AddressFamily.INET, 1);
            string ret = JsonConvert.SerializeObject(table);

            string json = "{\"table\":{\"family\":\"inet\",\"name\":\"filter\",\"handle\":1}}";
            Assert.AreEqual(json, ret);
        }

        [Test]
        public void ToStringConversion()
        {
            Table table = new Table("filter", AddressFamily.INET, 1);
            Assert.AreEqual("filter", table.ToString());
        }

        [Test]
        public void GetChainNoChains()
        {
            Table table = new Table("filter", AddressFamily.INET, 1);
            Assert.IsNull(table.GetChain("test"));
        }

        [Test]
        public void GetChainDoesntExist()
        {
            Table table = new Table("filter", AddressFamily.INET, 1);
            table.AddChain(new Chain("1", AddressFamily.INET, Policy.ACCEPT, ChainType.FILTER, Hook.FORWARD, 0, 0));
            table.AddChain(new Chain("2", AddressFamily.INET, Policy.ACCEPT, ChainType.FILTER, Hook.FORWARD, 0, 1));
            Assert.IsNull(table.GetChain("test"));
        }

        [Test]
        public void GetChain()
        {
            Table table = new Table("filter", AddressFamily.INET, 1);
            table.AddChain(new Chain("1", AddressFamily.INET, Policy.ACCEPT, ChainType.FILTER, Hook.FORWARD, 0, 0));
            table.AddChain(new Chain("2", AddressFamily.INET, Policy.ACCEPT, ChainType.FILTER, Hook.FORWARD, 0, 1));
            Chain chain = table.GetChain("2");
            Assert.NotNull(chain);
            Assert.AreEqual("2", chain.name);
        }

        [Test]
        public void AddChain()
        {
            Table table = new Table("filter", AddressFamily.INET, 1);
            Assert.AreEqual(0, table.chains.Count);

            table.AddChain(new Chain("1", AddressFamily.INET, Policy.ACCEPT, ChainType.FILTER, Hook.FORWARD, 0, 0));
            Assert.AreEqual(1, table.chains.Count);

            table.AddChain(new Chain("2", AddressFamily.INET, Policy.ACCEPT, ChainType.FILTER, Hook.FORWARD, 0, 1));
            Assert.AreEqual(2, table.chains.Count);
        }

        [Test]
        public void RemoveChain()
        {
            Table table = new Table("filter", AddressFamily.INET, 1);
            Chain chain1 = new Chain("2", AddressFamily.INET, Policy.ACCEPT, ChainType.FILTER, Hook.FORWARD, 0, 0);
            Chain chain2 = new Chain("2", AddressFamily.INET, Policy.ACCEPT, ChainType.FILTER, Hook.FORWARD, 0, 1);
            table.AddChain(chain1);
            table.AddChain(chain2);
            Assert.AreEqual(2, table.chains.Count);

            table.RemoveChain(chain2);
            Assert.AreEqual(1, table.chains.Count);

            table.RemoveChain(chain1);
            Assert.AreEqual(0, table.chains.Count);
        }

        [Test]
        public void RemoveChainNoChains()
        {
            Table table = new Table("filter", AddressFamily.INET, 1);
            Assert.AreEqual(0, table.chains.Count);


            Chain chain = new Chain("2", AddressFamily.INET, Policy.ACCEPT, ChainType.FILTER, Hook.FORWARD, 0, 0);
            Exception e = Assert.Throws<Exception>(() => table.RemoveChain(chain));

            Assert.AreEqual("Chain does not exist in table", e.Message);
        }
    }
}