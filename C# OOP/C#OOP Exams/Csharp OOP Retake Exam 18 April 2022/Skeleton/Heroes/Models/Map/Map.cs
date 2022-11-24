using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<Knight> knights = new List<Knight>();
            AddKnights(knights, players);
            List<Barbarian> barbarians = new List<Barbarian>();
            AddBarbarians(barbarians, players);
            int deadKnights = 0;
            int deadBarbarians = 0;
            while (barbarians.Count > 0 && knights.Count > 0)
            {
                deadBarbarians = KnightsAttack(knights, barbarians, deadBarbarians);

                deadKnights = BarbarianAttack(knights, barbarians, deadKnights);
            }
            string result = knights.Count > 0 ? $"The knights took {deadKnights} casualties but won the battle." : $"The barbarians took {deadBarbarians} casualties but won the battle.";
            return result;
        }

        private static int BarbarianAttack(List<Knight> knights, List<Barbarian> barbarians, int deadKnights)
        {
            for (int i = 0; i < knights.Count; i++)
            {
                for (int z = 0; z < barbarians.Count; z++)
                {
                    if (barbarians[z].IsAlive == true)
                    {
                        knights[i].TakeDamage(barbarians[z].Weapon.DoDamage());
                        if (knights[i].Health <= 0)
                        {
                            knights.Remove(knights[i]);
                            deadKnights++;
                            i--; 
                            break;
                        }
                    }
                }
            }

            return deadKnights;
        }

        private static int KnightsAttack(List<Knight> knights, List<Barbarian> barbarians, int deadBarbarians)
        {
            for (int z = 0; z < barbarians.Count; z++)
            {
                for (int i = 0; i < knights.Count; i++)
                {
                    if (knights[i].IsAlive == true)
                    {
                        barbarians[z].TakeDamage(knights[i].Weapon.DoDamage());
                        if (barbarians[z].Health <= 0)
                        {
                            barbarians.Remove(barbarians[z]);
                            deadBarbarians++;
                            z--;
                            break;
                        }
                    }
                }
            }

            return deadBarbarians;
        }

        private void AddKnights(List<Knight> knights, ICollection<IHero> players)
        {
            foreach (IHero hero in players)
            {
                if (hero is Knight knight)
                {
                    if (knight.IsAlive == true)
                    {
                        knights.Add(knight);
                    }
                }
            }
        }
        private void AddBarbarians(List<Barbarian> barbarians, ICollection<IHero> players)
        {
            foreach (IHero hero in players)
            {
                if (hero is Barbarian barbarian)
                {
                    if (barbarian.IsAlive == true)
                    {
                        barbarians.Add(barbarian);
                    }
                }
            }
        }
    }
}
