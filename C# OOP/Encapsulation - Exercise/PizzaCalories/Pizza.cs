using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dough { get; set; }
        public int ToppingsCount => this.toppings.Count;
        public void AddTopping(Topping topping)
        {
            if (10 - this.toppings.Count > 0)
            {
                this.toppings.Add(topping);
            }
            else
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
        }
        private double CalculatePizzaCalories()
        {
            double sum = 0;
            sum = this.Dough.TotalCalories();
            foreach (Topping topping in this.toppings)
            {
                sum += topping.TotalCalories();
            }
            return sum;
        }
        public double TotalPizzaCalories()
        {
            return CalculatePizzaCalories();
        }

    }
}
