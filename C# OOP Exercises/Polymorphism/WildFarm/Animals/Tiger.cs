namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Foods;
    public class Tiger : Feline
    {
        private const double TigerWeight = 1.0;
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.Foods = new List<Type>
            {
            typeof(Meat)
            };
        }

        protected override double WeightMultiplier => TigerWeight;

        protected override ICollection<Type> Foods { get; }

        public override void ProduceSound()
        {
            System.Console.WriteLine("ROAR!!!");
        }
    }
}
