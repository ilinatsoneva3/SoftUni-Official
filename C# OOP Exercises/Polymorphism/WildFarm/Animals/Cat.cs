namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Foods;

    public class Cat : Feline
    {
        private const double CatWeight = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.Foods = new List<Type>
            {            
            typeof(Meat),
            typeof(Vegetable)
            };
        }

        protected override double WeightMultiplier => CatWeight;

        protected override ICollection<Type> Foods { get; }

        public override void ProduceSound()
        {
            System.Console.WriteLine("Meow");
        }
    }
}
