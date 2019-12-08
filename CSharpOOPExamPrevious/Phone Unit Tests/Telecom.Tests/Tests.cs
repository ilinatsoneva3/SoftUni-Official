namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            var expectedMake = "Siemens";
            var expectedModel = "C60";

            var phone = new Phone("Siemens", "C60");
            Assert.AreEqual(expectedMake, phone.Make);
            Assert.AreEqual(expectedModel, phone.Model);
        }

        [TestCase(null, "C60")]
        [TestCase("Siemens", null)]
        public void ConstructorShouldThrowArgumentExceptionWithNullMakeOrModel(string make, string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Phone(make, model);
            });
        }

        [Test]
        public void TestIfAddContactCorrectly()
        {
            var expectedCount = 1;
            var phone = new Phone("Siemens", "C60");
            var name = "Gosho";
            phone.AddContact(name, "0883408477");
            Assert.AreEqual(expectedCount, phone.Count);
        }

        [Test]
        public void AddContactShouldThrowExceptionWhenContactAlreadyExists()
        {
            var phone = new Phone("Siemens", "C60");
            var name = "Gosho";
            phone.AddContact(name, "0883408477");
            Assert.Throws<InvalidOperationException>(() =>
            {
                phone.AddContact("Gosho", "0881765915");
            });
        }

        [Test]
        public void TestIfCallWorksCorrectly()
        {
            var expectedResult = "Calling Gosho - 0883408477...";
            var phone = new Phone("Siemens", "C60");
            var name = "Gosho";
            phone.AddContact(name, "0883408477");
            var actualResult = phone.Call("Gosho");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CallShouldThrowExceptionIfPersonDoesNotExist()
        {
            var phone = new Phone("Siemens", "C60");
            var name = "Gosho";
            phone.AddContact(name, "0883408477");
            Assert.Throws<InvalidOperationException>(()=> 
            {
                phone.Call("Ilina");
            });
        }
    }
}