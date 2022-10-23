using Generic_Scale;
using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<string> scale = new EqualityScale<string>("vesko","vesko");
            Console.WriteLine(scale.AreEqual());
            
        }
    }
}
