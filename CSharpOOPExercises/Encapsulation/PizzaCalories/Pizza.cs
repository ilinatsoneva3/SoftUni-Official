namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Pizza
    {
        private const int NameMaxLength = 15;
        private const int ToppingsMaxCount = 10;
        private string name;
        private List<Topping> toppings;
        private Dough dough;
        private double totalCalories;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > NameMaxLength)
                {
                    throw new ArgumentException($"Pizza name should be between 1 and {NameMaxLength} symbols.");
                }

                this.name = value;
            }
        }

        public void AddDough(Dough dough)
        {
            this.dough = dough;
            this.AddToTotalCalories(dough);
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count < ToppingsMaxCount)
            {
                this.toppings.Add(topping);
                this.AddToTotalCalories(topping);
            }
            else
            {
                throw new ArgumentException($"Number of toppings should be in range [0..{ToppingsMaxCount}].");
            }
        }

        public double GetTotalCalories()
        {
            return this.totalCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.totalCalories:F2} Calories.";
        }

        private void AddToTotalCalories(IIngredients ingredient)
        {
            var currentCalories = ingredient.TotalCalories;
            this.totalCalories += currentCalories;
        }
    }
}
