using Explicit_Interfaces.Contracts;
using System;

namespace Explicit_Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            while ((command=Console.ReadLine())!="End")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                Citizen citizen = new Citizen(name);
                IResident resident = citizen;
                IPerson person = citizen;
                Console.WriteLine(citizen.Name);
                Console.WriteLine($"{resident.GetName()}{person.GetName()}");
            }
          
        }
    }
}
