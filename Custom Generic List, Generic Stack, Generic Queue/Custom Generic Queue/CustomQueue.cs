using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Queue
{
    public class CustomQueue<T>
    {
        private T[] array;
        private const int InitialCapacity = 4;
        private const int FirstIndex = 0;
        private int count;
        public CustomQueue()
        {
            this.array = new T[InitialCapacity];
            this.count = 0;
        }
        public int Count { get { return this.Count; } }
        public void Enqueue(T element)
        {
            if (this.count == this.array.Length)
            {
                Resize(this.array);
            }
            this.array[this.count++] = element;
        }
        public T Dequeue()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            T elementToDeque = this.array[FirstIndex];
            this.array[FirstIndex] = default(T);
            Shift(this.array);
            this.count--;
            return elementToDeque;
        }
        public T Peek()
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
                this.array[i] = default(T);
                this.count--;
                i--;
            }
        }
        public void ForEach(Action<T>action)
        {
            for (int i = 0; i <this.count ; i++)
            {
                action(this.array[i]);
            }
        }

        private void Shift(T[] array)
        {
            for (int i = 0; i < this.count-1; i++)
            {
                this.array[i] = this.array[i + 1];
            }
            this.array[this.count - 1] = default(T);
        }

        private void Resize(T[] array)
        {
            T[] newArray = new T[array.Length * 2];
            for (int i = 0; i < this.count; i++)
            {
                newArray[i] = this.array[i];
            }
            newArray = array;
        }
    }
}
