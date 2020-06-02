using System;
using System.Collections.Generic;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository heroRepository;

    [SetUp]
    public void Setup()
    {
        this.hero = new Hero("Michael", 2);
        this.heroRepository = new HeroRepository();
    }

    [Test]
    public void TestIfRepositoryInitialitedCorrectly()
    {
        Assert.IsNotNull(this.heroRepository);
    }

    [Test]
    public void TestIfHeroInitializedCorrectly()
    {
        var expectedName = "Michael";
        var expectedLevel = 2;
        Assert.AreEqual(expectedName, this.hero.Name);
        Assert.AreEqual(expectedLevel, this.hero.Level);
    }

    [Test]
    public void TestIfCreateWorksCorrectly()
    {
        var expectedResult = "Successfully added hero Michael with level 2";
        var actualResult = this.heroRepository.Create(this.hero);
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void TestIfCreateThrowsArgumentNullExceptionIfHeroIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            this.heroRepository.Create(null);
        });
    }

    [Test]
    public void TestIfCreateThrowsInvalidOperationExceptionWhenHeroIsAlreadyAdded()
    {
        this.heroRepository.Create(hero);
        Assert.Throws<InvalidOperationException>(() =>
        {
            this.heroRepository.Create(hero);
        });
    }

    [Test]
    public void TestIfRemoveWorksCorrectly()
    {
        this.heroRepository.Create(hero);
        Assert.IsTrue(this.heroRepository.Remove(hero.Name));
    }

    [Test]
    public void TestIfRemoveThrowsArgumentNullExceptionWhenHeroNameIsNull()
    {
        this.heroRepository.Create(hero);
        Assert.Throws<ArgumentNullException>(() =>
        {
            this.heroRepository.Remove(null);
        });
    }

    [Test]
    public void GetHeroWithHighestLevelShouldWorkCorrectly()
    {
        var secondHero = new Hero("Jordan", 3);
        this.heroRepository.Create(hero);
        this.heroRepository.Create(secondHero);
        var result = this.heroRepository.GetHeroWithHighestLevel();
        Assert.That(result, Is.EqualTo(secondHero));
    }

    [Test]
    public void GetHeroWorksCorrectly()
    {
        this.heroRepository.Create(hero);
        var result = this.heroRepository.GetHero("Michael");
        Assert.That(result, Is.EqualTo(this.hero));
    }

    [Test]
    public void HeroesIsReadOnlyCollection() 
    {
        this.heroRepository.Create(hero);
        var collection = new List<Hero>() { this.hero };
        Assert.AreEqual(collection, this.heroRepository.Heroes);
    }
}