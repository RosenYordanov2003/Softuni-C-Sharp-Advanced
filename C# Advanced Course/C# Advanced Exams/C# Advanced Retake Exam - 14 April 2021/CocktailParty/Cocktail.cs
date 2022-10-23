using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> Ingredients;
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
           this.Ingredients = new List<Ingredient>();
           this.Name = name;
           this.Capacity = capacity;
           this.MaxAlcoholLevel = maxAlcoholLevel;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => this.Ingredients.Sum(x => x.Alcohol);
        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.Any(x => x.Name == ingredient.Name) && (this.Capacity - this.Ingredients.Count >= 0) && (ingredient.Alcohol <= this.MaxAlcoholLevel))
            {
                this.Ingredients.Add(ingredient);
                this.MaxAlcoholLevel -= ingredient.Alcohol;
            }
        }
        public bool Remove(string name)
        {
            bool isExist = false;
            Ingredient ingredientToRemove = this.Ingredients.FirstOrDefault(x => x.Name == name);
            if (ingredientToRemove!=null)
            {
                isExist = true;
                this.Ingredients.Remove(ingredientToRemove);
                this.MaxAlcoholLevel += ingredientToRemove.Alcohol;
            }
            return isExist;
        }
        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredientToFind = this.Ingredients.FirstOrDefault(x => x.Name == name);
            if (ingredientToFind!=null)
            {
                return ingredientToFind;
            }
            return null;
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            return this.Ingredients.OrderByDescending(x => x.Alcohol).First();
        }
 
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (Ingredient ingredient in this.Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
