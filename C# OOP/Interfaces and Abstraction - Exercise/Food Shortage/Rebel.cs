using Food_Shortage.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Food_Shortage
{
    public class Rebel : IBuyer
    {
        private string name;
        private int age;
        private string group;
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = 0;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            private set { age = value; }
        }
        public string Group
        {
            get { return group; }
            set { group = value; }
        }

        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
