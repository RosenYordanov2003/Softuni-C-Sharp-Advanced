using System;
using System.Collections.Generic;
using System.Linq;

namespace Border_Control
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IIDentifiable> list = new List<IIDentifiable>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 2)
                {
                    Robot currentRobot = new Robot(tokens[0], tokens[1]);
                    list.Add(currentRobot);
                }
                else
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    Person currentPerson = new Person(name, age, id);
                    list.Add(currentPerson);
                }
            }
            string endId = Console.ReadLine();
            list = list.Where(GetPredicate(endId)).ToList();
            list.ForEach(x => Console.WriteLine(x.Id));
        }

        static Func<IIDentifiable, bool> GetPredicate(string endId)
        {
            return x => x.Id.EndsWith(endId);
        }
    }
}
