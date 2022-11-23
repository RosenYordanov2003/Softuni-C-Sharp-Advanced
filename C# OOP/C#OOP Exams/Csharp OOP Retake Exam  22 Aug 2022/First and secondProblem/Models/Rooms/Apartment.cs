namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        private const int BedCapacity = 6;

        public Apartment() : base(BedCapacity){}
    }
}
