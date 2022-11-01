using Collection_Hierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection_Hierarchy.Collections
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        protected const int INTERNAL_LENGTH = 100;
        private int currentIndex = 0;
        private int countItems = 0;
        private string[] array = new string[INTERNAL_LENGTH];
        public virtual int Add(string item)
        {
            if (countItems > 0)
            {
                ShiftArray(array,countItems);
            }
            array[currentIndex] = item;
            countItems++;
            return currentIndex;
        }
        public virtual string Remove()
        {
            string elementToRemove = array[countItems-1];
            array[countItems-1] = default(string);
            countItems--;
            return elementToRemove;
        }
        protected virtual void ShiftArray(string[]array,int countItems)
        {
            for (int i = countItems; i > 0; i--)
            {
                array[i] = array[i - 1];
            }
        }
    }
}
