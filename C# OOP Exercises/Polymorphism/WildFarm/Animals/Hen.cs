namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Foods;
    public class Hen : Bird
    {
        private const double HenWeight = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.Foods = new List<Type>
            {
            typeof(Fruit),
            typeof(Seeds),
            typeof(Meat),
            typeof(Vegetable)
            };
        }

        protected override double WeightMultiplier => HenWeight;

        protected override ICollection<Type> Foods { get; }

        public override void ProduceSound()
        {
            System.Console.WriteLine("Cluck");
        }
    }
}
