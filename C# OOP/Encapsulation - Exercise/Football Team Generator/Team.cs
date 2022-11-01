using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private List<Player> players;
        private string teamName;
        private Team()
        {
            this.players = new List<Player>();
        }
        public Team(string teamName) : this()
        {
            this.TeamName = teamName;
        }
        public string TeamName
        {
            get { return teamName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameShouldNotBeEmpty);
                }
                teamName = value;
            }
        }
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = this.players.FirstOrDefault(p => p.Name == playerName);
            if (playerToRemove!=null)
            {
                this.players.Remove(playerToRemove);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotExistingPlayer, playerName, this.TeamName));
            }
        }

        public int Rating => this.players.Count > 0 ? (int)(Math.Round(this.players.Average(p => p.SkillRating))) : 0;
        public override string ToString()
        {
            return $"{this.TeamName} - {this.Rating}";
        }
    }
}
