using Food_Shortage.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Food_Shortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<IBuyer> list = new List<IBuyer>();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];
                    IBuyer currentRebel = new Rebel(name, age, group);
                    list.Add(currentRebel);
                }
                else
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string birthday = tokens[3];
                    IBuyer person = new Citizen(name, age, id, birthday);
                    list.Add(person);
                }
            }
            string command = string.Empty;
            while ((command=Console.ReadLine())!="End")
            {
                if (list.Any(x=>x.Name==command))
                {
                    IBuyer currentBuyer = list.First(x => x.Name == command);
                    currentBuyer.BuyFood();
                }
            }
            int sum = list.Sum(x => x.Food);
            Console.WriteLine(sum);
        }
    }
}
