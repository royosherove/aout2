using System;
using System.Transactions;
using NUnit.Framework;

namespace MyProduct.Tests
{
    [TestFixture]
    public class TrannsactionScopeTests
    {
        private TransactionScope trans = null;
        [SetUp]
        public void SetUp()
        {
            trans = new TransactionScope(TransactionScopeOption.Required);
        }
        [TearDown]
        public void TearDown()
        {
            trans.Dispose();
        }

        [Test]
        public void TestServicedSameTransaction()
        {
            MySimpleClass c = new MySimpleClass();

            long id = c.InsertCategoryStandard("whatever");
            long id2 = c.InsertCategoryStandard("whatever");
            Console.WriteLine("Got id of " + id);
            Console.WriteLine("Got id of " + id2);
            Assert.AreNotEqual(id, id2);
        }

    }
}