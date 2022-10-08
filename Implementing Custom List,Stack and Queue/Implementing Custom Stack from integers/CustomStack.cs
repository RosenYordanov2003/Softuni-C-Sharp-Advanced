using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Stack
{
    public class CustomStack
    {
        private int[] array;
        private const int InitalCapacity = 4;
        private int count;
        public CustomStack()
        {
            this.array = new int[InitalCapacity];
            this.count = 0;
        }
        public int Count { get { return this.count; } }
        public void Push(int element)
        {
            if (this.count == array.Length)
            {
                Resize(this.array);
            }
            this.array[this.count] = element;
            this.count++;
        }
        public int Peek()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return this.array[this.count - 1];
        }
        public int Pop()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            int elementToPop = this.array[this.Count - 1];
            this.array[this.count - 1] = 0;
            this.count--;
            return elementToPop;
        }
        public void ForEach(Action<int>action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.array[i]);
            }
        }

        private void Resize(int[] array)
        {
            int[] newArray = new int[array.Length * 2];
            for (int i = 0; i < this.count; i++)
            {
                newArray[i] = this.array[i];
            }
            this.array = newArray;
        }
    }
}
