namespace WildFarm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WildFarm.Animals;
    using WildFarm.Foods;

    public class Engine
    {
        private ICollection<Animal> animals;
        private List<string> input;
        private AnimalCreator animalCreator;
        private FoodCreator foodCreator;

        public Engine()
        {
            this.animals = new List<Animal>();
            this.animalCreator = new AnimalCreator();
            this.foodCreator = new FoodCreator();
        }

        public void Run()
        {
            this.input = Console.ReadLine().Split().ToList();

            while (input[0] !="End")
            {
                Animal animal = this.animalCreator.CreateAnimal(input);
                this.animals.Add(animal);
                input = Console.ReadLine().Split().ToList();
                Food food = this.CreateFood(input);

                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

               input= Console.ReadLine().Split().ToList();
            }

            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }

        private Food CreateFood(IList<string> args)
        {
            string type = args[0];
            var quantity = int.Parse(args[1]);

            switch (type)
            {
                case nameof(Vegetable):
                    return new Vegetable(quantity);
                case nameof(Seeds):
                    return new Seeds(quantity);
                case nameof(Meat):
                    return new Meat(quantity);
                case nameof(Fruit):
                    return new Fruit(quantity);
                default:
                    throw new ArgumentException($"{type} is invalid type of food!");
            }
        }
    }
}
