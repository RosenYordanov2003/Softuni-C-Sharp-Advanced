using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Stack
{
    public class CustomStack<T>
    {
        private T[] array;
        private const int InitalCapacity = 4;
        private int count;
        public CustomStack()
        {
            this.array = new T[InitalCapacity];
            this.count = 0;
        }
        public int Count { get { return this.count; } }
        public void Push(T element)
        {
            if (this.count == array.Length)
            {
                Resize(this.array);
            }
            this.array[this.count] = element;
            this.count++;
        }
        public T Peek()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return this.array[this.count - 1];
        }
        public T Pop()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            T elementToPop = this.array[this.Count - 1];
            this.array[this.count - 1] = default(T);
            this.count--;
            return elementToPop;
        }
        public void ForEach(Action<T>action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.array[i]);
            }
        }

        private void Resize(T[] array)
        {
            T[] newArray = new T[array.Length * 2];
            for (int i = 0; i < this.count; i++)
            {
                newArray[i] = this.array[i];
            }
            this.array = newArray;
        }
    }
}
