using System;
using System.Collections.Generic;
using System.Linq;
using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainBlockSystemTests
    {
        private ChainBlockSystem _chainblock;
        private Transaction _transaction;

        [SetUp]
        public void SetUp()
        {
            _chainblock = new ChainBlockSystem();
            _transaction = new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gosho", 250);
        }

        [Test]
        public void Test_ChainBlock_InitialCount()
        {
            Assert.AreEqual(0, _chainblock.Count);
        }

        [Test]
        public void Test_ChainBlock_AddTransaction_Method_Should_Add_TheTransaction()
        {
            _chainblock.Add(_transaction);
            Assert.AreEqual(1, _chainblock.Count);
        }

        [Test]
        public void Test_ChainBlock_AddTransaction_Method_ShouldNot_Add_TheTransaction()
        {
            _chainblock.Add(_transaction);
            Assert.Throws<InvalidOperationException>(() => _chainblock.Add(_transaction));
        }

        [Test]
        public void Test_ChainBlock_Change_TransactionStatus_ShouldBe_Successful()
        {
            _chainblock.Add(_transaction);
            _chainblock.ChangeTransactionStatus(2, TransactionStatus.Failed);
            Assert.AreEqual(TransactionStatus.Failed, _transaction.Status);
        }

        [Test]
        public void Test_ChainBlock_Change_TransactionStatus_ShouldNotBe_Successful()
        {
            Assert.Throws<ArgumentException>(() => _chainblock.ChangeTransactionStatus(2, TransactionStatus.Aborted));
        }

        [Test]
        public void Test_ChainBlock_Remove_Method_ShouldWork()
        {
            _chainblock.Add(_transaction);
            _chainblock.RemoveTransactionById(2);
            Assert.AreEqual(0, _chainblock.Count);
        }

        [Test]
        public void Test_ChainBlock_Remove_Method_ShouldNotWork()
        {
            _chainblock.Add(_transaction);
            Assert.Throws<InvalidOperationException>(() => _chainblock.RemoveTransactionById(6));
        }

        [Test]
        public void Test_ChainBlock_Get_TransactionBuId_Method_ShouldWork()
        {
            _chainblock.Add(_transaction);
            Assert.AreSame(_transaction, _chainblock.GetById(2));
        }

        [Test]
        public void Test_ChainBlock_Get_TransactionBuId_Method_ShouldNotWork()
        {
            _chainblock.Add(_transaction);
            Assert.Throws<InvalidOperationException>(() => _chainblock.GetById(99));
        }

        [Test]
        public void Test_ChainBlock_GetByTransactionStatusMethod_ShouldWork()
        {
            _chainblock.Add(_transaction);
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Petur", "Ivo", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Vasil", "Joro", 670);
            _chainblock.Add(firstTransaction);
            _chainblock.Add(secondTransaction);
            List<ITransaction> transactions = new List<ITransaction>()
            {
                _transaction,
                firstTransaction,
                secondTransaction
            };
            transactions = transactions.OrderByDescending(t => t.Amount).ToList();
            CollectionAssert.AreEqual(transactions, _chainblock.GetByTransactionStatus(TransactionStatus.Successfull));
        }

        [Test]
        public void Test_ChainBlock_GetByTransactionStatusMethod_ShouldNotWork()
        {
            _chainblock.Add(_transaction);
            Assert.Throws<InvalidOperationException>(
                () => _chainblock.GetByTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void Test_ChainBlock_GetAllSendersByTransactionStatusMethod_ShouldWork()
        {
            _chainblock.Add(_transaction);
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Petur", "Ivo", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Vasil", "Joro", 670);
            _chainblock.Add(firstTransaction);
            _chainblock.Add(secondTransaction);
            List<ITransaction> transactions = new List<ITransaction>()
            {
                _transaction,
                firstTransaction,
                secondTransaction
            };
            transactions = transactions.OrderByDescending(t => t.Amount).ToList();
            List<string> sendersList = transactions.Select(t => t.From).ToList();
            CollectionAssert.AreEqual(sendersList,
                _chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull));
        }

        [Test]
        public void Test_ChainBlock_GetAllSendersByTransactionStatusMethod_ShouldNotWork()
        {
            _chainblock.Add(_transaction);
            Assert.Throws<InvalidOperationException>(
                () => _chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        public void Test_ChainBlock_GetAllReceiverByTransactionStatusMethod_ShouldWork()
        {
            _chainblock.Add(_transaction);
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Petur", "Ivo", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Vasil", "Joro", 670);
            _chainblock.Add(firstTransaction);
            _chainblock.Add(secondTransaction);
            List<ITransaction> transactions = new List<ITransaction>()
            {
                _transaction,
                firstTransaction,
                secondTransaction
            };
            List<string> receiverList = transactions.OrderByDescending(t => t.Amount).Select(t => t.To).ToList();
            CollectionAssert.AreEqual(receiverList,
                _chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull));
        }

        [Test]
        public void Test_ChainBlock_GetAllReceiverByTransactionStatusMethod_ShouldNotWork()
        {
            _chainblock.Add(_transaction);
            Assert.Throws<InvalidOperationException>(
                () => _chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        public void Test_ChainBlockGetAllTransactionsById()
        {
            _chainblock.Add(_transaction);
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Petur", "Ivo", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Vasil", "Joro", 670);
            _chainblock.Add(firstTransaction);
            _chainblock.Add(secondTransaction);
            List<ITransaction> transactions = new List<ITransaction>()
            {
                _transaction,
                firstTransaction,
                secondTransaction
            };
            List<ITransaction> orderedTransactions =
                transactions.OrderByDescending(t => t.Amount).ThenBy(t => t.Id).ToList();
            CollectionAssert.AreEqual(orderedTransactions, _chainblock.GetAllOrderedByAmountDescendingThenById());
        }

        [Test]
        public void Test_GetByTransactionStatusAndMaximumAmountMethod_ShouldWork()
        {
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Petur", "Ivo", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Petur", "Joro", 670);
            _chainblock.Add(firstTransaction);
            _chainblock.Add(secondTransaction);
            List<ITransaction> transactions = new List<ITransaction>()
            {
                _transaction,
                firstTransaction,
                secondTransaction
            };
            string nameToSearch = "Petur";
            List<ITransaction> orderedTransactions = transactions.Where(t => t.From == nameToSearch)
                .OrderByDescending(t => t.Amount).ToList();
            CollectionAssert.AreEqual(orderedTransactions,
                _chainblock.GetBySenderOrderedByAmountDescending(nameToSearch));
        }

        [Test]
        public void Test_GetByTransactionStatusAndMaximumAmountMethod_ShouldNotWork()
        {
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Petur", "Ivo", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Petur", "Joro", 670);
            _chainblock.Add(firstTransaction);
            _chainblock.Add(secondTransaction);
            Assert.Throws<InvalidOperationException>(
                () => _chainblock.GetBySenderOrderedByAmountDescending("Vesko"));
        }

        [Test]
        public void Test_ChainBlock_GetByReceiverOrderedByAmountThenByIdMethod()
        {
            _chainblock.Add(_transaction);
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Petur", "Joro", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Vasil", "Joro", 670);
            _chainblock.Add(firstTransaction);
            _chainblock.Add(secondTransaction);
            List<ITransaction> transactions = new List<ITransaction>()
            {
                _transaction,
                firstTransaction,
                secondTransaction
            };
            string receiverNameToSearch = "Joro";
            transactions = transactions.Where(t => t.To == receiverNameToSearch).OrderBy(t => t.Amount)
                .ThenBy(t => t.Id).ToList();
            CollectionAssert.AreEqual(transactions,
                _chainblock.GetByReceiverOrderedByAmountThenById(receiverNameToSearch));
        }

        [Test]
        public void Test_ChainBlock_GetByReceiverOrderedByAmountThenByIdMethod_ShouldNotWork()
        {
            _chainblock.Add(_transaction);
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Petur", "Joro", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Vasil", "Joro", 670);

            Assert.Throws<InvalidOperationException>(
                () => _chainblock.GetByReceiverOrderedByAmountThenById("Vesko"));
        }

        [Test]
        public void Test_ChainBlockGetByTransactionStatusAndMaximumAmountMethod_ShouldNotBe_AnEmptyCollection()
        {
            _chainblock.Add(_transaction);
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Petur", "Joro", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Petur", "Pesho", 670);
            _chainblock.Add(firstTransaction);
            _chainblock.Add(secondTransaction);
            List<ITransaction> transactions = new List<ITransaction>()
            {
                _transaction,
                firstTransaction,
                secondTransaction
            };
            transactions = transactions.Where(t => t.Status == TransactionStatus.Successfull && t.Amount <= 450)
                .OrderByDescending(t => t.Amount).ToList();
            CollectionAssert.AreEqual(transactions,
                _chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 450));
        }

        [Test]
        public void Test_ChainBlockGetByTransactionStatusAndMaximumAmountMethod_ShouldBe_AnEmptyCollection()
        {
            _chainblock.Add(_transaction);
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Petur", "Joro", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Petur", "Pesho", 670);
            _chainblock.Add(firstTransaction);
            _chainblock.Add(secondTransaction);
            List<ITransaction> transactions = new List<ITransaction>();
            CollectionAssert.AreEqual(transactions,
                _chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Unauthorized, 500));
        }
        [Test]
        public void Test_ChainBlockGetByTransactionStatusAndMaximumAmountMethod_ShouldBe_AnEmptyCollection2()
        {
            _chainblock.Add(_transaction);
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Petur", "Joro", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Petur", "Pesho", 670);
            _chainblock.Add(firstTransaction);
            _chainblock.Add(secondTransaction);
            List<ITransaction> transactions = new List<ITransaction>();
            CollectionAssert.AreEqual(transactions,
                _chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 100));
        }

        [Test]
        public void Test_ChainBlock_GetBySenderAndMinimumAmountDescendingMethod_ShouldWork()
        {
            _chainblock.Add(_transaction);
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Petur", "Joro", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Petur", "Pesho", 670);
            _chainblock.Add(firstTransaction);
            _chainblock.Add(secondTransaction);
            List<ITransaction> expectedTransactions = new List<ITransaction>()
            {
                _transaction,
                firstTransaction,
                secondTransaction
            };
            string senderNamee = "Petur";
            expectedTransactions = expectedTransactions.Where(t => t.From == senderNamee && t.Amount > 200)
                .OrderByDescending(t => t.Amount).ToList();
            CollectionAssert.AreEqual(expectedTransactions, _chainblock.GetBySenderAndMinimumAmountDescending(senderNamee, 200));
        }

        [Test]
        public void Test_ChainBlock_GetBySenderAndMinimumAmountDescendingMethod_ShouldNotWork_With_No_ExistingSender()
        {
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Petur", "Joro", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Petur", "Pesho", 670);
            _chainblock.Add(firstTransaction);
            _chainblock.Add(secondTransaction);

            Assert.Throws<InvalidOperationException>(() =>
                _chainblock.GetBySenderAndMinimumAmountDescending("Denis", 200));
        }
        [Test]
        public void Test_ChainBlock_GetBySenderAndMinimumAmountDescendingMethod_ShouldNotWork_WithBiggerAmount()
        {
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Petur", "Joro", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Petur", "Pesho", 670);
            _chainblock.Add(firstTransaction);
            _chainblock.Add(secondTransaction);

            Assert.Throws<InvalidOperationException>(() =>
                _chainblock.GetBySenderAndMinimumAmountDescending("Petur", 800));
        }

        [Test]
        public void Test_ChainBlock_GetByReceiverAndAmountRangeMethod_ShouldWork()
        {
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Joro", "Pesho", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Petur", "Pesho", 670);
            _chainblock.Add(firstTransaction);
            _chainblock.Add(secondTransaction);
            List<ITransaction> expectedTransactions = new List<ITransaction>()
            {
                _transaction,
                firstTransaction,
                secondTransaction
            };
            string receiverName = "Pesho";
            double minAmount = 399;
            double maxAmount = 673;
            expectedTransactions = expectedTransactions
                .Where(t => t.To == receiverName && t.Amount >= minAmount && t.Amount <= maxAmount)
                .OrderByDescending(t => t.Amount).ThenBy(t => t.Id).ToList();
            CollectionAssert.AreEqual(expectedTransactions, _chainblock.GetByReceiverAndAmountRange(receiverName, minAmount, maxAmount));
        }
        [Test]
        public void Test_ChainBlock_GetByReceiverAndAmountRangeMethod_ShouldNotWork_With_No_Existing_Sender()
        {
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Joro", "Pesho", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Petur", "Pesho", 670);
            _chainblock.Add(firstTransaction);
            _chainblock.Add(secondTransaction);
            Assert.Throws<InvalidOperationException>(() => _chainblock.GetByReceiverAndAmountRange("Mitko", 300, 700));
        }
        [Test]
        public void Test_ChainBlock_GetByReceiverAndAmountRangeMethod_ShouldNotWork_With_No_Matching_TransactionAmount()
        {
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Joro", "Pesho", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Petur", "Pesho", 670);
            _chainblock.Add(firstTransaction);
            _chainblock.Add(secondTransaction);
            Assert.Throws<InvalidOperationException>(() => _chainblock.GetByReceiverAndAmountRange("Pesho", 790, 900));
        }

        [Test]
        public void Test_ChainBlock_GetAllInAmountRangeMethod_ShouldReturn_NoEmptyCollection()
        {
            ITransaction firstTransaction = new Transaction(1, TransactionStatus.Successfull, "Joro", "Pesho", 450);
            ITransaction secondTransaction = new Transaction(3, TransactionStatus.Successfull, "Petur", "Pesho", 670);
            _chainblock.Add(firstTransaction);
            _chainblock.Add(secondTransaction);
            List<ITransaction> expectedTransactions = new List<ITransaction>() { firstTransaction, secondTransaction };
            double minAmountRange = 200;
            double maxAmountRange = 700;
            expectedTransactions = expectedTransactions
                .Where(t => t.Amount >= minAmountRange && t.Amount <= maxAmountRange).ToList();
            CollectionAssert.AreEqual(expectedTransactions, _chainblock.GetAllInAmountRange(minAmountRange, maxAmountRange));
        }

        [Test]
        public void Test_ChainBlock_GetAllInAmountRangeMethod_ShouldReturn_AnEmptyCollection()
        {
            _chainblock.Add(_transaction);
            List<ITransaction> expectedTransactions = new List<ITransaction>();
            double minAmountRange = 370;
            double maxAmountRange = 700;

            CollectionAssert.AreEqual(expectedTransactions, _chainblock.GetAllInAmountRange(minAmountRange, maxAmountRange));
        }

        [Test]
        public void Test_ChainBlock_ContainsMethod_ShouldReturn_False()
        {
            _chainblock.Add(_transaction);
            Assert.IsTrue(_chainblock.Contains(_transaction));
        }
        [Test]
        public void Test_ChainBlock_ContainsMethod_ShouldReturn_True()
        {
            
            Assert.IsFalse(_chainblock.Contains(_transaction));
        }
    }
}
