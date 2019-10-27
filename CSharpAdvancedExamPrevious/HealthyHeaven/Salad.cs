namespace HealthyHeaven
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    public class Salad
    {
        private List<Vegetable> products;
        public Salad(string name)
        {
            this.Name = name;
            this.products = new List<Vegetable>();
        }
        public string Name { get; set; }

        public int GetTotalCalories() => this.products.Sum(x => x.Calories);

        public int GetProductCount() => this.products.Count;

        public void Add(Vegetable vegetable)
        {
            this.products.Add(vegetable);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"* Salad {this.Name} is {this.GetTotalCalories()} calories and have {this.GetProductCount()} products:");

            foreach (var vegetable in this.products)
            {
                sb.AppendLine(vegetable.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
