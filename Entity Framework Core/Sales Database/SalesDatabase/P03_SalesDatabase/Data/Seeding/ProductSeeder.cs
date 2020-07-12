namespace P03_SalesDatabase.Data.Seeding
{
    using P03_SalesDatabase.Data.IOManagement.Contracts;
    using P03_SalesDatabase.Data.Models;
    using P03_SalesDatabase.Data.Seeding.Contracts;
    using System;
    using System.Collections.Generic;

    public class ProductSeeder : ISeeder
    {
        private readonly Random random;
        private readonly SalesContext dbContext;
        private readonly IWriter writer;

        public ProductSeeder(SalesContext context, Random random, IWriter writer)
        {
            this.dbContext = context;
            this.random = random;
            this.writer = writer;
        }

        public void Seed()
        {
            ICollection<Product> products = new List<Product>();

            string[] names = new string[]
            {
                "Notebook",
                "Pen",
                "Book",
                "Pencil",
                "Bagpack",
                "Board game",
                "Study book",
                "Atlas",
                "Puzzle"
            };

            for (int i = 0; i < 50; i++)
            {
                var nameIndex = this.random.Next(names.Length);
                var currentName = names[nameIndex];
                var quantity = this.random.Next(100);
                var price = this.random.Next(5000) * 1.846m;

                var product = new Product()
                {
                    Name = currentName,
                    Quantity = quantity,
                    Price = price
                };

                products.Add(product);
                this.writer
                    .WriteLine($"Product {product.Name} with {product.Price} price and {product.Quantity} quantity was added.");
            }

            this.dbContext.AddRange(products);
            this.dbContext.SaveChanges();
        }
    }
}
