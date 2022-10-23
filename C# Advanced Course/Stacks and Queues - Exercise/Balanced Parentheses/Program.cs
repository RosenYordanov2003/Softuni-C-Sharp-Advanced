using System;
using System.Linq;
using System.Collections.Generic;
namespace Balanced_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            bool isBalanced = true;
            string input = Console.ReadLine();
            foreach (char symbol in input)
            {
                if (symbol == '(' || symbol == '[' || symbol == '{')
                {
                    stack.Push(symbol);
                }
                else if (symbol == ')')
                {
                    if (stack.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }
                    char stackBracket = stack.Peek();
                    if (stackBracket == '(')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else if (symbol == '}')
                {
                    if (stack.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }
                    char stackBracket = stack.Peek();
                    if (stackBracket == '{')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else if (symbol == ']')
                {
                    if (stack.Count==0)
                    {
                        isBalanced = false;
                        break;
                    }
                    char stackBracket = stack.Peek();
                    if (stackBracket == '[')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }
            if (isBalanced&&stack.Count==0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
