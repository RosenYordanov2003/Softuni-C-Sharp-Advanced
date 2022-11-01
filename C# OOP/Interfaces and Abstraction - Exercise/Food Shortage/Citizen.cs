using Food_Shortage.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Food_Shortage
{
    public class Citizen : IIDentifiable, IBirthdable, IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthday;

        public Citizen(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
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
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
