using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();
            doublyLinkedList.AddFirst(2);
            doublyLinkedList.AddFirst(4);
            doublyLinkedList.AddLast(5);
            doublyLinkedList.AddLast(6);
            doublyLinkedList.RemoveFirst();
            doublyLinkedList.RemoveLast();
            doublyLinkedList.ForEach(x => Console.WriteLine(x));
            int[]array = doublyLinkedList.ToArray();
            Console.WriteLine(String.Join(" ",array));
        }
    }
}
