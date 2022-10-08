using System;

namespace Custom_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            // queue.Dequeue();
            queue.Enqueue(5);
            queue.Enqueue(12);
            queue.Enqueue(100);
            queue.Enqueue(-10);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Peek());
            Console.WriteLine("---");
            queue.ForEach(x => Console.WriteLine(x));
            CustomQueue<char> charQueue = new CustomQueue<char>();
            charQueue.Enqueue('a');
            charQueue.Enqueue('b');
            charQueue.Enqueue('c');
            charQueue.ForEach(x => Console.WriteLine(x));
            charQueue.Dequeue();
            Console.WriteLine("----");
            charQueue.ForEach(x => Console.WriteLine(x));
           
        }
    }
}
