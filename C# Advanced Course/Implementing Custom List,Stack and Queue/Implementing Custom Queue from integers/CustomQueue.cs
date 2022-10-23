using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Queue
{
    public class CustomQueue
    {
        private int[] array;
        private const int InitialCapacity = 4;
        private const int FirstIndex = 0;
        private int count;
        public CustomQueue()
        {
            this.array = new int[InitialCapacity];
            this.count = 0;
        }
        public int Count { get { return this.Count; } }
        public void Enqueue(int element)
        {
            if (this.count == this.array.Length)
            {
                Resize(this.array);
            }
            this.array[this.count++] = element;
        }
        public int Dequeue()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            int elementToDeque = this.array[FirstIndex];
            this.array[FirstIndex] = default(int);
            Shift(this.array);
            this.count--;
            return elementToDeque;
        }
        public int Peek()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return this.array[FirstIndex];
        }
        public void Clear()
        {
            for (int i = 0; i < this.count; i++)
            {
                this.array[i] = 0;
                this.count--;
                i--;
            }
        }
        public void ForEach(Action<int>action)
        {
            for (int i = 0; i <this.count ; i++)
            {
                action(this.array[i]);
            }
        }

        private void Shift(int[] array)
        {
            for (int i = 0; i < this.count-1; i++)
            {
                this.array[i] = this.array[i + 1];
            }
            this.array[this.count - 1] = 0;
        }

        private void Resize(int[] array)
        {
            int[] newArray = new int[array.Length * 2];
            for (int i = 0; i < this.count; i++)
            {
                newArray[i] = this.array[i];
            }
            newArray = array;
        }
    }
}
