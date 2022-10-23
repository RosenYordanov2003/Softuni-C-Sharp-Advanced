using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOperations = int.Parse(Console.ReadLine());
            string result = string.Empty;
            Stack<string> undoStack = new Stack<string>();
            for (int i = 0; i < countOperations; i++)
            {
                string[] data = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                int commandNumber = int.Parse(data[0]);
                if (commandNumber == 1)
                {
                    string text = data[1];
                    result += text;
                    undoStack.Push(result);
                }
                else if (commandNumber == 2)
                {
                    int countToDelete = int.Parse(data[1]);
                    result = result.Substring(0, result.Length - countToDelete);
                    undoStack.Push(result);
                }
                else if (commandNumber == 3)
                {
                    int indexToReturn = int.Parse(data[1]);
                    Console.WriteLine(result[indexToReturn-1]);
                }
                else if (commandNumber==4)
                {
                    undoStack.Pop();
                    if (undoStack.Count!=0)
                    {
                        result = undoStack.Peek();
                    }
                    else
                    {
                        result=string.Empty;
                    }
                }
            }
        }
    }
}
