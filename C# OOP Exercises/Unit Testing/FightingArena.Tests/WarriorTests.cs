//using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldInitializeWarriorCorrectly()
        {
            var name = "Pesho";
            var damage = 15;
            var HP = 100;

            var warrior = new Warrior(name, damage, HP);
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(HP, warrior.HP);
        }

        [TestCase (null, 15, 100)]
        [TestCase ("   ", 15, 100)]
        [TestCase ("Pesho", 0, 100)]
        [TestCase ("Pesho", -1, 100)]
        [TestCase ("Pesho", 15, -1)]
        public void TestInitializationWithWrongInputShouldThrowArgumentException(string name, int damage, int HP)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        public void AttackShouldWorkCorrectly()
        {
            var expectedAttackerHP = 90;
            var expectedDeffenderHP = 75;

            var attacker = new Warrior("Pesho", 15, 100);
            var deffender = new Warrior("Gosho", 10, 90);
            attacker.Attack(deffender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDeffenderHP, deffender.HP);
        }

        [Test]
        public void AttackShouldThrowInvalidOperationExceptionWhenAttackingWithLowHP()
        {
            var attacker = new Warrior("Pesho", 15, 30);
            var deffender = new Warrior("Gosho", 10, 90);


            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(deffender);
            });
        }

        [Test]
        public void AttackShouldThrowInvalidOperationExceptionWhenDefendingWithLowHP()
        {
            var attacker = new Warrior("Pesho", 15, 100);
            var deffender = new Warrior("Gosho", 10, 30);


            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(deffender);
            });
        }

        [Test]
        public void AttackShouldThrowInvalidOperationExceptionWhenAttackingStrongerEnemy()
        {
            var attacker = new Warrior("Pesho", 15, 40);
            var deffender = new Warrior("Gosho", 50, 90);


            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(deffender);
            });
        }

        [Test]
        public void AttackShouldKillEnemy()
        {
            var expectedDefHP = 0;
            var expectedAttHP = 90;

            var attacker = new Warrior("Pesho", 50, 100);
            var deffender = new Warrior("Gosho", 10, 40);

            attacker.Attack(deffender);

            Assert.AreEqual(expectedDefHP, deffender.HP);
            Assert.AreEqual(expectedAttHP, attacker.HP);
        }
    }
}