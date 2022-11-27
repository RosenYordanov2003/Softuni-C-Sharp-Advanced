namespace SingletonDemo.Models
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Contracts;
    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> _capitals;
        private static SingletonDataContainer _instance = new SingletonDataContainer();
        private SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");
            _capitals = new Dictionary<string, int>();
            string inputFilePath = @"..\..\..\capital.txt";
            FileStream file = File.Create(inputFilePath);
            string[] elements = File.ReadAllLines(@"C:\Users\Home\source\repos\Design Patterns Lab\Singleton\capital.txt");
            for (int i = 0; i < elements.Length; i += 2)
            {
                _capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public static SingletonDataContainer Instance => _instance;
        public int GetPopulation(string name)
        {
            return _capitals[name];
        }
    }
}
