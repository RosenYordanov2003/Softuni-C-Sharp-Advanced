using System;
using SingletonDemo.Contracts;
using SingletonDemo.Models;

namespace SingletonDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            ISingletonContainer container1 = SingletonDataContainer.Instance;
            ISingletonContainer container2 = SingletonDataContainer.Instance;
            ISingletonContainer container3 = SingletonDataContainer.Instance;
            ISingletonContainer container4 = SingletonDataContainer.Instance;
        }
    }
}
