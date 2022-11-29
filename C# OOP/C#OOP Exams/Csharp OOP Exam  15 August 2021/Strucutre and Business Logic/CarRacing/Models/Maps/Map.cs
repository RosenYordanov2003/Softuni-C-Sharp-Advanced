namespace CarRacing.Models.Maps
{
    using Contracts;
    using CarRacing.Models.Racers.Contracts;
    using Utilities.Messages;
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if ((!racerTwo.IsAvailable()))
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            racerOne.Race();
            racerTwo.Race();
            double racerOneBehaviorResult = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            double racerTwoBehaviorResult = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;

            double raceOneResult = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneBehaviorResult;
            double racerTwoResult = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoBehaviorResult;
            string winner = raceOneResult > racerTwoResult ? racerOne.Username : racerTwo.Username;
            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner);
        }
    }
}
