using Collection_Hierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection_Hierarchy.Collections
{
    public class MyList : AddRemoveCollection, IMyList
    {
        private string[] array = new string[INTERNAL_LENGTH];
        private int countItems;
        private const int REMOVE_INDEX = 0;
        private const int ADD_INDEX = 0;
        public int Used => countItems;
        public override int Add(string item)
        {
            if (countItems > 0)
            {
               base.ShiftArray(this.array,this.countItems);
            }
            array[ADD_INDEX] = item;
            countItems++;
            return ADD_INDEX;
        }
        public override string Remove()
        {
            string elementToRemove = array[REMOVE_INDEX];
            array[REMOVE_INDEX] = default(string);
            countItems--;
            ShiftArray(array,countItems);
            return elementToRemove;
        }
        protected override void ShiftArray(string[]array,int countItems)
        {
            for (int i = 0; i <= countItems; i++)
            {
                array[i] = array[i + 1];
            }
        }
    }
}
