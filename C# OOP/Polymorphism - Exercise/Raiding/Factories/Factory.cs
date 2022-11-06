namespace Raiding.Factories
{
    using System;
    using Models;
    using Contracts;
    using Exceotions;

    public class Factory : IFactory
    {
        public BaseHero CreateHero(string name,string typeHero)
        {
            BaseHero hero = null;
            if (typeHero == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (typeHero == "Druid")
            {
                hero = new Druid(name);
            }
            else if (typeHero=="Rogue")
            {
                hero = new Rogue(name);
            }
            else if (typeHero== "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.INVALID_HERO_TYPE);
            }
            return hero;
        }
    }
}
