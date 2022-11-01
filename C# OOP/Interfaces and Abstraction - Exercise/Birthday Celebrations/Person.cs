using Birthday_Celebrations.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Birthday_Celebrations
{
    public class Person : IIDentifiable, IBirthdable
    {
        private string name;
        private int age;
        private string id;
        private string birthday;

        public Person(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
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
    }
}
