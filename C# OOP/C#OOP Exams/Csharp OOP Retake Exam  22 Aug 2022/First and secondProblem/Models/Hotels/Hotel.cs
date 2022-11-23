
using System.Linq;
using System.Text;
using BookingApp.Repositories;

namespace BookingApp.Models.Hotels
{
    using System;
    using Utilities.Messages;
    using Bookings.Contracts;
    using Contacts;
    using Rooms.Contracts;
    using Repositories.Contracts;
    using BookingApp.Models.Bookings;

    public class Hotel : IHotel
    {
        private string fullName;
        private int category;

        public Hotel(string fullName,int category)
        {
            FullName = fullName;
            Category = category;
            Rooms = new RoomRepository();
            Bookings = new BookingRepository();
        }

        public string FullName
        {
            get { return this.fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }
                fullName = value;
            }
        }

        public int Category
        {
            get { return this.category; }
            private set
            {
                if (value<1||value>5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }

                category = value;
            }
        }

        public double Turnover  => Math.Round(Bookings.All().Sum(x => x.ResidenceDuration * x.Room.PricePerNight), 2);
        public IRepository<IRoom> Rooms { get; }
        public IRepository<IBooking> Bookings { get; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hotel name: {FullName}");
            sb.AppendLine($"--{Category} star hotel");
            sb.AppendLine($"--Turnover: {Turnover:F2}$");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();
            if (this.Bookings.All().Count>0)
            {
                foreach (IBooking booking in this.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                }
            }
            else
            {
                sb.AppendLine("none");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
