using System;
using System.Collections.Generic;
using System.Reflection;

namespace TrafficLights
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //red -> green -> yellow -> 
            string[] startTrafficLights = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] newTrafficLight = new string[startTrafficLights.Length];
                for (int j = 0; j < newTrafficLight.Length; j++)
                {
                    Type type = typeof(TrafficLight);
                    newTrafficLight[j] = FindLight(startTrafficLights[j],type);
                }

                startTrafficLights = newTrafficLight;
                Console.WriteLine(string.Join(" ",newTrafficLight));
            }
        }

        private static string FindLight(string startTrafficLight, Type type)
        {
            TrafficLight obj = (TrafficLight)Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod("Light");
            return (string)method.Invoke(obj, new object[] { startTrafficLight });
        }
    }
}
