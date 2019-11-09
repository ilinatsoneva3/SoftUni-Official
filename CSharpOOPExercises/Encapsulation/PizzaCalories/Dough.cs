

namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Dough : IIngredients
    {
        private const int MinimumWeight = 1;
        private const int MaximumWeight = 200;
        private Dictionary<string, double> caloriesModifiersPerType = new Dictionary<string, double>
        {
            {"white", 1.5 },
            {"wholegrain", 1.0 },
        };

        private Dictionary<string, double> caloriesModifiersPerTechnique = new Dictionary<string, double>
        {
            {"crispy", 0.9 },
            {"chewy", 1.1},
            {"homemade", 1.0 },
        };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
            this.TotalCalories = this.GetTotalCalories();
        }

        public string FlourType
        {
            get => this.flourType;

            private set
            {
                if (!this.caloriesModifiersPerType.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;

            private set
            {
                if (!this.caloriesModifiersPerTechnique.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;

            private set
            {
                if (value < MinimumWeight || value > MaximumWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinimumWeight}..{MaximumWeight}].");
                }

                this.weight = value;
            }
        }

        public double CaloriesPerGram { get; private set; } = 2;

        public double TotalCalories { get; private set; }

        public double GetTotalCalories()
        {
            double typeModifier = this.caloriesModifiersPerType[this.flourType.ToLower()];
            double techniqueModifier = this.caloriesModifiersPerTechnique[this.bakingTechnique.ToLower()];
            this.TotalCalories = this.CaloriesPerGram * this.Weight * typeModifier * techniqueModifier;
            return this.TotalCalories;
        }
    }
}
