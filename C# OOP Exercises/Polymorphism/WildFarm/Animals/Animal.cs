namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WildFarm.Foods;
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.ProduceSound();
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        protected abstract double WeightMultiplier { get; }
        protected abstract ICollection<Type> Foods { get; }

        public abstract void ProduceSound();

        public virtual void Eat(Food food)
        {
            if (!this.Foods.Contains(food.GetType()))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }
    }
}
