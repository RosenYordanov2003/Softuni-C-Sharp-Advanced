using System;
using Chainblock.Models;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        private Transaction _transaction;

        [SetUp]
        public void SetUp()
        {
            _transaction = new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gosho", 250);
        }

        [Test]
        public void Test_Transaction_Constructor()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(2,_transaction.Id);
                Assert.AreEqual(TransactionStatus.Successfull,_transaction.Status);
                Assert.AreEqual("Pesho",_transaction.From);
                Assert.AreEqual("Gosho",_transaction.To);
                Assert.AreEqual(250,_transaction.Amount);
            });
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Test_Transaction_With_InvalidSender(string senderName)
        {
            Assert.Throws<ArgumentException>(() =>
                _transaction = new Transaction(2, TransactionStatus.Successfull, senderName, "Gosho", 250));
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Test_Transaction_With_InvalidReceiver(string receiverName)
        {
            Assert.Throws<ArgumentException>(() =>
                _transaction = new Transaction(2, TransactionStatus.Successfull, "Pesho", receiverName, 250));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-199)]
        [TestCase(-199.67)]
        public void Test_Transaction_With_Invalid_Amount(double amount)
        {
            Assert.Throws<ArgumentException>(()=>_transaction =
                new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gosho", amount));
        }
    }
}
