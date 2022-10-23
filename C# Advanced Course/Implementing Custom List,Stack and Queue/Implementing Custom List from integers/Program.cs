using System;
using System.Linq;

namespace Implementing_Stack_and_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList customList = new CustomList();
            //customList.Add(5);
            //customList.Add(25);
            //customList.Add(17);
            //Console.WriteLine(customList.RemoveAt(0));
            //customList.Add(49);
            //Console.WriteLine(customList.Contains(49));
            //Console.WriteLine(customList.Count);
            //customList.ForEach(x => Console.WriteLine(x));
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);
            customList.Add(4);
            customList.Add(5);
            customList.Add(6);
            customList.Add(100);
            customList.Add(99);
            customList.Add(88);
           // customList.Remove(3);
        //   customList.ForEach(x => Console.WriteLine(x));
         //   int[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            //customList.AddRange(array);
          //  Console.WriteLine(customList.Count);
            customList.RemoveRange(2,6);
            Console.WriteLine("----");
            customList.ForEach(x => Console.WriteLine(x));
        }
    }
}
