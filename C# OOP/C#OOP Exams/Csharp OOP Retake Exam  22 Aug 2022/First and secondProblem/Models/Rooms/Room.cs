
using System;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Rooms
{
    using Contracts;
    public abstract class Room : IRoom
    {
        private int bedCapacity;
        private double pricePerNight = 0;

        protected Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
        }

        public int BedCapacity
        {
            get { return bedCapacity; }
            protected set { bedCapacity = value; }
        }
        public double PricePerNight
        {
            get { return pricePerNight; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }
                pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            this.PricePerNight = price;
        }
    }
}
