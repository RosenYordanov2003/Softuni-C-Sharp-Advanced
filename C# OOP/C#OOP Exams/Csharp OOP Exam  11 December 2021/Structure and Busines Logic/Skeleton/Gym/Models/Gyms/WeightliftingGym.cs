namespace Gym.Models.Gyms
{
    public class WeightliftingGym : Gym
    {
        private const int Capacity = 20;
        public WeightliftingGym(string gymName) : base(gymName, Capacity){}
    }
}
