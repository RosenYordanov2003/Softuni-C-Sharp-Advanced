using System;
using System.Collections.Generic;

namespace Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(",",StringSplitOptions.RemoveEmptyEntries);
                string direction = tokens[0];
                string carNumber = tokens[1];
                if (direction == "IN")
                {
                    set.Add(carNumber);
                }
                else
                {
                    if (set.Contains(carNumber))
                    {
                        set.Remove(carNumber);
                    }
                }
            }
            if (set.Count==0)
            {
                Console.WriteLine("Parking Lot is Empty");
                Environment.Exit(0);
            }
            Console.WriteLine(string.Join(Environment.NewLine,set));
        }
    }
}
