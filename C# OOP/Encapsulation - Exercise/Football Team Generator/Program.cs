using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Program
    {
        private static List<Team> teamList;
        static void Main(string[] args)
        {
            teamList = new List<Team>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] tokens = command.Split(';');
                    string action = tokens[0];
                    if (action == "Team")
                    {
                        string teamName = tokens[1];
                        AddTeam(teamName);
                    }
                    else if (action == "Add")
                    {
                        string team = tokens[1];
                        Team teamToAddPlayer = teamList.FirstOrDefault(t => t.TeamName == team);
                        if (teamToAddPlayer != null)
                        {
                            Player newPlayer = CreateNewPlayer(tokens);
                            teamToAddPlayer.AddPlayer(newPlayer);
                        }
                        else
                        {
                            throw new InvalidOperationException(string.Format(ExceptionMessages.NotExistingTeam, team));
                        }
                    }
                    else if (action == "Remove")
                    {
                        RemovePlayer(tokens);
                    }
                    else if (action == "Rating")
                    {
                        string teamName = tokens[1];
                        ShowRating(teamName);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }

        static void ShowRating(string teamName)
        {
            Team teamToShowRating = teamList.FirstOrDefault(t => t.TeamName == teamName);
            if (teamToShowRating!=null)
            {
                Console.WriteLine(teamToShowRating);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotExistingTeam, teamName));
            }
        }

        static void RemovePlayer(string[] tokens)
        {
            string teamName = tokens[1];
            Team teamToSearch = teamList.FirstOrDefault(t => t.TeamName == teamName);
            if (teamToSearch != null)
            {
                string playerName = tokens[2];
                teamToSearch.RemovePlayer(playerName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotExistingTeam, teamName));
            }
        }

        static Player CreateNewPlayer(string[] tokens)
        {
            string playerName = tokens[2];
            int endurace = int.Parse(tokens[3]);
            int sprint = int.Parse(tokens[4]);
            int dribble = int.Parse(tokens[5]);
            int passing = int.Parse(tokens[6]);
            int shooting = int.Parse(tokens[7]);
            Player player = new Player(playerName, endurace, sprint, dribble, passing, shooting);
            return player;
        }

        static void AddTeam(string teamName)
        {
            Team team = new Team(teamName);
            teamList.Add(team);
        }
    }
}
