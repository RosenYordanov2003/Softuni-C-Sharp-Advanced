using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] personsInformation = Console.ReadLine().Split(new char[] {';','='}, StringSplitOptions.RemoveEmptyEntries);
            List<Person> persons = new List<Person>();
            for (int i = 0; i < personsInformation.Length; i+=2)
            {
                try
                {
                    Person person = new Person(personsInformation[i], decimal.Parse(personsInformation[i+1]));
                    persons.Add(person);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    return;
                }
            }
            string[] productsInfromation = Console.ReadLine().Split(new char[] {';','='}, StringSplitOptions.RemoveEmptyEntries);
            List<Product> products = new List<Product>();
            for (int i = 0; i < productsInfromation.Length; i+=2)
            {
                try
                {
                    Product product = new Product(productsInfromation[i], decimal.Parse(productsInfromation[i+1]));
                    products.Add(product);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    return;
                }
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string buyer = tokens[0];
                string productToBuy = tokens[1];
                Person currentPerson = persons.Find(x => x.Name == buyer);
                Product currentProduct = products.Find(x => x.Name == productToBuy);
                currentPerson.AddProduct(currentProduct);
            }
            foreach (Person person in persons)
            {
                if (person.Products.Count == 0)
                {
                     Console.WriteLine($"{person.Name} - Nothing bought ");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products)}");
                }
            }
        }
    }
}
