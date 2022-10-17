using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> list;
        private int index;
        public ListyIterator(List<T> list)
        {
            this.list = list;
            this.index = 0;
        }

        public bool Move()
        {
            if (index < list.Count - 1)
            {
                index++;
                return true;
            }

            return false;
        }
        public bool HasNext()
        {
            return this.index < this.list.Count;
        }
        public T Print()
        {
            T result = default(T);

            if (this.list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            else
            {
                result = this.list[this.index];
                return result;
            }
        }
    }
}
