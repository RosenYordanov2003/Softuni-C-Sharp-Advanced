using System;
using Template_Pattern.Models;

namespace Template_Pattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            Sourdough bread1 = new Sourdough();
            bread1.Make();
            Console.WriteLine();
            TwelveGrain bread2 = new TwelveGrain();
            bread2.Make();
            Console.WriteLine();
            WholeWheat bread3 = new WholeWheat();
            bread3.Make();
        }
    }
}
