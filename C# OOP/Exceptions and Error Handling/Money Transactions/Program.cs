using System;
using System.Collections.Generic;
using System.Linq;

namespace Money_Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accounts = new Dictionary<int, double>();
            string[] input = Console.ReadLine().Split(new char[] { ',', '-' });
            AddElements(accounts, input);
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                try
                {
                    if (action != "Deposit" && action != "Withdraw")
                    {
                        throw new InvalidOperationException("Invalid command!");
                    }
                    else
                    {
                        if (action == "Deposit")
                        {
                            int accountNumber = int.Parse(tokens[1]);
                            double sum = double.Parse(tokens[2]);
                            if (!accounts.ContainsKey(accountNumber))
                            {
                                throw new ArgumentException("Invalid account!");
                            }
                            else
                            {
                                accounts[accountNumber]+=sum;
                                Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
                            }
                        }
                        else
                        {
                            int accountNumber = int.Parse(tokens[1]);
                            double sum = double.Parse(tokens[2]);
                            if (sum > accounts[accountNumber])
                            {
                                throw new  InvalidOperationException("Insufficient balance!");
                            }
                            else
                            {
                                accounts[accountNumber]-=sum;
                                Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
                            }
                        }
                    }
                }

                catch (InvalidOperationException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch(ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }

        static void AddElements(Dictionary<int, double> accounts, string[] input)
        {
            for (int i = 0; i < input.Length; i+=2)
            {
                int key = int.Parse(input[i]);
                double value = double.Parse(input[i+1]);
                accounts[key] = value;
            }
        }
    }
}
