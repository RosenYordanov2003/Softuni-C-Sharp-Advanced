using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            List<int> sequenceDividers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(num => int.Parse(num)).ToList();

            Func<int, List<int>, bool> function = (number, dividers) =>
                {
                    int counter = 0;
                    foreach (int item in dividers)
                    {
                        if (number%item == 0)
                        {
                            counter++;
                        }
                    }
                    if (counter==dividers.Count)
                    {
                        return true;
                    }
                    return false;
                    
                };
            List<int> results = new List<int>();
            for (int i = 1; i <= end; i++)
            {
                bool result = function(i, sequenceDividers);
                if (result)
                {
                    results.Add(i);
                }
                else
                {
                    continue;
                }
            }
            Action<List<int>> print = number => Console.WriteLine(String.Join(" ", number));
            print(results);
        }
    }
}
