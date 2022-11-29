namespace CarRacing.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarRacing.Models.Racers.Contracts;
    using Contracts;
    using Utilities.Messages;
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> racers;

        public RacerRepository()
        {
            racers = new List<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models => racers;
        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            racers.Add(model);
        }

        public bool Remove(IRacer model)
        {
            return this.racers.Remove(model);
        }

        public IRacer FindBy(string property)
        {
            return racers.FirstOrDefault(r => r.Username == property);
        }
    }
}
