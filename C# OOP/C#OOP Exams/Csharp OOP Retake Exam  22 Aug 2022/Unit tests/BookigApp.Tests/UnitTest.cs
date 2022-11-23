using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Room room;
        private Booking booking;
        private Hotel hotel;
        [SetUp]
        public void Setup()
        {
            room = new Room(3, 110.20);
            booking = new Booking(2, room, 3);
            hotel = new Hotel("Paradise", 5);
        }

        [Test]
        public void Test_Construcor()
        {
            int expectedBedCapacity = 3;
            double expectedPricePerNight = 110.20;
            Assert.AreEqual(expectedBedCapacity, room.BedCapacity);
            Assert.AreEqual(expectedPricePerNight, room.PricePerNight);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void Test_WithInvalid_BedCapacity(int bedCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                room = new Room(bedCapacity, 100);
            });
        }

        [TestCase(0)]
        [TestCase(-0.99)]
        [TestCase(-1)]
        public void Test_With_Invalid_PricePerNight(double pricePerNight)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                room = new Room(3, pricePerNight);
            });
        }

        [Test]
        public void Test_BookingConstructor()
        {
            int expectedBookingNumber = 2;
            Room expectedRoom = room;
            int expectedResidenceDuration = 3;
            Assert.AreEqual(expectedBookingNumber, booking.BookingNumber);
            Assert.AreEqual(expectedRoom, booking.Room);
            Assert.AreEqual(expectedResidenceDuration, booking.ResidenceDuration);
        }

        [Test]
        public void Test_HotelConstructor()
        {
            string expectedName = "Paradise";
            int expectedCategory = 5;
            Assert.AreEqual(expectedName, hotel.FullName);
            Assert.AreEqual(expectedCategory, hotel.Category);
            Assert.AreEqual(0, hotel.Turnover);
            Assert.IsNotNull(hotel.Rooms);
            Assert.IsNotNull(hotel.Bookings);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Test_WithInvalidHotel_FullName(string fullName)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                hotel = new Hotel(fullName, 5);
            });
        }

        [TestCase(6)]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(9999)]
        [TestCase(-2)]
        public void Test_With_InvalidCategory(int category)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                hotel = new Hotel("Paradise", category);
            });
        }

        [Test]
        public void Test_Hotel_AddRoom_Method()
        {
            Room roomToAdd = new Room(3, 170.55);
            int expectedRoomsCoubt = 1;
            hotel.AddRoom(roomToAdd);
            Assert.AreEqual(expectedRoomsCoubt, hotel.Rooms.Count);
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void Test_Hotel_BookingMethod_WithInvalid_AdultsCount(int adults)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(adults, 5, 4, 200);
            });
        }
        [TestCase(-100)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void Test_Hotel_BookingMethod_WithInvalid_ChildrenCount(int children)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(2, children, 4, 200);
            });
        }
        [TestCase(-100)]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(0)]
        public void Test_Hotel_BookingMethod_WithInvalid_ResidenseDuration(int residenceDuration)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(2, 2, residenceDuration, 200);
            });
        }
        [Test]
        public void Test_Hotel_BookingMethod_ShouldWork()
        {
           hotel.AddRoom(room);
           hotel.BookRoom(2,1,3,330.60);
           int expectedBookingCount = 1;
           double expectedTurnOver = 330.60;
           Assert.AreEqual(expectedBookingCount,hotel.Bookings.Count);
           Assert.AreEqual(expectedTurnOver,hotel.Turnover);
        }
    }
}