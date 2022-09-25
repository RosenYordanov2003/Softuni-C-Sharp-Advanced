using System;
using System.Linq;
using System.Collections.Generic;

namespace Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> appendAction = words => Console.WriteLine("Sir " + string.Join(Environment.NewLine + "Sir ",words));

            appendAction(names);
        }
    }
}
