using System;

namespace Custom_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomQueue queue = new CustomQueue();
            queue.Dequeue();
            queue.Enqueue(5);
            queue.Enqueue(12);
            queue.Enqueue(100);
            queue.Enqueue(-10);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Peek());
            queue.ForEach(x => Console.WriteLine(x));
        }
    }
}
