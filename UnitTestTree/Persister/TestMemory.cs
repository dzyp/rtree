using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tree.Persister;

namespace UnitTestTree.Persister
{
    /// <summary>
    /// Summary description for TestMemory
    /// </summary>
    [TestClass]
    public class TestMemory
    {
        public TestMemory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

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
        public void TestPersist()
        {
            var persister = new Memory();
            var key = "key";
            var payload = new byte[] { 0x20 };
            persister.Persist(key, payload);
            var result = persister.Load(key);
            Assert.AreEqual(payload, result);
        }

        [TestMethod]
        public void BenchmarkPersist()
        {
            var persister = new Memory();
            var key = "key";
            var payload = new byte[] { 0x20 };
            Benchmark.Profile("memory persist", 100000, () => {
                persister.Persist(key, payload);
            });
        }
    }
}
