//using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            string make = "Mercedes";
            string model = "S Classa";
            double fuelConsumption = 1.5;
            double fuelCapacity = 100;

            this.car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void AssertObjectIsNotSetToNull()
        {
            string make = "Mercedes";
            string model = "S Classa";
            double fuelConsumption = 1.5;
            double fuelCapacity = 100;

            this.car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.IsNotNull(this.car);
        }

        [Test]
        public void EmptyConstructorSetsFuelAmountCorrectly()
        {
            var expectedAmount = 0;

            string make = "Mercedes";
            string model = "S Classa";
            double fuelConsumption = 1.5;
            double fuelCapacity = 100;

            car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(expectedAmount, car.FuelAmount);
        }


        [TestCase(null, "S Classa", 1.5, 100)]
        [TestCase("", "S Classa", 1.5, 100)]
        [TestCase("Mercedes", null, 1.5, 100)]
        [TestCase("Mercedes", "", 1.5, 100)]
        [TestCase("Mercedes", "S Classa", 0, 100)]
        [TestCase("Mercedes", "S Classa", -1.5, 100)]
        [TestCase("Mercedes", "S Classa", 1.5, 0)]
        [TestCase("Mercedes", "S Classa", 1.5, -10)]
        public void MakeShouldThrowArgumentExceptionWhenInitializedWithNullValue
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
               {
                   new Car(make, model, fuelConsumption, fuelCapacity);
               });
        }

        [Test]
        public void RefuelMethodWorksCorrectly()
        {
            var expectedAmount = 50;
            string make = "Mercedes";
            string model = "S Classa";
            double fuelConsumption = 1.5;
            double fuelCapacity = 100;
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(50);
            Assert.AreEqual(expectedAmount, car.FuelAmount);
        }

        [TestCase(0)]
        [TestCase(-20)]
        public void RefuelThrowsArgumentExceptionWhenAmountIsZeroOrBelow(double refuelAmount)
        {
            string make = "Mercedes";
            string model = "S Classa";
            double fuelConsumption = 1.5;
            double fuelCapacity = 100;
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(refuelAmount);
            });
        }

        [TestCase(101)]
        [TestCase(150)]
        public void RefuelSetsFuelCapacityIfGivenAmountOfFuelIsBiggerThanCapacity(double fuelAmount)
        {
            var expectedFuelAmount = 100;
            string make = "Mercedes";
            string model = "S Classa";
            double fuelConsumption = 1.5;
            double fuelCapacity = 100;
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelAmount);
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void DriveMethodRecalculatesMethodCorrectly()
        {
            var expectedFuelAmount = 47.75;
            string make = "Mercedes";
            string model = "S Classa";
            double fuelConsumption = 1.5;
            double fuelCapacity = 100;
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(50);
            car.Drive(150);
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void DriveThrowsInvalidOperationExceptionWhenFuelIsInsufficient()
        {
            string make = "Mercedes";
            string model = "S Classa";
            double fuelConsumption = 1.5;
            double fuelCapacity = 100;
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(150);
            });
        }
    }
}