using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackOfStrings = new StackOfStrings();
            Console.WriteLine(stackOfStrings.IsEmpty());
            stackOfStrings.Push("Hello");
            stackOfStrings.Push("How are you");
            Console.WriteLine(stackOfStrings.IsEmpty());
            string[] collection = new string[] { "Vesko", "Gosho", "Ivan" };
           // List<string>collection = new List<string>() { "Vesko","Gosho"};
            stackOfStrings.AddRange(collection);
            Console.WriteLine(string.Join(",",stackOfStrings));
        }
    }
}
