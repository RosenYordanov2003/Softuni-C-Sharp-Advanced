namespace BookingApp.Models.Rooms
{
    public class DoubleBed : Room
    {
        private const int BedCapacity = 2;

        public DoubleBed() : base(BedCapacity) {}
    }
}
