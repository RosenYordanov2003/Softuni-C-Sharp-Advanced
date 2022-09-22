using System;
using System.Linq;

namespace Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ").Select(x => int.Parse(x)).ToArray();
            numbers = numbers.Where(x=>isEvenNumber(x)).OrderBy(x => x).ToArray();
            Console.WriteLine(String.Join(", ", numbers));
        }
        static bool isEvenNumber(int x)
        {
            return x % 2 == 0;
        }
    }
}
