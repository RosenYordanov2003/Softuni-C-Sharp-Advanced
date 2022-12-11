namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using Contracts;
    public class CocktailRepository : IRepository<ICocktail>
    {
        private List<ICocktail> models;

        public CocktailRepository()
        {
            models = new List<ICocktail>();
        }
        public IReadOnlyCollection<ICocktail> Models => models;
        public void AddModel(ICocktail model)
        {
          models.Add(model);
        }
    }
}
