using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get => this.name;
            set { this.name = value; }
        }
        public virtual int Age
        {
            get => this.age;
            set
            {
                if (value < 0)
                {
                    throw new Exception();
                }
                this.age = value;
            }
        }
        public override string ToString()
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {this.Name}, Age: {this.Age}");
            return stringBuilder.ToString().Trim();
        }
    }
}
