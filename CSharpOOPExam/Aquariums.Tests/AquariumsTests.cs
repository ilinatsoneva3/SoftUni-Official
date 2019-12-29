namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        public Fish fish;
        public Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            this.fish = new Fish("Nemo");
            this.aquarium = new Aquarium("Ocean", 50);
        }

        [Test]
        public void TestIfFishAvailabilityIsTrue()
        {
            Assert.IsTrue(this.fish.Available);
        }

        [Test]
        public void TestAquariumConstructor()
        {
            var expectedName = "Ocean";
            var expectedCapacity = 50;
            Assert.AreEqual(expectedName, this.aquarium.Name);
            Assert.AreEqual(expectedCapacity, this.aquarium.Capacity);
        }

        [Test]
        public void NameShouldThrowArgumentNullExceptionIfNullOrEmpty()
        {

            Assert.Throws<ArgumentNullException>(()=>
            {
                new Aquarium("", 50);
            });
        }

        [Test]
        public void CapacityShouldThrowArgumentExceptionIfBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Aquarium("Nemoo", -1);
            });
        }

        [Test]
        public void AddFishShouldWorkCorrectly()
        {
            var expectedCount = 1;
            this.aquarium.Add(this.fish);
            Assert.AreEqual(expectedCount, this.aquarium.Count);
        }

        [Test]
        public void AddFishShouldThrowInvalidOperationExceptionWhenAquariumIsFull()
        {
            var newAquarium = new Aquarium("Ocean 2", 1);
            newAquarium.Add(this.fish);
            Assert.Throws<InvalidOperationException>(()=> 
            {
                newAquarium.Add(new Fish("Nemoo"));
            });
        }

        [Test]
        public void RemoveFishWorksCorrectly()
        {
            var expectedCount = 0;
            this.aquarium.Add(fish);
            this.aquarium.RemoveFish("Nemo");
            Assert.AreEqual(expectedCount, this.aquarium.Count);
        }

        [Test]
        public void RemoveFishShouldThrowInvalidOperationExceptionWhenFishDoesntExist()
        {
            this.aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(()=> 
            {
                this.aquarium.RemoveFish("Nemooo");
            });
        }

        [Test]
        public void SellFishWorksCorrectly()
        {
            var expectedResult = false;
            this.aquarium.Add(fish);
            this.aquarium.SellFish("Nemo");
            Assert.AreEqual(expectedResult, this.fish.Available);
        }

        [Test]
        public void SellFishWorksCorrectlySecondPart()
        {
            var expectedResult = "Nemo";
            this.aquarium.Add(fish);
            var result = this.aquarium.SellFish("Nemo");
            Assert.AreEqual(expectedResult,result.Name);
        }

        [Test]
        public void SellFishShouldThrowInvalidOperationExceptionWhenFishDoesntExist()
        {
            this.aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.aquarium.SellFish("Nemooo");
            });
        }

        [Test]
        public void ReportShouldWorkCorrectly()
        {
            var expectedResult = "Fish available at Ocean: Nemo";
            this.aquarium.Add(fish);
            var actualResult = this.aquarium.Report();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
