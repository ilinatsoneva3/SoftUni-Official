namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Foods;
    public class Owl : Bird
    {
        private const double OwlWeight = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.Foods = new List<Type>
            {          
            typeof(Meat)
            };
        }

        protected override double WeightMultiplier => OwlWeight;

        protected override ICollection<Type> Foods { get; }

        public override void ProduceSound()
        {
            System.Console.WriteLine("Hoot Hoot");
        }
    }
}
