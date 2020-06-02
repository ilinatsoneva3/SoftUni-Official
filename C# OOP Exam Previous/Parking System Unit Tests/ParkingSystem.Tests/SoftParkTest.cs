namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private SoftPark softPark;
        [SetUp]
        public void Setup()
        {
            this.softPark = new SoftPark();
        }

        [Test]
        public void CarConstructorShouldInitializeCorrectly()
        {
            string expectedMake = "Mercedes";
            string expectedRegistrationNumber = "1991";
            var car = new Car("Mercedes", "1991");
            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedRegistrationNumber, car.RegistrationNumber);
        }

        [Test]
        public void SoftParkConstructorShouldInitializeCorrectly()
        {
            Car expectedCar = null;
            Assert.AreEqual(expectedCar, this.softPark.Parking["A1"]);
            Assert.AreEqual(12, this.softPark.Parking.Count);
        }

        [Test]
        public void ParkCarShouldWorkCorrectly()
        {
            var expectedResult = "Car:1991 parked successfully!";
            var car = new Car("Mercedes", "1991");
            var actualResult = this.softPark.ParkCar("A1", car);
            Assert.AreEqual(expectedResult, actualResult);
            Assert.That(this.softPark.Parking["A1"], Is.EqualTo(car));
        }

        [Test]
        public void ParkCarShouldThrowArgumentExceptionWhenParkingSpotDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.ParkCar("z69", new Car("Mercedes", "1991"));
            });
        }

        [Test]
        public void ParkCarShouldThrowArgumentExceptionWhenParkingSpotIsTaken()
        {
            this.softPark.ParkCar("A1", new Car("Honda", "1991"));

            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.ParkCar("A1", new Car("Mercedes", "1991"));
            });
        }

        [Test]
        public void ParkCarShouldThrowInvalidOperationExceptionWhenCarIsAlreadyParked()
        {
            var car = new Car("Honda", "1991");
            this.softPark.ParkCar("A1", car);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.softPark.ParkCar("A2", car);
            });
        }

        [Test]
        public void RemoveCarShouldWorkCorrectly()
        {
            var expectedResult = "Remove car:1991 successfully!";
            var car = new Car("Honda", "1991");
            this.softPark.ParkCar("A1", car);
            var actualResult = softPark.RemoveCar("A1", car);
            Assert.AreEqual(expectedResult, actualResult);
            Assert.IsNull(softPark.Parking["A1"]);
        }

        [Test]
        public void RemoveCarShouldThrowArgumentExceptionWhenParkingSpotDoesNotExist()
        {
            var car = new Car("Honda", "1991");
            this.softPark.ParkCar("A1", car);
            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.RemoveCar("Z60", car);
            });
        }

        [Test]
        public void RemoveCarShouldThrowArgumentExceptionWhenCarDoesNotExist()
        {
            var car = new Car("Honda", "1991");
            this.softPark.ParkCar("A1", car);
            var secondCar = new Car("Mercedes", "1991");
            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.RemoveCar("A1", secondCar);
            });
        }
    }
}