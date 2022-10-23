using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public  class Stack<T>:IEnumerable<T>
    {
        T[] internalArray;
        private int count;
        private const int initialCapacity = 4;
        public Stack()
        {
            this.internalArray = new T[initialCapacity];
            this.count = 0;
        }
        public void Push(T item)
        {
            if (this.count==this.internalArray.Length)
            {
                Resize();
            }
            this.internalArray[this.count++] = item;
        }
        public T Pop()
        {
            if (this.count==0)
            {
                throw new InvalidOperationException("No elements");
            }
            T itemToPop = this.internalArray[this.count-1];
            this.count--;
            return itemToPop;
        }
        public void Resize()
        {
            T[] newArray = new T[internalArray.Length * 2];
            for (int i = 0; i < this.count; i++)
            {
                newArray[i] = internalArray[i];
            }
            internalArray = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                yield return this.internalArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
