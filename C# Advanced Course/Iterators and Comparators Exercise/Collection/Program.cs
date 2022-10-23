using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList();
            string command;
            ListyIterator<string> list = new ListyIterator<string>(input);
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }
                else if (command == "Print")
                {
                    try
                    {
                        list.Print();
                    }
                    catch (InvalidOperationException exception)
                    {

                        Console.WriteLine(exception.Message);
                    }
                }
                else if (command == "PrintAll")
                {
                    foreach (var item in list)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
