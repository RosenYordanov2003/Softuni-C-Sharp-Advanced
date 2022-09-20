using System;
using System.Collections.Generic;

namespace Sets_and_Dictionaries_Advanced___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countNames=int.Parse(Console.ReadLine());
            HashSet<string>names=new HashSet<string>();
            for (int i = 0; i <countNames ; i++)
            {
                string currentName = Console.ReadLine();
                names.Add(currentName);
            }
            Console.WriteLine(string.Join(Environment.NewLine,names));
        }
    }
}
