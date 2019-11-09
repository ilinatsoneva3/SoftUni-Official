namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private double money;
        private List<Product> products;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
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

        public double Money
        {
            get => this.money;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.MoneyIsNegativeException);
                }

                this.money = value;
            }
        }

        public void AddProduct(Product product)
        {
            bool hasEnoughMoney = CanBuy(product);

            if (hasEnoughMoney)
            {
                this.Money -= product.Cost;
                this.products.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            string result = ValidateProductsBought();
            
            return result;
        }

        private string ValidateProductsBought()
        {
            if (this.products.Count>0)
            {
                return $"{this.Name} - {string.Join(", ", this.products)}";
            }
            else
            {
                return $"{this.Name} - Nothing bought";
            }
        }

        private bool CanBuy(Product product)
        {
            if (this.Money < product.Cost)
            {
                return false;
            }

            return true;
        }
    }
}
