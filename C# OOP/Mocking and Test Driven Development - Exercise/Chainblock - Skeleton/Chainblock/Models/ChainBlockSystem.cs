using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chainblock.Contracts;

namespace Chainblock.Models
{
    public class ChainBlockSystem : IChainblock
    {
        private HashSet<ITransaction> _transactions;

        public ChainBlockSystem()
        {
            _transactions = new HashSet<ITransaction>();
        }
        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => _transactions.Count;
        public void Add(ITransaction tx)
        {
            if (Contains(tx.Id))
            {
                throw new InvalidOperationException("Already added transaction");
            }
            _transactions.Add(tx);
        }

        public bool Contains(ITransaction tx)
        {
            return _transactions.Contains(tx);
        }

        public bool Contains(int id)
        {
            return _transactions.Any(t => t.Id == id);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction transaction = _transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                throw new ArgumentException();
            }
            transaction.Status = newStatus;
        }

        public void RemoveTransactionById(int id)
        {
            ITransaction transactionToRemove = _transactions.FirstOrDefault(t => t.Id == id);
            if (transactionToRemove == null)
            {
                throw new InvalidOperationException();
            }
            _transactions.Remove(transactionToRemove);
        }

        public ITransaction GetById(int id)
        {
            ITransaction transaction = _transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                throw new InvalidOperationException();
            }

            return transaction;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            List<ITransaction> transactions = this._transactions.Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount).ToList();
            if (transactions.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return transactions;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            List<string> senders = _transactions.Where(t => t.Status == status).OrderByDescending(t => t.Amount).Select(t => t.From).ToList();
            if (senders.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return senders;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            List<string> receivers = _transactions.Where(t => t.Status == status).OrderByDescending(t => t.Amount).Select(t => t.To).ToList();
            if (receivers.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return receivers;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            List<ITransaction> orderedTransactions =
                _transactions.OrderByDescending(t => t.Amount).ThenBy(t => t.Id).ToList();
            return orderedTransactions;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            List<ITransaction> transactions =
                _transactions.Where(t => t.From == sender).OrderByDescending(t => t.Amount).ToList();
            if (transactions.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            List<ITransaction> transactions = _transactions.Where(t => t.To == receiver).OrderBy(t => t.Amount)
                .ThenBy(t => t.Id).ToList();
            if (transactions.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            List<ITransaction> transactions = _transactions.Where(t => t.Status == status && t.Amount <= amount)
                .OrderByDescending(t => t.Amount).ToList();
            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            List<ITransaction> transactions = _transactions.Where(t => t.From == sender && t.Amount > amount)
                .OrderByDescending(t => t.Amount).ToList();
            if (transactions.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            List<ITransaction> transactions = _transactions.Where(t => t.To == receiver && t.Amount >= lo&&t.Amount<=hi)
                .OrderByDescending(t => t.Amount).ThenBy(t=>t.Id).ToList();
            if (transactions.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            List<ITransaction> transactions = _transactions.Where(t => t.Amount >= lo && t.Amount <= hi).ToList();
            return transactions;
        }
    }
}
