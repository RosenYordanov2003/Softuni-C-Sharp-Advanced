namespace CarRacing.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarRacing.Models.Cars.Contracts;
    using Contracts;
    using Utilities.Messages;
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models => cars;
        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }
            this.cars.Add(model);
        }

        public bool Remove(ICar model)
        {
           return cars.Remove(model);
        }

        public ICar FindBy(string property)
        {
            return cars.FirstOrDefault(c => c.VIN == property);
        }
    }
}
