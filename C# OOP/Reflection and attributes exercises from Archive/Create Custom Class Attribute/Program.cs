using System;
using InfernoInfinity.Core.Contracts;
using InfernoInfinity.Core.Models;
using InfernoInfinity.CustomAttributes;
using InfernoInfinity.Repositories.Contracts;
using InfernoInfinity.Repositories.Models;
using InfernoInfinity.Weapons.Models;

namespace InfernoInfinity
{
    public class Program
    {
        static void Main(string[] args)
        {
            IRepository weaponRepository = new WeaponRepository();
            IEngine engine = new Engine(weaponRepository);
            //engine.Run();
            string command = Console.ReadLine();
            while (true)
            {
                if (command=="END")
                {
                    break;
                }

                GetAttribute(typeof(Weapon),command);
                command = Console.ReadLine();
            }
        }

        private static void GetAttribute(Type type,string command)
        {
            CustomAttribute attribute = (CustomAttribute)Attribute.GetCustomAttribute(type, typeof(CustomAttribute));
            if (command =="Author")
            {
                Console.WriteLine($"Author: {attribute.Author}");
            }
            else if (command== "Revision")
            {
                Console.WriteLine($"Revision: {attribute.Revision}");
            }
            else if (command=="Reviewers")
            {
                Console.WriteLine($"Reviewers: {attribute.Reviewers} ");
            }
            else
            {
                Console.WriteLine($"Class description: {attribute.Description}");
            }
        }
    }
}
