using System.Linq;

namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using Formula1.Models.Contracts;
    using Contracts;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => models;
        public void Add(IFormulaOneCar model)
        {
           this.models.Add(model);
        }

        public bool Remove(IFormulaOneCar model)
        {
          return this.models.Remove(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return this.models.FirstOrDefault(c => c.Model == name);
        }
    }
}
