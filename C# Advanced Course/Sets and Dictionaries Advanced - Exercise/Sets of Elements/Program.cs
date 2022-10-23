using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lenght = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int firstSetLenght = lenght[0];
            HashSet<int> firsSet = new HashSet<int>();
            int secondSetLength = lenght[1];
            HashSet<int> secondSet = new HashSet<int>();
            for (int i = 0; i < firstSetLenght; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firsSet.Add(number);
            }
            HashSet<int> result = new HashSet<int>();
            for (int i = 0; i < secondSetLength; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }
            foreach (int item in firsSet)
            {
                if (secondSet.Contains(item))
                {
                    result.Add(item);
                }
            }
            Console.Write(String.Join(" ", result));
        }
    }
}
