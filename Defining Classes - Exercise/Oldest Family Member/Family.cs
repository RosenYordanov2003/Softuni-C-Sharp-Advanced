using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> Persons { get; set; } = new List<Person>();
        public void AddMember(Person person)
        {
            Persons.Add(person);
        }
        public Person GetOldestMember()
        {
            List<Person> orderList = Persons.OrderByDescending(x => x.Age).ToList();
            return orderList[0];
        }
    }
}
