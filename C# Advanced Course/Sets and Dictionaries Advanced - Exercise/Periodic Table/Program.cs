using System;
using System.Collections.Generic;
using System.Linq;

namespace Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int countElements=int.Parse(Console.ReadLine());

            SortedSet<string>set=new SortedSet<string>();
            for (int i = 0; i <countElements ; i++)
            {
                string[] elements = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                for (int z = 0; z <elements.Length ; z++)
                {
                    set.Add(elements[z]);
                }
            }
            Console.Write(string.Join(" ",set));
        }
    }
}
