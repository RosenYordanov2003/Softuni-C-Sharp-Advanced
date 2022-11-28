namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int Capacity = 15;
        public BoxingGym(string gymName) : base(gymName, Capacity){}
    }
}
