using System;
using System.Linq;

namespace Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> func = w => char.IsUpper(w[0]);
            Console.WriteLine(string.Join(Environment.NewLine,input.Where(func)));
        }
    }
}
