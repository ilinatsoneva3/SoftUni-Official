namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Foods;
    public class Dog : Mammal
    {
        private const double DogWeight = 0.40;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.Foods = new List<Type>
            {
            typeof(Meat)
            };
        }

        protected override double WeightMultiplier => DogWeight;

        protected override ICollection<Type> Foods { get; }

        public override void ProduceSound()
        {
            System.Console.WriteLine("Woof!");
        }
    }
}
