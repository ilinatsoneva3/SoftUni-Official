namespace ShoppingSpree
{
    using System;
    public class Product
    {
        private string name;
        private double cost;

        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameIsEmptyException);
                }

                this.name = value;
            }
        }

        public double Cost
        {
            get => this.cost;

            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(ExceptionMessages.MoneyIsNegativeException);
                }

                this.cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
