using Raiding.Factories;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding
{
    public class Engine : IEngine
    {
        private Factory factory;
        private ICollection<BaseHero> heroes;
        public Engine()
        {
            this.factory = new Factory();
            this.heroes = new List<BaseHero>();
        }
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                try
                {
                    BaseHero hero = factory.CreateHero(heroName, heroType);
                    heroes.Add(hero);
                }
                catch (ArgumentException exception)
                {
                    i--;
                    Console.WriteLine(exception.Message);
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            PrintResult(bossPower);
        }

        private void PrintResult(int bossPower)
        {
            int totalHeroesSum = heroes.Select(h => h.Power).ToArray().Sum();
            foreach (BaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }
            string result = totalHeroesSum >= bossPower ? "Victory!" : "Defeat...";
            Console.WriteLine(result);
        }
    }
}
