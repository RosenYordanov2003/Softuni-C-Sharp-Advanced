using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Core
{
    using Contracts;
    public class Controller : IController
    {
        private IRepository<IHotel> hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel != null)
            {
                return $"Hotel {hotelName} is already registered in our platform.";
            }
            else
            {
                hotel = new Hotel(hotelName, category);
                this.hotels.AddNew(hotel);
                return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
            }
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }
            else
            {
                IRoom room = hotel.Rooms.Select(roomTypeName);
                if (room != null)
                {
                    return "Room type is already created!";
                }
                else
                {
                    IRoom roomToAdd = CreateRoom(roomTypeName);
                    hotel.Rooms.AddNew(roomToAdd);
                    return $"Successfully added {roomTypeName} room type in {hotelName} hotel!";
                }
            }
        }


        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }
            else
            {
                if (!isValidRoom(roomTypeName))
                {
                    throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
                }
                else if (hotel.Rooms.Select(roomTypeName) == null)
                {
                    return "Room type is not created yet!";
                }
                else
                {
                    IRoom room = hotel.Rooms.Select(roomTypeName);
                    if (room.PricePerNight != 0)
                    {
                        return "Price is already set!";
                    }
                    else
                    {
                        room.SetPrice(price);
                        return $"Price of {roomTypeName} room type in {hotelName} hotel is set!";
                    }
                }
            }
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            List<IHotel> orderHotels = new List<IHotel>();
            OrderHotels(orderHotels);
            List<IHotel> hotelWithCategory = orderHotels.Where(h => h.Category == category).ToList();
            if (hotelWithCategory.Count == 0)
            {
                return $"{category} star hotel is not available in our platform.";
            }
            else
            {
                //var hotelToGet = hotelWithCategory.OrderBy(h => h.Rooms.All().Where(r => r.BedCapacity >=adults+children));
                foreach (IHotel hotel in hotelWithCategory)
                {
                    foreach (IRoom room in hotel.Rooms.All().OrderBy(r => r.BedCapacity))
                    {
                        if (room.BedCapacity >= children + adults)
                        {
                            int bookingNumber = hotel.Bookings.All().Count + 1;
                            hotel.Bookings.AddNew(new Booking(room, duration, adults, children,bookingNumber));
                            return $"Booking number {bookingNumber} for {hotel.FullName} hotel is successful!";
                        }
                    }
                }

                return "We cannot offer appropriate room for your request.";
            }
        }


        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel==null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }
            else
            {
                string result = hotel.ToString();
                return result;
            }
        }


        private IRoom CreateRoom(string roomTypeName)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(Room))
                .FirstOrDefault(t => t.Name == roomTypeName);
            if (type == null)
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            else
            {
                IRoom room = (IRoom)Activator.CreateInstance(type);
                return room;
            }
        }

        private bool isValidRoom(string roomTypeName)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(Room))
                .FirstOrDefault(t => t.Name == roomTypeName);
            if (type == null)
            {
                return false;
            }

            return true;
        }
        private void OrderHotels(List<IHotel> orderHotels)
        {
            foreach (IHotel hotel in hotels.All().OrderBy(x => x.FullName))
            {
                foreach (IRoom rooms in hotel.Rooms.All().Where(r => r.PricePerNight > 0).OrderBy(r => r.BedCapacity))
                {
                    orderHotels.Add(hotel);
                }
            }
        }
    }
}
