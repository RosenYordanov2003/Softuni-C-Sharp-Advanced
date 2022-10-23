using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo([AllowNull] Person other)
        {
            int result = 0;
            result = this.Name.CompareTo(other.Name);
            if (result != 0)
            {
                return result;
            }
            result = this.Age.CompareTo(other.Age);
            return result;
        }
        public override bool Equals(object obj)
        {
            Person otherPerson = obj as Person;
            return otherPerson.Name == this.Name && otherPerson.Age == this.Age;
        }
        public override int GetHashCode()
        {
            int hashCode = this.Name.GetHashCode()^this.Age.GetHashCode();
            return hashCode;
         
        }
    }
}
