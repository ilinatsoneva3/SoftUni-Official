namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Foods;
    public class Mouse : Mammal
    {
        private const double MouseWeight = 0.1;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.Foods = new List<Type>
            {
            typeof(Fruit),            
            typeof(Vegetable)
            };
        }

        protected override double WeightMultiplier => MouseWeight;

        protected override ICollection<Type> Foods { get; }

        public override void ProduceSound()
        {
            System.Console.WriteLine("Squeak");
        }
    }
}
