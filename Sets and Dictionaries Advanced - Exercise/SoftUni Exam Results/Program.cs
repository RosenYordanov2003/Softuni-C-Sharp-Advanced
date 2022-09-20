using System;
using System.Collections.Generic;
using System.Linq;
namespace SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> personalityResults = new Dictionary<string, int>();
            Dictionary<string, int> contests = new Dictionary<string, int>();
            string command;
            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] tokens = command.Split('-');

                string name = tokens[0];
                if (command.Contains("banned"))
                {
                    if (personalityResults.ContainsKey(name))
                    {
                        personalityResults.Remove(name);
                    }
                    continue;
                }
                string contest = tokens[1];
                int points = int.Parse(tokens[2]);
                if (!personalityResults.ContainsKey(name))
                {
                    personalityResults[name] = points;
                    if (!contests.ContainsKey(contest))
                    {
                        contests[contest] = 0;
                    }
                    contests[contest]++;
                }
                else if (personalityResults.ContainsKey(name))
                {
                    contests[contest]++;
                    if (personalityResults[name] < points)
                    {
                        personalityResults[name] = points;
                    }
                }
            }
            PrintResult(personalityResults, contests);
        }

        static void PrintResult(Dictionary<string, int> personalityResults, Dictionary<string, int> contests)
        {
            Console.WriteLine("Results:");
            foreach (KeyValuePair<string,int> studet in personalityResults.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{studet.Key} | {studet.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (KeyValuePair<string,int> contest in contests.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{contest.Key} - {contest.Value}");
            }
        }
    }
}
