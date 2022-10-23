using System;
using System.Linq;
using System.Collections.Generic;

namespace Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> contestDictionary = new Dictionary<string, Dictionary<String, int>>();
            string command;
            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = command.Split(":");
                string contest = tokens[0];
                string password = tokens[1];
                if (!dictionary.ContainsKey(contest))
                {
                    dictionary[contest] = password;
                }
            }
            string secondCommand;
            while ((secondCommand = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = secondCommand.Split("=>");
                string currentContest = tokens[0];
                string currentPassword = tokens[1];
                string userName = tokens[2];
                int currentPoints = int.Parse(tokens[3]);
                if (dictionary.ContainsKey(currentContest) && dictionary[currentContest] == currentPassword)
                {
                    if (!contestDictionary.ContainsKey(userName))
                    {
                        contestDictionary.Add(userName,new Dictionary<String, int>());
                        contestDictionary[userName][currentContest] = currentPoints;
                    }
                    else if (!contestDictionary[userName].ContainsKey(currentContest))
                    {
                        contestDictionary[userName][currentContest] = currentPoints;
                    }
                    else
                    {
                        if (contestDictionary[userName][currentContest] < currentPoints)
                        {
                            contestDictionary[userName][currentContest] = currentPoints;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            PrintResult(contestDictionary);
        }

        static void PrintResult(Dictionary<string, Dictionary<string, int>> contestDictionary)
        {
           var theBstStudent = contestDictionary.OrderByDescending(x => x.Value.Values.Sum()).Take(1).ToDictionary(x=>x.Key,x=>x.Value);
            string winner = " ";
            int points = 0;
            foreach (var item in theBstStudent)
            {
                winner=item.Key;
                points = item.Value.Values.Sum();
                
            }
            Console.WriteLine($"Best candidate is {winner} with total {points} points.");
            Console.WriteLine("Ranking: ");
            foreach (KeyValuePair<string,Dictionary<string,int>> students in contestDictionary.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{students.Key}");
                foreach (KeyValuePair<string,int> contest in students.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
