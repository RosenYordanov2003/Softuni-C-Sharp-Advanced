using System;
using System.Linq;

namespace Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int namesLength = int.Parse(Console.ReadLine());
       
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string,int, bool> checkNameLength = (name,length) => name.Length <=length;

            names = names.Where(name => checkNameLength(name,namesLength)).ToArray();

            Action<string[]> print = name => Console.WriteLine(string.Join(Environment.NewLine, name));

            print(names);
        }
    }
}
