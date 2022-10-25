using System;
namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Coffee coffee = new Coffee("Lavazza", 2.10);
            Console.WriteLine(coffee.Price);
        }
    }
}
