using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList:List<string>
    {
        public RandomList()
        {
            this.Random = new Random();
        }
        public Random Random { get; set; }
        public string RandomString()
        {
            int index = Random.Next(0, this.Count);
            string stringToReturn = this[index];
            this.RemoveAt(index);
            return stringToReturn;
        }
    }
}
