using System;
using System.Collections.Generic;
using System.Linq;

namespace Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> invitationsGuests = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> filters = new List<string>();
            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] tokens = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                if (action == "Add filter")
                {
                    string format = $"{tokens[1]};{tokens[2]}";
                    filters.Add(format);
                }
                else
                {
                    string format = $"{tokens[1]};{tokens[2]}";
                    if (filters.Contains(format))
                    {
                        filters.Remove(format);
                    }
                }
            }
            AcceptGuests(filters, invitationsGuests);
            Console.WriteLine(string.Join(" ", invitationsGuests));
        }

        static void AcceptGuests(List<string> filters, List<string> invitationsGuests)
        {
            for (int i = 0; i < filters.Count; i++)
            {
                string[] currentFiler = filters[i].Split(";", StringSplitOptions.RemoveEmptyEntries);
                string action = currentFiler[0];
                string criteria=currentFiler[1];
                invitationsGuests.RemoveAll(GetPredicate(action, criteria));
            }
        }

        static Predicate<string> GetPredicate(string action, string criteriaToSearch)
        {
            if (action == "Starts with")
            {
                return name => name.StartsWith(criteriaToSearch);
            }
            else if (action == "Ends with")
            {
                return name => name.EndsWith(criteriaToSearch);
            }
            else if (action == "Contains")
            {
                return name => name.Contains(criteriaToSearch);
            }
            else
            {
                int length = int.Parse(criteriaToSearch);
                return name => name.Length == length;
            }
        }
    }
}
