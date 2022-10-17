using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Stack<string> stack = new Stack<string>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command.Contains("Push"))
                {
                    string[] pushCommand = command.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
                    foreach (var item in pushCommand)
                    {
                        stack.Push(item);
                    }
                }
                else if (command == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException exception)
                    {

                        Console.WriteLine(exception.Message);
                    }
                }
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
