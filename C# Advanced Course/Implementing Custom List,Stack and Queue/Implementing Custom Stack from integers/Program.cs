using System;

namespace Custom_Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
           CustomStack stack = new CustomStack();
            stack.Push(6);
            stack.Push(5);
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            Console.WriteLine("---");
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Console.WriteLine("---");
            stack.ForEach(x => Console.WriteLine(x));
        }
    }
}
