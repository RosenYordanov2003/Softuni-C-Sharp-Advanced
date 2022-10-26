using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        public Person(string firsName, string lastName, int age)
        {
            this.FirstName = firsName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get { return firstName; }
            private set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            private set { lastName = value; }
        }
        public int Age
        {
            get { return age; }
           private set { age = value; }
        }

        public override string ToString()
        {
            return$"{this.FirstName} {this.lastName} is {this.age} years old.";
        }

    }
}
