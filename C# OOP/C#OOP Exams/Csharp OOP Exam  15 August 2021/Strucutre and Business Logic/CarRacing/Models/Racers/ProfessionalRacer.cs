namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    public class ProfessionalRacer : Racer
    {
        private const int InitialDrivingExperience = 30;
        private const string InitialRacerBehavior = "strict";
        public ProfessionalRacer(string userName, ICar car) : base(userName, InitialRacerBehavior, InitialDrivingExperience, car) { }
        public override void Race()
        {
            base.Race();
            DrivingExperience += 10;
        }
    }
}
