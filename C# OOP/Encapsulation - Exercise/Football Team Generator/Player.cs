using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            this.Stats = new Stats(endurance, sprint, dribble, passing, shooting);
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameShouldNotBeEmpty);
                }
                name = value;
            }
        }
        public Stats Stats { get; set; }
        public double SkillRating => CalculateSkillOverall();
        private double CalculateSkillOverall() => (this.Stats.Endurance + this.Stats.Sprint + this.Stats.Dribble + this.Stats.Passing + this.Stats.Shooting) / 5.0;
       
    }
}
