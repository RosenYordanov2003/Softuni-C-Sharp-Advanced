using System;
using System.Linq;

namespace Implementing_Stack_and_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList<string> list = new CustomList<string>();
            list.Add("Hello");
            list.Add("Hello Mark");
            list.Remove("Hello");
            list.ForEach(x => Console.WriteLine(x));
            Console.WriteLine(list.Contains("Hello"));
            CustomList<int> integerList = new CustomList<int>();
            integerList.Add(1);
            integerList.Add(3);
            integerList.Add(3);
            integerList.Add(3);
            integerList.Add(7);
            integerList.RemoveAt(1);
            integerList.ForEach(x => Console.WriteLine(x));
            Console.WriteLine(integerList.Contains(-1));
        }
    }
}
