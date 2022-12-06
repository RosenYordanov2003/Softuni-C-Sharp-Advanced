namespace Chainblock.Models
{
    using System;
    using Contracts;
    public class Transaction : ITransaction
    {
        private string _sender;

        private string _receiver;

        private double _amount;

        public Transaction(int id, TransactionStatus status, string sender, string receiver, double amount)
        {
            Id = id;
            Status = status;
            From = sender;
            To = receiver;
            Amount = amount;
        }
        public int Id { get; set; }
        public TransactionStatus Status { get; set; }

        public string From
        {
            get => _sender;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Sender cannot be null or white space");
                }
                _sender = value;
            }
        }

        public string To
        {
            get => _receiver;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Receiver cannot be null or white space");
                }

                _receiver = value;
            }
        }

        public double Amount
        {
            get => _amount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Amount cannot be less or equal to zero");
                }
                _amount = value;
            }
        }
    }
}
