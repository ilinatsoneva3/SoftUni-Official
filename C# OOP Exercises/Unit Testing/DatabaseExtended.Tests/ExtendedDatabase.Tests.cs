using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;
        private readonly Person personToTest = new Person(3, "Pesho");
        private readonly Person[] people =
            {
            new Person(1, "Gosho"),
            new Person(2, "Stefcho")
        };


        [SetUp]
        public void Setup()
        {
            this.database = new ExtendedDatabase.ExtendedDatabase(people);
            this.database.Add(personToTest);
        }

        [Test]
        public void DatabaseShouldReturnCountCorrectly()
        {
            int expectedCount = 3;
            int actualCount = this.database.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void DatabaseShouldThrowErrorWhenCountIsMoreThanSixteen()
        {
            for (int i = 4; i <= 16; i++)
            {
                var person = new Person(i, $"Smeshko{i}");
                this.database.Add(person);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(17, "Something"));
            });
        }

        [Test]
        public void DatabaseShouldThrowExceptionWhenAPersonWithTheSameIDIsAdded()
        {
            Person person = new Person(3, "Stefchoo");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(person);
            });
        }

        [Test]
        public void DatabaseShouldThrowExceptionWhenAPersonWithTheSameNameIsAdded()
        {
            Person person = new Person(4, "Stefcho");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(person);
            });
        }

        [Test]
        public void DatabaseShouldThrowExceptionWhenTryingToRemovePersonFromEmptyCollection()
        {
            for (int i = 0; i < 3; i++)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });
        }

        [Test]
        public void TestIfRemoveMethodWorksCorrectly()
        {
            int expectedCount = 2;
            this.database.Remove();
            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestIfFindPersonByUsernameMethodIsWorkingCorrectly()
        {
            var newPerson = new Person(4, "Ilina");
            var people = new Person[] { newPerson, personToTest };
            this.database = new ExtendedDatabase.ExtendedDatabase(people);
            var expected = newPerson;
            var actual = this.database.FindByUsername("Ilina");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestIfFindByUsernameThrowsExceptionWhenUsernameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.database.FindByUsername(null);
            });
        }

        [Test]
        public void TestIfFindByUsernameThrowsExceptionWhenNoSuchUsernameIsFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
           {
               this.database.FindByUsername("Raltsa");
           });
        }

        [Test]
        public void TestIfFindByIDWorksCorrectly()
        {
            var newPerson = new Person(4, "Ilina");
            var people = new Person[] { newPerson, personToTest };
            this.database = new ExtendedDatabase.ExtendedDatabase(people);
            var expected = newPerson;
            var actual = this.database.FindById(4);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestIfFindByIDThrowsErrorWithNegativeID()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
           {
               this.database.FindById(-1);
           });
        }

        [Test]
        public void TestIfFindByIDThrowsErrorWhenNoSuchIDIsAvailable()
        {
            Assert.Throws<InvalidOperationException>( ()=>
            {
                this.database.FindById(10);
            });
        }
    }
}