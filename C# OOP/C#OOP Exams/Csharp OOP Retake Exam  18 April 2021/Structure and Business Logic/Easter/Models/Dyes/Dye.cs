namespace Easter.Models.Dyes
{
    using Contracts;
    public class Dye : IDye
    {
        private int _power;

        public Dye(int power)
        {
            Power = power;
        }
        public int Power
        {
            get { return _power; }
            private set
            {
                if (value < 0)
                {
                    _power = 0;
                }
                else
                {
                    _power = value;
                }
            }
        }
        public void Use()
        {
            Power -= 10;
        }
        public bool IsFinished() => Power == 0;
    }
}
