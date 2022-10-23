using System;
using System.Linq;
using System.Collections.Generic;

namespace ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, ForceUser> dictionary = new Dictionary<string, ForceUser>();
            string[] separators = new string[] { "|", "->" };
            string command;
            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                bool isExist = false;
                string[] tokens = command.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (command.Contains('|'))
                {
                    string sideToJoin = tokens[0];
                    sideToJoin = sideToJoin.Trim();
                    string name = tokens[1];
                    name = name.Trim();
                    isExist = CheckIfTheUserExist(dictionary,name);
                    if (!dictionary.ContainsKey(sideToJoin))
                    {
                        dictionary[sideToJoin] = new ForceUser();

                    }
                    if (!isExist)
                    {
                        dictionary[sideToJoin].HashSet.Add(name);
                    }
                }
                else if (command.Contains("->"))
                {
                    string name = tokens[0];
                    string sideToSearch = string.Empty;
                    name = name.Trim();
                    string side = tokens[1];
                    side = side.Trim();
                    if (dictionary.ContainsKey(side))
                    {
                        foreach (KeyValuePair<string, ForceUser> item in dictionary)
                        {
                            string currentKey = item.Key;
                            foreach (string user in item.Value.HashSet)
                            {
                                if (user == name)
                                {
                                    sideToSearch = currentKey;
                                    break;
                                }
                            }
                        }
                        if (sideToSearch != string.Empty)
                        {
                            dictionary[sideToSearch].HashSet.Remove(name);
                        }

                        dictionary[side].HashSet.Add(name);

                    }
                    else
                    {
                        string key = string.Empty;
                        dictionary[side] = new ForceUser();
                        foreach (KeyValuePair<string, ForceUser> item in dictionary)
                        {
                            string currentKey = item.Key;
                            foreach (string user in item.Value.HashSet)
                            {
                                if (user == name)
                                {
                                    key = currentKey;
                                    break;
                                }
                            }
                        }
                        if (key != string.Empty)
                        {
                            dictionary[key].HashSet.Remove(name);
                        }

                        dictionary[side].HashSet.Add(name);
                    }
                    Console.WriteLine($"{name} joins the {side} side!");
                }
            }
            PrintResult(dictionary);
        }

        static bool CheckIfTheUserExist(Dictionary<string, ForceUser> dictionary,string name)
        {
            foreach (KeyValuePair<string, ForceUser> forceSide in dictionary)
            {
               
                foreach (string user in forceSide.Value.HashSet)
                {
                    if (name==user)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static void PrintResult(Dictionary<string, ForceUser> dictionary)
        {
            foreach (KeyValuePair<string, ForceUser> item in dictionary.Where(x => x.Value.HashSet.Count > 0).OrderByDescending(x => x.Value.HashSet.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {item.Key}, Members: {item.Value.HashSet.Count}");
                foreach (string user in item.Value.HashSet.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }

    }
    class ForceUser
    {
        public HashSet<string> HashSet { get; set; } = new HashSet<string>();
    }
}

