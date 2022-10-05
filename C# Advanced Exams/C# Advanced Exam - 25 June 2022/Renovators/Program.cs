using System;
using System.Collections.Generic;

namespace Renovators
{
    public class StartUp
    {
        static void Main()
        {
            Catalog catalog = new Catalog("Quality renovators", 5, "Kitchen");
            Renovator renovator = new Renovator("Gosho", "Painter", 270, 7);
            Console.WriteLine(renovator);
            Console.WriteLine(catalog.AddRenovator(renovator));
            Console.WriteLine(catalog.RemoveRenovator("Pesho"));
            Renovator secondRenovator = new Renovator("Pesho", "Tiles", 200, 9);
            Renovator thirdRenovator = new Renovator("Ivan", "Tiles", 450, 7);
            Renovator fourthRenovator = new Renovator("Velichko", "Painter", 120, 3);
            Renovator fifthRenovator = new Renovator("Stamat", "Furniture", 300, 4);
            Renovator sixthRenovator = new Renovator("Genadi", "Furniture", 80, 15);
            Renovator seventhRenovator = new Renovator("Unufri", "Furniture", 80, 15);
            Console.WriteLine(catalog.AddRenovator(secondRenovator));
            Console.WriteLine(catalog.AddRenovator(thirdRenovator));
            Console.WriteLine(catalog.AddRenovator(fourthRenovator));
            Console.WriteLine(catalog.AddRenovator(fifthRenovator));
            Console.WriteLine(catalog.AddRenovator(sixthRenovator));
            Console.WriteLine(catalog.AddRenovator(seventhRenovator));
            Console.WriteLine(catalog.HireRenovator("Genadi"));
            List<Renovator> renovators = catalog.PayRenovators(8);
            foreach (var renovatorToBePaid in renovators)
            {
                Console.WriteLine(renovatorToBePaid);
            }
            Console.WriteLine(catalog.RemoveRenovatorBySpecialty("Painter"));
            Console.WriteLine("----------------------Report----------------------");
            Console.WriteLine(catalog.Report());

        }
    }
}
