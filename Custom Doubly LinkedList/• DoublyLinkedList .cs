using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private Node head;
        private Node tail;
        public int Count { get; private set; }
        public void AddFirst(int value)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new Node(value);
            }
            else
            {
                Node newHead = new Node(value);
                newHead.Next = this.head;
                this.head.Previous = newHead;
                this.head = newHead;

            }
            this.Count++;
        }
        public void AddLast(int value)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new Node(value);
            }
            else
            {
                Node newTail = new Node(value);
                newTail.Previous = this.tail;
                this.tail.Next = newTail;
                tail = newTail;
            }
            this.Count++;
        }
        public int RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new Exception("The list is empty!");
            }
            int currentHead = this.head.Value;
            if (this.head != null)
            {
                this.head = this.head.Next;
                if (this.head != null)
                {
                    // remove older Head from previous on new current head
                    this.head.Previous = null;
                }
                else
                {
                    // if we have only 2 elements in our list we remove the connection between head and tail
                    this.tail = null;
                }
            }
            this.Count--;
            return currentHead;
        }
        public int RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new Exception("The list is empty!");
            }
            int currentTailValue = this.tail.Value;
            this.tail = this.tail.Previous;
            if (this.tail != null)
            {
                this.tail.Next = null;
            }
            else
            {
                this.head = null;
            }
            this.Count--;
            return currentTailValue;
        }
        public void ForEach(Action<int> action)
        {
            Node currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
        public int[] ToArray()
        {
            int[] array = new int[this.Count];
            Node currentNode = this.head;
            int index = 0;
            while (currentNode != null)
            {
                array[index] = currentNode.Value;
                currentNode = currentNode.Next;
                index++;
            }
            return array;
        }
    }
}
