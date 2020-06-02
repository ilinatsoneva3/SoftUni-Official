using NUnit.Framework;
using Database;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        private readonly int[] data = { 1, 2, 3 };

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(data);
        }

        [Test]
        public void DoesConstructorWorkCorrectly()
        {
            int expectedCount = 3;
            int actualCount = this.database.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void DoesAddMethodWorkCorrectlyWhenCountIsBelow16()
        {
            int expectedCount = 4;
            this.database.Add(4);
            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void DoesAddMethodThrowExceptionWhenTryingToAddElementAfterDatabaseIsFull()
        {
            for (int i = 4; i <= 16; i++)
            {
                this.database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(17);
            });
        }

        [Test]
        public void DoesRemoveMethodRemovesTheLastElement()
        {
            int expectedCount = 2;
            this.database.Remove();
            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void DoesRemoveMethodThrowExceptionWhenDatabaseIsEmpty()
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
        public void DoesFetchMethodReturnsTheSameCollection()
        {
            int[] result = this.database.Fetch();
            CollectionAssert.AreEqual(this.data, result);
        }

    }
}