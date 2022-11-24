using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroes = new List<IHero>();
        public IReadOnlyCollection<IHero> Models => heroes;

        public void Add(IHero model)
        {
            this.heroes.Add(model);
        }

        public IHero FindByName(string name)
        {
            return this.heroes.FirstOrDefault(h => h.Name == name);
        }

        public bool Remove(IHero model)
        {
            IHero hero = this.heroes.FirstOrDefault(h => h.Name == model.Name);
            return this.heroes.Remove(hero);
        }
    }
}
