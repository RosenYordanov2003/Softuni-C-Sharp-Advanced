namespace BookingApp.Models.Rooms
{
    public class Studio : Room
    {
        private const int BedCapacity = 4;

        public Studio() : base(BedCapacity){}
    }
}
