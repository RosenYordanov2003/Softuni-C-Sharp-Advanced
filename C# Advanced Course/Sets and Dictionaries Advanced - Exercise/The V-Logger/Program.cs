using System;
using System.Linq;
using System.Collections.Generic;

namespace The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> dictionary = new Dictionary<string, Vlogger>();
            while (true)
            {
                string[] command = Console.ReadLine().Split(' ');
                if (command[0] == "Statistics")
                {
                    break;
                }
                if (command.Contains("joined"))
                {
                    string vlogger = command[0];
                    if (!dictionary.ContainsKey(vlogger))
                    {
                        dictionary[vlogger] = new Vlogger();
                    }
                }
                else if (command.Contains("followed"))
                {
                    string firstVlogger = command[0];
                    string secondVlogger = command[2];
                    if (firstVlogger != secondVlogger)
                    {
                        if (dictionary.ContainsKey(firstVlogger)&&dictionary.ContainsKey(secondVlogger))
                        {
                            dictionary[firstVlogger].Following.Add(secondVlogger);
                            dictionary[secondVlogger].Followers.Add(firstVlogger);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            PrintResult(dictionary);
        }

        static void PrintResult(Dictionary<string, Vlogger> dictionary)
        {
            Console.WriteLine($"The V-Logger has a total of {dictionary.Count} vloggers in its logs.");
            string theMostFamousVlogger = FindTheMostFamousVlogger(dictionary);
            int counter = 1;
            Console.WriteLine($"{counter}. {theMostFamousVlogger} : {dictionary[theMostFamousVlogger].Followers.Count} followers, {dictionary[theMostFamousVlogger].Following.Count} following");
            foreach (string follower in dictionary[theMostFamousVlogger].Followers.OrderBy(x=>x))
            {
                Console.WriteLine($"*  {follower}");
            }
            foreach (KeyValuePair<string,Vlogger> vlogger in dictionary.OrderByDescending(x=>x.Value.Followers.Count).ThenBy(x=>x.Value.Following.Count))
            {
                if (vlogger.Key==theMostFamousVlogger)
                {
                    continue;
                }
                else
                {
                    counter++;
                    Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");
                }
            }
        }

        static string FindTheMostFamousVlogger(Dictionary<string, Vlogger> dictionary)
        {
            string winner = string.Empty;
            int maxFolowers = int.MinValue;
            int minFollowing = 0;
            foreach (KeyValuePair<string, Vlogger> vlogger in dictionary)
            {
                if (vlogger.Value.Followers.Count>maxFolowers)
                {
                    maxFolowers=vlogger.Value.Followers.Count;
                    minFollowing=vlogger.Value.Following.Count;
                    winner=vlogger.Key;
                }
                else if (vlogger.Value.Followers.Count==maxFolowers)
                {
                    if (vlogger.Value.Following.Count< minFollowing)
                    {
                        winner=vlogger.Key;
                    }
                    else
                    {
                        continue;
                    }
 
                }
            }
            return winner;
        }
    }
    class Vlogger
    {

        public HashSet<string> Followers { get; set; } = new HashSet<string>();
        public HashSet<string> Following { get; set; } = new HashSet<string>();
    }

}
