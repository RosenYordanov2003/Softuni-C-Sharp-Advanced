using Explicit_Interfaces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Explicit_Interfaces
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }

        string IPerson.GetName()
        {
           return Name;
        }
        string IResident.GetName()
        {
            return "Mr/Ms/Mrs ";
        }
    }
}
