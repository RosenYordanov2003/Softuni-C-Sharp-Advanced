namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;
    using ChristmasPastryShop.Models.Booths.Contracts;
    using Contracts;

    public class BoothRepository : IRepository<IBooth>
    {
        private List<IBooth> models;

        public BoothRepository()
        {
            models = new List<IBooth>();
        }
        public IReadOnlyCollection<IBooth> Models => models;
        public void AddModel(IBooth model)
        {
          models.Add(model);
        }
    }
}
