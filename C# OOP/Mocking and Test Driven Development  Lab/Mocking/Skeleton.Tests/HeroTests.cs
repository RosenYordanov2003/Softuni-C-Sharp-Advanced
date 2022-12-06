
using Moq;
using NUnit.Framework;

namespace FakeAxeAndDummy
{
    public class HeroTests
    {
        private Mock<IWeapon> _mockWeapon = new Mock<IWeapon>();
        private Mock<ITarget> _mockTarget = new Mock<ITarget>();
        private Hero _hero;

        [SetUp]
        public void SetUo()
        {
            _mockTarget.Setup(m => m.Health).Returns(19);
            _mockTarget.Setup(m => m.Experience).Returns(15);
            _mockTarget.Setup(m => m.IsDead()).Returns(_mockTarget.Object.Health > 0);
            _mockTarget.Setup(m => m.GiveExperience()).Returns(10);
            _mockTarget.Setup(m => m.TakeAttack(_mockWeapon.Object.AttackPoints));

            _mockWeapon.Setup(m => m.AttackPoints).Returns(20);
            _mockWeapon.Setup(m => m.DurabilityPoints).Returns(30);
            _mockWeapon.Setup(m => m.Attack(_mockTarget.Object));

            _hero = new Hero("Vesko", _mockWeapon.Object);
        }

        [Test]
        public void Test_Hero_Constructor()
        {
            Assert.AreEqual("Vesko",_hero.Name);
            Assert.AreEqual(_mockWeapon.Object,_hero.Weapon);
        }

        [Test]
        public void Test_Hero_Attack_Method()
        {
            _hero.Attack(_mockTarget.Object);
            Assert.AreEqual(10,_hero.Experience);
        }
    }
}
