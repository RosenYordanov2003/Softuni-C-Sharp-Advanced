using System;

namespace GenericCountMethodDoubles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.Add(input);
            }
            double inputToCompare = double.Parse(Console.ReadLine());
            Console.WriteLine(box.CompareElements(inputToCompare));
        }
    }
}
