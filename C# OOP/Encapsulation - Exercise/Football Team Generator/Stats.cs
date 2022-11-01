using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurace, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurace;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get { return endurance; }
            private set
            {
                if (value<0||value>100)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStats,nameof(this.Endurance)));
                }
                endurance = value;
            }
        }
        public int Sprint
        {
            get { return sprint; }
            private set
            {
                if (value<0||value>100)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStats,nameof(this.Sprint)));
                }
                sprint = value;
            }
        }

        public int Dribble
        {
            get { return dribble; }
            private set
            {
                if (value<0||value>100)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStats, nameof(this.Dribble)));
                }
                dribble = value;
            }
        }
        public int Passing
        {
            get { return passing; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStats, nameof(this.Passing)));
                }
                passing = value;
            }
        }
        public int Shooting
        {
            get { return shooting; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStats, nameof(this.Shooting)));
                }
                shooting = value;
            }
        }

    }
}
