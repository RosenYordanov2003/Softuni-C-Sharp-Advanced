using System;
using System.Linq;

namespace TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> func = (firstName, points) => firstName.Sum(x => x) >= points;

            Func<string[], int, Func<string, int, bool>, string> getNames = (firstName, points, func) => names.Where(name => func(name, points)).FirstOrDefault();
            string name = getNames(names, n, func);
            Console.WriteLine(name);

        }


    }
}
