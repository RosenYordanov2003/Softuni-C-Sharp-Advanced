using Collection_Hierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection_Hierarchy.Collections
{
    public class AddCollection : IAddCollection
    {
        protected const int INTERNAL_LENGTH = 100;
        private int currentIndex = 0;
        private string[] array = new string[INTERNAL_LENGTH];
        public int Add(string item)
        {
            int index = currentIndex;
            array[currentIndex++] = item;
            return index;
        }
    }
}
