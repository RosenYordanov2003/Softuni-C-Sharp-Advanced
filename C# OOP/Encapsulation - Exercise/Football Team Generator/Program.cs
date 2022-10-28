using System;
using System.Collections.Generic;
using System.Linq;


namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] tokens = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    string action = tokens[0];
                    if (action == "Team")
                    {
                        string teamName = tokens[1];
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    else if (action == "Add")
                    {
                        string teamToFind = tokens[1];
                        string playerName = tokens[2];
                        int endurace = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);
                        Team teamToAddPlayer = teams.FirstOrDefault(t => t.Name == teamToFind);
                        if (teamToAddPlayer != null)
                        {
                            Player player = new Player(playerName, endurace, sprint, dribble, passing, shooting);
                            teamToAddPlayer.AddPlayer(player);
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamToFind} does not exist.");
                        }
                    }
                    else if (action == "Remove")
                    {
                        string teamToFind = tokens[1];
                        string playerName = tokens[2];
                        Team teamToRemovePlayer = teams.FirstOrDefault(t => t.Name == teamToFind);
                        if (teamToRemovePlayer != null)
                        {
                            teamToRemovePlayer.Remove(playerName);
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamToFind} does not exist.");
                        }
                    }
                    else if (action == "Rating")
                    {
                        string teamToShowRating = tokens[1];
                        Team team = teams.FirstOrDefault(x => x.Name == teamToShowRating);
                        if (team != null)
                        {
                            Console.WriteLine($"{team.Name} - {team.Rating}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamToShowRating} does not exist.");
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

            }
        }
    }
}
