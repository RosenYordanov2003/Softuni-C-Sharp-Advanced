namespace Template_Pattern.Models
{
    using System;
    public class Sourdough : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for Sourdough Bread.");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking Sourdough Bread (20 minutes)");
        }
    }
}
