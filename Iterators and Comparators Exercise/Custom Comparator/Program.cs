using System;
using System.Linq;

namespace Custom_Comparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> customComparator = (x, y) =>
            {
                if (x%2==0&&y%2!=0)
                {
                    return -1;
                }
                else if (x % 2 == 0 && y % 2 == 0)
                {
                    return x.CompareTo(y);
                }
                else if (x%2!=0&&y%2==0)
                {
                    return 1;
                }
                else
                {
                    return x.CompareTo(y);
                }
            };
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Array.Sort(input,(x,y)=>customComparator(x,y));
            Console.WriteLine(String.Join(" ",input));
        }
    }
}
