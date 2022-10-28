using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int baseCalories = 2;
        private int weight;
        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        private string FlourType
        {
            get { return flourType; }
            set
            {
                if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
                {
                    flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        private string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                value = value.ToLower();
                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }
        private int Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }
        public int BaseCaloriesPerGram => baseCalories;
        public double TotalCalories()
        {
            return this.CalculateCalories();
        }
        private double CalculateCalories()
        {
            double sum = 0;
            this.FlourType = FlourType.ToLower();
            if (this.FlourType == "white")
            {
                if (this.BakingTechnique == "crispy")
                {
                    sum = (baseCalories * weight) * 1.5 * 0.9;
                }
                else if (this.BakingTechnique == "chewy")
                {
                    sum = (baseCalories * weight) * 1.5 * 1.1;
                }
                else
                {
                    sum = (baseCalories * weight) * 1.5 * 1.0;
                }
            }
            else
            {
                if (this.BakingTechnique == "crispy")
                {
                    sum = (baseCalories * weight) * 1.0 * 0.9;
                }
                else if (this.BakingTechnique == "chewy")
                {
                    sum = (baseCalories * weight) * 1.0 * 1.1;
                }
                else
                {
                    sum = (baseCalories * weight) * 1.0 * 1.0;
                }
            }
            return sum;
        }
    }
}
