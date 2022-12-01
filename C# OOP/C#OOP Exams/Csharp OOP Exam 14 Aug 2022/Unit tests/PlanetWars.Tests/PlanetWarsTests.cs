using NUnit.Framework;
using System;
using System.ComponentModel;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Weapon weapon;
            private Planet planet;

            [SetUp]
            public void SetUp()
            {
                weapon = new Weapon("RPG", 100.25, 5);
                planet = new Planet("Earth", 10000);
            }

            [Test]
            public void Test_Weapon_Constructor()
            {
                Assert.AreEqual("RPG", weapon.Name);
                Assert.AreEqual(100.25, weapon.Price);
                Assert.AreEqual(5, weapon.DestructionLevel);
                Assert.IsFalse(weapon.IsNuclear);
            }

            [TestCase(-1)]
            [TestCase(-100.25)]
            public void Test_Weapon_With_Invalid_Price(double price)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    weapon = new Weapon("RPG", price, 5);
                });
            }
            [Test]
            public void Test_Weapon_IncreaseDestructionLevel_Method()
            {
                weapon.IncreaseDestructionLevel();
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(7, weapon.DestructionLevel);
            }

            [Test]
            public void Test_Weapon_WheterIs_IsNuclear_Should_Return_True()
            {
                for (int i = 1; i <= 10; i++)
                {
                    weapon.IncreaseDestructionLevel();
                }
                Assert.IsTrue(weapon.IsNuclear);
                Assert.AreEqual(15, weapon.DestructionLevel);
            }

            [Test]
            public void Test_Planet_Constructor()
            {
                Assert.AreEqual("Earth", planet.Name);
                Assert.AreEqual(10000, planet.Budget);
                Assert.IsNotNull(planet.Weapons);
                Assert.AreEqual(0, planet.MilitaryPowerRatio);
            }

            [TestCase(null)]
            [TestCase("")]
            public void Test_Planet_With_Invalid_Name(string value)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet(value, 1000);
                });
            }
            [TestCase(-10)]
            [TestCase(double.MinValue)]
            public void Test_Planet_With_Invalid_Budget(double value)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet("Earth", value);
                });
            }

            [Test]
            public void Test_Planet_AddWeapon_Method_ShouldWork()
            {
                planet.AddWeapon(weapon);
                planet.AddWeapon(new Weapon("Scar", 450, 5));
                Assert.AreEqual(2, planet.Weapons.Count);
            }

            [Test]
            public void Test_Planet_AddMethod_With_Already_Existing_Weapon()
            {
                planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);
                });
            }
            [Test]
            public void Test_Weapon_Remove_Method()
            {
                planet.AddWeapon(weapon);
                planet.RemoveWeapon("RPG");
                Assert.AreEqual(0, planet.Weapons.Count);
            }
            [Test]
            public void Test_Planet_Profit_Method()
            {
                planet.Profit(90000);
                Assert.AreEqual(100000, planet.Budget);
            }

            [Test]
            public void Test_Planet_WeaponUpgrade_Method()
            {
                this.planet.AddWeapon(weapon);
                planet.UpgradeWeapon("RPG");
                Assert.AreEqual(6, weapon.DestructionLevel);
            }

            [Test]
            public void Test_WeaponUpGrade_Method_With_NoExisting_Weapon()
            {
                this.planet.AddWeapon(weapon);
                planet.UpgradeWeapon("RPG");
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("Scar");
                });
            }

            [Test]
            public void Test_Planet_SpendFunds_Method()
            {
                planet.SpendFunds(5000);
                Assert.AreEqual(5000, planet.Budget);
            }

            [TestCase(10001)]
            [TestCase(100000)]
            [TestCase(11000)]
            public void Test_Planet_SpendFunds_WithAmountBiggerThanBudget(double amount)
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(amount);
                });
            }

            [Test]
            public void Test_Planet_MilitaryPowerRatio_Property()
            {
                planet.AddWeapon(weapon);
                planet.AddWeapon(new Weapon("Scar", 450, 10));
                Assert.AreEqual(15, planet.MilitaryPowerRatio);
            }

            [TestCase(10)]
            [TestCase(100)]
            public void Test_Planet_DestructOpponent_Method_With_Stronger_Opponent(int weaponDestructionLevel)
            {
                Planet opponentPlanet = new Planet("Mars", 100000000);
                opponentPlanet.AddWeapon(new Weapon("Scar", 400, weaponDestructionLevel));
                planet.AddWeapon(weapon);
                planet.AddWeapon(new Weapon("Pump Shotgun", 1000, 5));
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(opponentPlanet);
                });
            }
            [Test]
            public void Test_Planet_DestructOpponent_Method_Should_Work()
            {
                Planet opponentPlanet = new Planet("Mars", 5);
                opponentPlanet.AddWeapon(new Weapon("Scar", 400, 4));
                planet.AddWeapon(weapon);
                string expectedResult = $"{opponentPlanet.Name} is destructed!";
                Assert.AreEqual(expectedResult,planet.DestructOpponent(opponentPlanet));
            }
        }
    }
}
