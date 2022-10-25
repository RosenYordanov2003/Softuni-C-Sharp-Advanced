using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            ///Person person = new Person(name, age);
            Child child = new Child(name, age);
            //Console.WriteLine(person);
            Console.WriteLine(child);
        }
    }
}