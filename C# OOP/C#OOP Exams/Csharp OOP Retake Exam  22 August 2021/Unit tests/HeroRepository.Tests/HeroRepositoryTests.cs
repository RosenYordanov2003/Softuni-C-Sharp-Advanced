using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private Hero _hero;
    private HeroRepository _heroRepository;


    [SetUp]
    public void SetUp()
    {
        _hero = new Hero("Pesho", 10);
        _heroRepository = new HeroRepository();
    }

    [Test]
    public void Test_Hero_Constructor()
    {
        Assert.AreEqual("Pesho", _hero.Name);
        Assert.AreEqual(10, _hero.Level);
    }

    [Test]
    public void Test_HeroRepository_CreateMethod_WithInvalid_Hero()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            _heroRepository.Create(null);
        });
    }
    [Test]
    public void Test_HeroRepository_CreateMethod_WithExisting_Hero()
    {
        _heroRepository.Create(_hero);
        Assert.Throws<InvalidOperationException>(() =>
        {
            _heroRepository.Create(_hero);
        });
    }
    [Test]
    public void Test_HeroRepository_CreateMethod_WithValid_Hero()
    {

        string expectedResult = string.Format($"Successfully added hero Pesho with level 10");
        Assert.AreEqual(expectedResult, _heroRepository.Create(_hero));
        Assert.AreEqual(1,_heroRepository.Heroes.Count);
    }

    [TestCase(null)]
    [TestCase(" ")]
    [TestCase("")]
    public void Test_HeroRepository_RemoveMethod_WithInvalidHeroName(string name)
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            _heroRepository.Remove(name);
        });
    }
    [Test]
    public void Test_HeroRepository_RemoveMethod_WithValidHeroName_ShouldReturnFalse()
    {
      Assert.IsFalse(_heroRepository.Remove("Kris24"));
    }
    [Test]
    public void Test_HeroRepository_RemoveMethod_WithValidHeroName_ShouldReturnTrue()
    {
        _heroRepository.Create(_hero);
        Assert.IsTrue(_heroRepository.Remove("Pesho"));
        Assert.AreEqual(0,_heroRepository.Heroes.Count);
    }

    [Test]
    public void GetHero_WithHighest_Level()
    {
        _heroRepository.Create(_hero);
        _heroRepository.Create(new Hero("Gosho", 25));
        _heroRepository.Create(new Hero("Evtimkata", -99));
        Hero winningHero = new Hero("Tom", 26);
        _heroRepository.Create(winningHero);
        Assert.AreSame(winningHero,_heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void Test_GetHeroMethod()
    {
        _heroRepository.Create(_hero);
        Hero hero = _heroRepository.GetHero("Pesho");
        Assert.AreSame(_hero,hero);
    }
    [Test]
    public void Test_GetHeroMethod2()
    {
        Assert.AreEqual(null,_heroRepository.GetHero("Gosho"));
    }
}