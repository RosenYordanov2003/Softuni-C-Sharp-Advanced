using System;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private IRepository<IRace> races;
        private IRepository<IPilot> pilots;
        private IRepository<IFormulaOneCar> cars;
        [SetUp]
        public void Setup()
        {
            pilots = new PilotRepository();
            races = new RaceRepository();
            cars = new FormulaOneCarRepository();
        }

        [Test]
        public void TestCreatePilotCommandShouldWork()
        {
            IPilot pilot = new Pilot("Gosho Tsvetanov");
            pilots.Add(pilot);
            Assert.AreEqual(1,pilots.Models.Count);
        }
        [Test]
        public void TestCreatePilotCommandShouldNotWork()
        {
            IPilot pilot = new Pilot("Gosho Tsvetanov");
            pilots.Add(pilot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                pilots.Add(pilot);
            });
        }
    }
}