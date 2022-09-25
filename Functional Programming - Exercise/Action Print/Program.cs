using System;
using System.Collections.Generic;
using System.Linq;

namespace Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<string> printResult = n => Console.WriteLine(n);

            names.ForEach(x =>printResult(x));
        }
    }
}
