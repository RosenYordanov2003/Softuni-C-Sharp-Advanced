using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private int weight;
        private  int baseCalories = 2;
        public Topping(string topping, int weight)
        {
            this.ToppingType = topping;
            this.Weight = weight;
        }
        private string ToppingType
        {
            get { return toppingType; }
            set
            {
                if (value == "meat" || value == "sauce" || value == "cheese" || value == "veggies" || value == "Meat" || value == "Sauce" || value == "Cheese" || value == "Veggies")
                {
                    toppingType = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        private int Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
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
            this.ToppingType = toppingType.ToLower();
            if (this.ToppingType == "cheese")
            {
                sum = 1.1 * this.Weight * baseCalories;
            }
            else if (this.ToppingType == "sauce")
            {
                sum = 0.9 * this.Weight * baseCalories;
            }
            else if (this.ToppingType == "meat")
            {
                sum = 1.2 * this.Weight * baseCalories;
            }
            else
            {
                sum = 0.8 * this.Weight * baseCalories;
            }
            return sum;
        }
    }
}