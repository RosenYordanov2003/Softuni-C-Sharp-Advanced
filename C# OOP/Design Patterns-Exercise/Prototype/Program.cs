using System;
using Prototype.Models;

namespace Prototype
{
    public class Program
    {
        static void Main(string[] args)
        {
            SandwichMenu menu = new SandwichMenu();
            menu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce,Tomato");
            menu["PB&J"] = new Sandwich("White", "", "", "Peanut butter and Jelly");
            menu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");
            Sandwich sandwich1 = menu["BLT"].Clone() as Sandwich;
            Sandwich sandwich2 = menu["Turkey"].Clone() as Sandwich;
            Sandwich sandwich3 = menu["PB&J"].Clone() as Sandwich;
        }
    }
}
