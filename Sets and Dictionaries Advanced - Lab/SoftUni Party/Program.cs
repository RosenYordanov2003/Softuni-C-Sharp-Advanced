using System;
using System.Collections.Generic;

namespace SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
           HashSet<string> normalGuests = new HashSet<string>();
           HashSet<string> vip = new HashSet<string>();
            string command;
            while ((command=Console.ReadLine())!="PARTY")
            {
                char firstChar = command[0];
                if (char.IsDigit(firstChar))
                {
                    vip.Add(command);
                    continue;
                }
                normalGuests.Add(command);
            }
            string command2;
            while ((command2 = Console.ReadLine()) != "END")
            {
                char firstChar = command2[0];
                if (!char.IsDigit(firstChar))
                {
                    if (normalGuests.Contains(command2))
                    {
                        normalGuests.Remove(command2);
                    }
                }
                else
                {
                    if (vip.Contains(command2))
                    {
                        vip.Remove(command2);
                    }
                }
            }
            int missedCountPeople = vip.Count + normalGuests.Count;
            Console.WriteLine(missedCountPeople);
            if (vip.Count>0)
            {
                Console.WriteLine(String.Join(Environment.NewLine,vip));
            }
            if (normalGuests.Count>0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, normalGuests));
            }
        }
    }
}
