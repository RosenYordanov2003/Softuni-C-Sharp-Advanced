using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;
        public Team(string name, int openPositions, char group)
        {
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;
            players = new List<Player>();
        }

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count
        {
            get { return this.players.Count; }
        }
        public string AddPlayer(Player player)
        {
            string message = string.Empty;
            if (string.IsNullOrEmpty(player.Name)||string.IsNullOrEmpty(player.Position))
            {
                message = "Invalid player's information.";
            }
            else if (player.Rating < 80)
            {
                message = "Invalid player's rating.";
            }
            else if (this.OpenPositions - this.players.Count > 0)
            {
                this.OpenPositions--;
                message = $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
            }
            else
            {
                message = "There are no more open positions.";
            }
            return message;
        }
        public bool RemovePlayer(string name)
        {
            bool isExist = false;
            Player playerToRemove = players.FirstOrDefault(x => x.Name == name);
            if (playerToRemove != null)
            {
                isExist = true;
                this.players.Remove(playerToRemove);
                this.OpenPositions++;
            }
            return isExist;
        }
        public int RemovePlayerByPosition(string position)
        {
            int countRemovedPlayers = 0;
            for (int i = 0; i < players.Count; i++)
            {
                Player currentPlayer = players[i];
                if (currentPlayer.Position == position)
                {
                    players.Remove(currentPlayer);
                    countRemovedPlayers++;
                    this.OpenPositions++;
                    i--;
                }
            }
            return countRemovedPlayers;
        }
        public Player RetirePlayer(string name)
        {
            Player playerToFind = players.FirstOrDefault(x => x.Name == name);
            if (playerToFind != null)
            {
                playerToFind.Retired = true;
                return playerToFind;
            }
            return null;
        }
        public List<Player> AwardPlayers(int games)
        {
            List<Player> list = players.Where(x => x.Games >= games).ToList();
            return list;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}");
            foreach (Player people in players.Where(x => x.Retired != true))
            {
                sb.AppendLine(people.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
