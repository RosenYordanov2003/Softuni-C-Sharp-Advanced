using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"A name should not be empty.");
                }
                name = value;
            }
        }
        public int Endurance
        {
            get { return endurance; }
            private set
            {
                if (value >= 0 && value <= 100)
                {
                    endurance = value;
                }
                else
                {
                    throw new ArgumentException($"Endurance should be between 0 and 100.");
                }
            }
        }
        public int Sprint
        {
            get { return sprint; }
            private set
            {
                if (value >= 0 && value <= 100)
                {
                    sprint = value;
                }
                else
                {
                    throw new ArgumentException($"Sprint should be between 0 and 100.");
                }
            }
        }
        public int Dribble
        {
            get { return dribble; }
            private set
            {
                if (value >= 0 && value <= 100)
                {
                    dribble = value;
                }
                else
                {
                    throw new ArgumentException($"Dribble should be between 0 and 100.");
                }
            }
        }
        public int Passing
        {
            get { return passing; }
            private set
            {
                if (value >= 0 && value <= 100)
                {
                    passing = value;
                }
                else
                {
                    throw new ArgumentException($"Passing should be between 0 and 100.");
                }
            }
        }
        public int Shooting
        {
            get { return shooting; }
            private set
            {
                if (value >= 0 && value <= 100)
                {
                    shooting = value;
                }
                else
                {
                    throw new ArgumentException($"Shooting should be between 0 and 100.");
                }
            }
        }
        private double CalculateOverralSkillLevel()
        {
            return (double)(Shooting + Dribble + Endurance + Passing + Sprint) / 5;
        }
        public double PlayerOverralSkillLevel()
        {
            return this.CalculateOverralSkillLevel();
        }
    }
}
