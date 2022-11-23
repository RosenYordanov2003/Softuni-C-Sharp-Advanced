namespace BookingApp.Models.Bookings
{
    using System;
    using System.Text;
    using Utilities.Messages;
    using Contracts;
    using BookingApp.Models.Rooms.Contracts;
    public class Booking : IBooking
    {
        private IRoom room;
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;

        public Booking(IRoom room,int residenceDuration,int adultsCount,int childrenCount,int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            this.bookingNumber = bookingNumber;
        }

        public IRoom Room
        {
            get { return this.room; }
            private set { this.room = value; }
        }

        public int ResidenceDuration
        {
            get { return this.residenceDuration; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }

                residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get { return this.adultsCount; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get { return this.childrenCount; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                childrenCount = value;
            }
        }

        public int BookingNumber => bookingNumber;
          
        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {this.Room.GetType().Name}");
            sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            sb.AppendLine($"Total amount paid: {Math.Round(ResidenceDuration*Room.PricePerNight,2):F2}$");
            return sb.ToString().TrimEnd();
        }
    }
}
