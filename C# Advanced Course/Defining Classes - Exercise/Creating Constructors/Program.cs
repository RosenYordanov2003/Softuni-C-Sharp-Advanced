using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int ages = int.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            Person defaultPerson = new Person();
            Person secondPerson = new Person(ages);
            Person thirdPerson = new Person(name,ages);
            Console.WriteLine(thirdPerson.Name);
            Console.WriteLine(thirdPerson.Age);
        }
    }
}
