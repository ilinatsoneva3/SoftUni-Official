namespace MakeASalad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        const int TomatoCalories = 80;
        const int CarrotCalories = 136;
        const int LettuceCalories = 109;
        const int PotatoCalories = 215;
        static void Main(string[] args)
        {
            var vegetables = new Queue<string>(Console.ReadLine().Split());
            var calories = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var saladsMade = new Queue<int>();

            while (calories.Any() && vegetables.Any())
            {

                var currentSaladCalorie = calories.Peek();

                while (currentSaladCalorie > 0 && vegetables.Any())
                {
                    var currentVegetable = vegetables.Dequeue();

                    switch (currentVegetable)
                    {
                        case "tomato":
                            currentSaladCalorie -= TomatoCalories;
                            break;
                        case "carrot":
                            currentSaladCalorie -= CarrotCalories;
                            break;
                        case "lettuce":
                            currentSaladCalorie -= LettuceCalories;
                            break;
                        case "potato":
                            currentSaladCalorie -= PotatoCalories;
                            break;
                    }
                }

                saladsMade.Enqueue(calories.Pop());
            }

            if (saladsMade.Any())
            {
                Console.WriteLine(string.Join(" ", saladsMade));
            }

            if (vegetables.Any())
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
            else if (calories.Any())
            {
                Console.WriteLine(string.Join(" ", calories));
            }
        }
    }
}