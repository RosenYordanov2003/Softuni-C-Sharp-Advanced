namespace Command_Pattern.Models
{
    using System;
    public class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public string Name { get; set; }
        public int Price { get; set; }

        public void IncreasePrice(int amount)
        {
            if (amount < Price)
            {
                Price += amount;
                Console.WriteLine($"Price for the {Name} has been increased with amount {amount}$.");
            }
        }

        public void DecreasePrice(int amount)
        {
            Price -= amount;
            Console.WriteLine($"Price for the {Name} has been decreased with amount {amount}$.");
        }

        public override string ToString() => $"Current price for the {Name} product is {Price}$.";
    }
}
