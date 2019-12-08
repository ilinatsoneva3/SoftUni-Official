//using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void ShouldInitializeCorrectly()
        {
            Assert.IsNotNull(this.arena);
        }

        [Test]
        public void TestIfEnrollWorksCorrectly()
        {
            var warrior = new Warrior("Pesho", 15, 100);
            this.arena.Enroll(warrior);

            Assert.That(this.arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void EnrolShouldThrowInvalidOperationExceptionWhenAddingExistingWarrior()
        {
            var warrior = new Warrior("Pesho", 15, 100);
            this.arena.Enroll(warrior);

            var newWarrior = new Warrior("Pesho", 10, 90);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(newWarrior);
            });
        }

        [Test]
        public void CountShouldWorkCorrectly()
        {
            var expectedCount = 1;
            var warrior = new Warrior("Pesho", 15, 100);
            this.arena.Enroll(warrior);

            Assert.AreEqual(expectedCount, this.arena.Count);
        }

        [Test]
        public void FightShouldWorkCorrectly()
        {
            var expectedAttackerHP = 90;
            var expectedDeffenderHP = 75;

            var attacker = new Warrior("Pesho", 15, 100);
            var deffender = new Warrior("Gosho", 10, 90);

            this.arena.Enroll(attacker);
            this.arena.Enroll(deffender);

            this.arena.Fight("Pesho", "Gosho");

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDeffenderHP, deffender.HP);
        }

        [Test]
        public void FightShouldThrowInvalidOperationExceptionWithNonExistingDeffender()
        {
            var attacker = new Warrior("Pesho", 15, 100);
            var deffender = new Warrior("Gosho", 10, 90);

            this.arena.Enroll(attacker);
            this.arena.Enroll(deffender);

            Assert.Throws<InvalidOperationException>(()=> 
            {
                this.arena.Fight("Pesho", "Ilina");
            });
        }

        [Test]
        public void FightShouldThrowInvalidOperationExceptionWithNonExistingAttacker()
        {
            var attacker = new Warrior("Pesho", 15, 100);
            var deffender = new Warrior("Gosho", 10, 90);

            this.arena.Enroll(attacker);
            this.arena.Enroll(deffender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight("Ilina", "Gosho");
            });
        }
    }
}
