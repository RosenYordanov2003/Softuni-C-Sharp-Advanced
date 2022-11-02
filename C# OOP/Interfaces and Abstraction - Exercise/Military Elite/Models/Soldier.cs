using Military_Elite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Models
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}";
        }
    }
}
