namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Topping : IIngredients
    {
        private const double MinimumWeight = 1;
        private const double MaximumWeight = 50;
        private Dictionary<string, double> caloriesModifiersPerType = new Dictionary<string, double>
        {
            {"meat", 1.2 },
            {"veggies", 0.8 },
            {"cheese", 1.1 },
            {"sauce", 0.9 }
        };

        private string toppingType;
        private double weigth;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
            this.TotalCalories = this.GetTotalCalories();
        }

        public string ToppingType
        {
            get => this.toppingType;

            private set
            {
                if (!caloriesModifiersPerType.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }
        public double Weight
        {
            get => this.weigth;

            private set
            {
                if (value < MinimumWeight || value > MaximumWeight)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [{MinimumWeight}..{MaximumWeight}].");
                }

                this.weigth = value;
            }
        }
        public double CaloriesPerGram { get; private set; } = 2;

        public double TotalCalories { get; private set; }

        public double GetTotalCalories()
        {
            double modifier = this.caloriesModifiersPerType[this.toppingType.ToLower()];
            this.TotalCalories = this.CaloriesPerGram * modifier * this.Weight;
            return this.TotalCalories;
        }
    }
}
