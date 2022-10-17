using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ComparingObjects
{
    public class Person:IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
           this.Name = name;
           this.Age = age;
           this.Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo([AllowNull] Person other)
        {
            int result = 0;
            result = this.Name.CompareTo(other.Name);
            if (result != 0)
            {
                return result;
            }
            result = this.Age.CompareTo(other.Age);
            if (result!=0)
            {
                return result;
            }
            result = this.Town.CompareTo(other.Town);
            return result;
        }
    }
}
