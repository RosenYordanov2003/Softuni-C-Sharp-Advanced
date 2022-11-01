using Border_Control;
using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Person : IIDentifiable
    {
        private string name;
        private int age;
        private string id;

        public Person(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
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
    }
}
