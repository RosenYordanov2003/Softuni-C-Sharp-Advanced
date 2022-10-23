using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public Guild(string name, int capacity)
        {
            this.roster = new List<Player>();
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.roster.Count; } }
        public void AddPlayer(Player player)
        {
            if (this.Capacity - this.roster.Count > 0)
            {
                this.roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            Player playerToRemove = this.roster.FirstOrDefault(x => x.Name == name);
            if (playerToRemove != null)
            {
                this.roster.Remove(playerToRemove);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            Player playerToPromote = this.roster.First(x => x.Name == name);
            if (playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            Player playerToDeomote = this.roster.First(x => x.Name == name);
            if (playerToDeomote.Rank != "Trial")
            {
                playerToDeomote.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string @class)
        {
            Player[] PlayersToRemove = this.roster.Where(x => x.Class == @class).ToArray();
            for (int i = 0; i < PlayersToRemove.Length; i++)
            {
                Player currentPlayer = PlayersToRemove[i];
                this.roster.Remove(currentPlayer);
            }
            return PlayersToRemove;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (Player player in this.roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
