using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Gyms.Tests
{
    public class GymsTests
    {
        private Athlete athlete;
        private Gym gym;

        [SetUp]
        public void SetUp()
        {
            athlete = new Athlete("Pesho");
            gym = new Gym("Titanium", 300);
        }

        [Test]
        public void Test_Athlete_Constructor()
        {
            string expectedName = "Pesho";
            Assert.AreEqual(expectedName, athlete.FullName);
            Assert.IsFalse(athlete.IsInjured);
        }

        [Test]
        public void Test_Gym_Constructor()
        {
            string expectedGymName = "Titanium";
            int expectedSize = 300;
            Assert.AreEqual(expectedGymName, gym.Name);
            Assert.AreEqual(expectedSize, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_GymName_Property_WithInvalidNames(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                gym = new Gym(name, 300);
            });
        }

        [TestCase("Titanium")]
        [TestCase("Pulse")]
        public void Test_GymName_Property_WithValidNames(string name)
        {
            gym = new Gym(name, 300);
            Assert.AreEqual(name, gym.Name);
        }

        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-99999)]
        [TestCase(int.MinValue)]
        public void Test_GymCapacity_WithInvalid_Values(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                gym = new Gym("Titanium", capacity);
            });
        }
        [TestCase(100)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(350)]
        [TestCase(int.MaxValue)]
        public void Test_GymCapacity_WithValid_Values(int capacity)
        {
            gym = new Gym("Pulse", capacity);
            Assert.AreEqual(capacity, gym.Capacity);
        }

        [Test]
        public void Test_GymCount()
        {
            Assert.AreEqual(0, gym.Count);
        }
        [Test]
        public void Test_AddAthleteMethod_ShouldWork()
        {
            int expectedCount = 2;
            gym.AddAthlete(athlete);
            gym.AddAthlete(new Athlete("Gosho"));
            Assert.AreEqual(expectedCount, gym.Count);
        }
        [Test]
        public void Test_AddAthleteMethod_ShouldNotWork()
        {
            gym = new Gym("Titanium", 2);
            gym.AddAthlete(athlete);
            gym.AddAthlete(new Athlete("Gosho"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(new Athlete("Misho"));
            });
        }

        [Test]
        public void Test_Gym_RemoveMethod_ShouldWork()
        {
            int expectedCount = 1;
            for (int i = 1; i <= 3; i++)
            {
                gym.AddAthlete(new Athlete(string.Format($"Pesho{i}")));
            }
            Assert.AreEqual(3, gym.Count);
            gym.RemoveAthlete("Pesho1");
            gym.RemoveAthlete("Pesho2");
            Assert.AreEqual(expectedCount, gym.Count);
        }

        [Test]
        public void Test_Gym_RemoveMethod_With_NoExistingAthletes_ShouldNotWork()
        {
            gym = new Gym("Pulse", 10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Pesho99");
            });
        }

        [Test]
        public void Test_InjureMethod_ShouldWork()
        {
            gym.AddAthlete(athlete);
            Athlete injuredAthlete = gym.InjureAthlete("Pesho");
            Assert.IsTrue(athlete.IsInjured);
            Assert.AreSame(injuredAthlete, athlete);
        }
        [Test]
        public void Test_InjureMethod_With_No_ExistingAthlete_ShouldNotWork()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Pesho256");
            });
        }

        [Test]
        public void Test_Gym_ReportMethod()
        {
            List<Athlete> atheletes = new List<Athlete>()
            {
                new Athlete("Gosho"),
                new Athlete("Pesho22"),
                new Athlete("Mitko")
            };
            List<string> athletesNamesList = new List<string>();
            foreach (Athlete athelete in atheletes)
            {
                athletesNamesList.Add(athelete.FullName);
                gym.AddAthlete(athelete);
            }
            string namesResult = string.Format(string.Join(", ", athletesNamesList));
            string expectedReportResult = string.Format($"Active athletes at {gym.Name}: {namesResult}");
            Assert.AreEqual(expectedReportResult, gym.Report());
        }
        [Test]
        public void Test_Gym_ReportMethod2()
        {
            int counter = 0;
            List<Athlete> atheletes = new List<Athlete>()
            {
                new Athlete("Gosho"),
                new Athlete("Pesho22"),
                new Athlete("Mitko")
            };
            List<string> athletesNamesList = new List<string>();
            foreach (Athlete athelete in atheletes)
            {
                gym.AddAthlete(athelete);
                if (counter % 2 == 0)
                {
                    gym.InjureAthlete(athelete.FullName);
                }

                if (!athelete.IsInjured)
                {
                    athletesNamesList.Add(athelete.FullName);
                }

                counter++;
            }
            string namesResult = string.Format(string.Join(", ", athletesNamesList));
            string expectedReportResult = string.Format($"Active athletes at {gym.Name}: {namesResult}");
            Assert.AreEqual(expectedReportResult, gym.Report());
        }
        [Test]
        public void Test_Gym_ReportMethod3()
        {
            List<Athlete> atheletes = new List<Athlete>()
            {
                new Athlete("Gosho"),
                new Athlete("Pesho22"),
                new Athlete("Mitko")
            };
            gym.AddAthlete(atheletes.Find(a => a.FullName == "Gosho"));
            gym.AddAthlete(atheletes.Find(a => a.FullName == "Mitko"));
            List<string> athletesNamesList = new List<string>();
            gym.InjureAthlete("Gosho");
            gym.InjureAthlete("Mitko");
            foreach (Athlete athelete in atheletes.Where(a => a.IsInjured == false))
            {
                gym.AddAthlete(athelete);
                athletesNamesList.Add(athelete.FullName);
            }
            string namesResult = string.Format(string.Join(", ", athletesNamesList));
            string expectedReportResult = string.Format($"Active athletes at {gym.Name}: {namesResult}");
            Assert.AreEqual(expectedReportResult, gym.Report());
        }
    }
}
