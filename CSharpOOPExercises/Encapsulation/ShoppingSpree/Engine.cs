namespace ShoppingSpree
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private List<Person> people;
        private List<Product> products;

        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                var peopleDetails = Console.ReadLine()
               .Split(";", StringSplitOptions.RemoveEmptyEntries)
               .ToList();

                AddPeople(peopleDetails);

                var productsDetails = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                AddProducts(productsDetails);

                BuyAllTheProducts();

                PrintPeople();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }           
        }

        private void PrintPeople()
        {
            foreach (var person in this.people)
            {
                Console.WriteLine(person);
            }
        }

        private void BuyAllTheProducts()
        {
            var command = Console.ReadLine();

            while (command != "END")
            {
                var input = command.Split().ToList();
                var currentPerson = people
                    .Where(x => x.Name == input[0])
                    .First();
                var currentProduct = products
                    .Where(x => x.Name == input[1])
                    .First();
                currentPerson.AddProduct(currentProduct);
                command = Console.ReadLine();
            }
        }

        private void AddProducts(List<string> productsDetails)
        {
            foreach (var productDetails in productsDetails)
            {
                var args = productDetails
                    .Split("=")
                    .ToArray();
                var name = args[0];
                var cost = double.Parse(args[1]);
                var product = new Product(name, cost);
                this.products.Add(product);
            }
        }

        private void AddPeople(List<string> peopleDetails)
        {
            foreach (var personDetails in peopleDetails)
            {
                var args = personDetails.Split("=").ToArray();
                var name = args[0];
                var money = double.Parse(args[1]);
                var person = new Person(name, money);
                this.people.Add(person);
            }
        }
    }
}
