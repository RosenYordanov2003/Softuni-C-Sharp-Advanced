namespace Formula1.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Utilities;
    using Contracts;
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace ;
        private ICollection<IPilot> pilots;

        public Race(string raceName, int laps)
        {
            RaceName = raceName;
            NumberOfLaps = laps;
            tookPlace = false;
            this.pilots = new List<IPilot>();
        }
        public string RaceName
        {
            get { return this.raceName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get { return this.numberOfLaps; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                numberOfLaps = value;
            }
        }

        public bool TookPlace
        {
            get { return this.tookPlace; }
            set { tookPlace = value; }
        }

        public ICollection<IPilot> Pilots => pilots;
        public void AddPilot(IPilot pilot)
        {
          this.pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The { RaceName } race has:");
            sb.AppendLine($"Participants: { Pilots.Count }");
            sb.AppendLine($"Number of laps: { NumberOfLaps }");
            string tookPlaceResult = TookPlace == true ? "Yes" : "No";
            sb.AppendLine($"Took place: { tookPlaceResult }");
            return sb.ToString().TrimEnd();
        }
    }
}
