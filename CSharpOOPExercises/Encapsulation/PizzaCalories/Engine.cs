namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            try
            {
                var input = InputParser();

                var pizza = CreatePizza(input);

                input = InputParser();

                var dough = CreateDough(input);

                pizza.AddDough(dough);

                input = InputParser();

                while (input[0]!="END")
                {
                    var topping = CreateTopping(input);
                    pizza.AddTopping(topping);

                    input = InputParser();
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }           
        }

        private Topping CreateTopping(List<string> input)
        {
            var toppingType = input[1];
            var toppingWeight = double.Parse(input[2]);
            var topping = new Topping(toppingType, toppingWeight);
            return topping;
        }

        private Dough CreateDough(List<string> input)
        {
            var doughType = input[1];
            var doughTechnique = input[2];
            var doughWeight = double.Parse(input[3]);
            var dough = new Dough(doughType, doughTechnique, doughWeight);
            return dough;
        }

        private Pizza CreatePizza(List<string> input)
        {
            var pizzaName = input[1];
            var pizza = new Pizza(pizzaName);
            return pizza;
        }

        private List<String> InputParser()
        {
            var parser = Console.ReadLine()
                    .Split(" ")
                    .ToList();
            return parser;
        }
    }
}
