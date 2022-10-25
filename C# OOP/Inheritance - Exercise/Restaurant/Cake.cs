using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake:Dessert
    {
        public Cake(string name):base(name,CakePrice,CakeGrams,CakeCalories)
        {

        }
        public const double CakeGrams = 250;
        public const decimal CakePrice = 5;
        public const double CakeCalories = 1000;
    }
}
