using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private int rating;
        private List<Player> players;
        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }
        public string Name { get; set; }
        public int Rating
        {
            get
            {
                double ratingsSum = 0;

                foreach (var player in players)
                {
                    ratingsSum += player.PlayerOverralSkillLevel();
                }

                return rating = (int)Math.Round(ratingsSum);
            }
        }
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void Remove(string playerName)
        {
            Player playerToRemove = this.players.FirstOrDefault(p => p.Name == playerName);
            if (playerToRemove != null)
            {
                this.players.Remove(playerToRemove);
            }
            else
            {
                Console.WriteLine($"Player {playerName} is not in {this.Name} team.");
            }
        }
    }
}
