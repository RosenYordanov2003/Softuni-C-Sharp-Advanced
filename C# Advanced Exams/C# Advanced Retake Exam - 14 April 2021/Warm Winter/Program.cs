using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] hatsValues = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[]scarfValues = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int>stack= new Stack<int>(hatsValues);
            Queue<int> queue= new Queue<int>(scarfValues);
            Queue<int> sets = new Queue<int>();
            while (stack.Any()&&queue.Any())
            {
                int currentHat = stack.Pop();
                int currentScarf = queue.Peek();
                if (currentHat==currentScarf)
                {
                    stack.Push(++currentHat);
                    queue.Dequeue();
                }
                else if (currentScarf > currentHat)
                {
                    continue;
                }
                else
                {
                    int currentSet = currentHat+currentScarf;
                    sets.Enqueue(currentSet);
                    queue.Dequeue();
                }
            }
            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.Write(string.Join(" ",sets));
        }
    }
}
