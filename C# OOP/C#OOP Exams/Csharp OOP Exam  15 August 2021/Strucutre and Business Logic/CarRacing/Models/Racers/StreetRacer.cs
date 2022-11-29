namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    public class StreetRacer : Racer
    {
        private const int InitialDrivingExperience = 10;
        private const string InitialRacerBehavior = "aggressive";
        public StreetRacer(string userName, ICar car) : base(userName, InitialRacerBehavior, InitialDrivingExperience, car) { }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 5;
        }
    }
}
