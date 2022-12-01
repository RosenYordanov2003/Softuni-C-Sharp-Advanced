namespace AquaShop.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using AquaShop.Models.Fish.Contracts;
    using System.Reflection;
    using System.Collections.Generic;
    using Contracts;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using Repositories;
    using AquaShop.Repositories.Contracts;
    using Models.Aquariums;
    using Utilities.Messages;
    using Models.Decorations;
    using Models.Fish;

    public class Controller : IController
    {
        private IRepository<IDecoration> decorationRepository;
        private List<IAquarium> aquariums;

        public Controller()
        {
            decorationRepository = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (!ValidateType(aquariumType, typeof(Aquarium)))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            IAquarium aquarium = CreateAquarium(aquariumType, aquariumName);
            this.aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (!ValidateType(decorationType, typeof(Decoration)))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            IDecoration decoration = CreateDecoration(decorationType);
            this.decorationRepository.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decorationToInsert = decorationRepository.FindByType(decorationType);
            if (decorationToInsert == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            decorationRepository.Remove(decorationToInsert);
            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);
            aquarium.AddDecoration(decorationToInsert);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (!ValidateType(fishType, typeof(Fish)))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IFish fish = CreateFish(fishType, fishName, fishSpecies, price);
            IAquarium aquarium = aquariums.First(a => a.Name == aquariumName);
            if (!CheckAquariumWater(aquarium, fish))
            {
                return OutputMessages.UnsuitableWater;
            }
            aquarium.AddFish(fish);

            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);
            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);
            decimal fishValue = aquarium.Fish.Select(f => f.Price).Sum();
            decimal decorationValue = aquarium.Decorations.Select(d => d.Price).Sum();
            decimal totalValue = fishValue + decorationValue;
            return string.Format($"The value of Aquarium {aquariumName} is {totalValue:F2}.");
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IAquarium aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().Trim();
        }


        private bool ValidateType(string typeToFind, Type basType)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == basType)
                .FirstOrDefault(t => t.Name == typeToFind);
            return type == null ? false : true;
        }

        private IAquarium CreateAquarium(string type, string name)
        {
            IAquarium aquarium;
            if (type == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(name);
            }
            else
            {
                aquarium = new FreshwaterAquarium(name);
            }

            return aquarium;
        }

        private IDecoration CreateDecoration(string type)
        {
            IDecoration decoration;
            if (type == "Ornament")
            {
                decoration = new Ornament();
            }
            else
            {
                decoration = new Plant();
            }

            return decoration;
        }


        private IFish CreateFish(string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }

            return fish;
        }

        private bool CheckAquariumWater(IAquarium aquarium, IFish fish)
        {
            if (fish.GetType().Name == "FreshwaterFish")
            {
                if (aquarium.GetType().Name == "FreshwaterAquarium")
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (aquarium.GetType().Name == "FreshwaterAquarium")
                {
                    return false;
                }

                return true;
            }
        }
    }
}
