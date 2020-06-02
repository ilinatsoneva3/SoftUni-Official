using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitMotorcycle motor;
        private RaceEntry race;

        [SetUp]
        public void Setup()
        {
            race = new RaceEntry();
            motor = new UnitMotorcycle("Honda", 80, 160.00);
        }

        [Test]
        public void TestIfUnitMotorInitializesCorrectly()
        {
            var expectedName = "Honda";
            var expectedHorsePower = 80;
            var expectedCubicCM = 160.00;
            Assert.AreEqual(expectedName, motor.Model);
            Assert.AreEqual(expectedHorsePower, motor.HorsePower);
            Assert.AreEqual(expectedCubicCM, motor.CubicCentimeters);
        }

        [Test]
        public void TestIfUnitRiderInitializesCorrectly()
        {
            var expectedName = "Michael";
            var rider = new UnitRider("Michael", motor);
            Assert.AreEqual(expectedName, rider.Name);
            Assert.AreEqual("Honda", rider.Motorcycle.Model);
        }

        [Test]
        public void TestIfUnitRiderThrowsAnErrorWhenInitializedWithNullName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new UnitRider(null, motor);
            });
        }

        [Test]
        public void TestIfAddRiderWorksCorrectly()
        {
            var expectedResult = "Rider Michael added in race.";
            var rider = new UnitRider("Michael", motor);
            var actualResult = race.AddRider(rider);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddRiderShouldThrowInvalidOperationExceptionWhenRiderIsNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddRider(null);
            });
        }

        [Test]
        public void AddRiderShouldThrowInvalidOperationExceptionWhenRiderAlreadyExists()
        {
            var rider = new UnitRider("Michael", motor);
            race.AddRider(rider);
            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddRider(rider);
            });
        }

        [Test]
        public void TestCounterWorksCorrectly()
        {
            var expectedCount = 1;
            var rider = new UnitRider("Michael", motor);
            race.AddRider(rider);
            Assert.AreEqual(expectedCount, race.Counter);
        }

        [Test]
        public void AverageHorsePowerShouldWorkCorrectly()
        {
            var expectedResult = 80;
            var rider = new UnitRider("Michael", motor);
            var rider2 = new UnitRider("John", motor);
            race.AddRider(rider);
            race.AddRider(rider2);
            var actualResult = race.CalculateAverageHorsePower();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AverageHorsePowerShouldInvalidOperationExceptionWithLessThanTwoParticipants()
        {
            var rider = new UnitRider("Michael", motor);
            race.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() =>
            {
                var actualResult = race.CalculateAverageHorsePower();
            });
        }
    }
}