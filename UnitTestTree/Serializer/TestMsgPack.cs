using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTree;
using TestTree.Serializer;

namespace UnitTestTree.Serializer
{
    /// <summary>
    /// Summary description for TestMsgPack
    /// </summary>
    [TestClass]
    public class TestMsgPack
    {
        public TestMsgPack()
        {
            this.serializer = new MsgPackSerializer<Node>();
        }

        private TestContext testContextInstance;
        private ISerializer<Node> serializer;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestSerialize()
        {
            var node = new Node();
            node.Key = "test";
            var payload = this.serializer.Marshal(node);
            var result = this.serializer.Unmarshal(payload);
            Assert.AreEqual(node, result);
        }

        [TestMethod]
        public void BenchmarkSerialize()
        {
            Benchmark.Profile("Msgpack serialize", 10000, () =>
            {
                var node = new Node();
                node.Key = "test";
                var payload = this.serializer.Marshal(node);
                var result = this.serializer.Unmarshal(payload);
            });
        }
    }
}
