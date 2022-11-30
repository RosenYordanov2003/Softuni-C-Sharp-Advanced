namespace Easter.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Contracts;
    using Models.Bunnies;
    using Easter.Models.Bunnies.Contracts;
    using Models.Dyes;
    using Models.Eggs;
    using Easter.Models.Eggs.Contracts;
    using Models.Workshops;
    using Easter.Models.Workshops.Contracts;
    using Repositories;
    using Easter.Repositories.Contracts;
    using Utilities.Messages;
    public class Controller : IController
    {
        private IRepository<IBunny> _bunnies;
        private IRepository<IEgg> _eggs;
        private IWorkshop _workshop;

        public Controller()
        {
            _bunnies = new BunnyRepository();
            _eggs = new EggRepository();
            _workshop = new Workshop();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (!IsValidBunnyType(bunnyType))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            IBunny bunny = CreateBunny(bunnyType, bunnyName);
            _bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunny.GetType().Name, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = _bunnies.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            bunny.AddDye(new Dye(power));
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            _eggs.Add(egg);
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            List<IBunny> bunnies = _bunnies.Models.Where(b => b.Energy >= 50).OrderByDescending(b => b.Energy).ToList();
            IEgg egg = _eggs.FindByName(eggName);
            if (bunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            foreach (IBunny bunny in bunnies)
            {
                _workshop.Color(egg, bunny);
                if (bunny.Energy <= 0)
                {
                    _bunnies.Remove(bunny);
                }
            }
            if (egg.IsDone())
            {
                return string.Format(OutputMessages.EggIsDone, eggName);
            }
            return string.Format(OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{_eggs.Models.Where(e => e.IsDone()).Count()} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach (IBunny bunny in _bunnies.Models)
            {
                sb.AppendLine(bunny.ToString());
            }
            return sb.ToString().Trim();
        }

        private bool IsValidBunnyType(string bunnyType)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(Bunny))
                .FirstOrDefault(t => t.Name == bunnyType);
            if (type == null)
            {
                return false;
            }
            return true;
        }

        private IBunny CreateBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else
            {
                bunny = new SleepyBunny(bunnyName);
            }
            return bunny;
        }
    }
}
