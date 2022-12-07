namespace EasterRaces.Repositories.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using EasterRaces.Models.Cars.Contracts;
    using Contracts;

    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>();
        }
        public ICar GetByName(string name)
        {
            return cars.FirstOrDefault(c => c.Model == name);
        }

        public IReadOnlyCollection<ICar> GetAll() => cars;

        public void Add(ICar model)
        {
            cars.Add(model);
        }

        public bool Remove(ICar model)
        {
            return cars.Remove(model);
        }
    }
}
