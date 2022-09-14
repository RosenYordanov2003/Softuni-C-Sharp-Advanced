using System;
using System.Linq;
using System.Collections.Generic;

namespace Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                char current=expression[i];
                if (current == '(')
                {
                    stack.Push(i);
                }
                if (current == ')')
                {
                    int startIndex = stack.Pop();
                    int endIndex = i;
                    string currentResult=expression.Substring(startIndex, endIndex - startIndex+1);
                    Console.WriteLine(currentResult);
                }
            }
        }
    }
}
