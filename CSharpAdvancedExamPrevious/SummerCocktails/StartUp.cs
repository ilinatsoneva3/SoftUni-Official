namespace SummerCoctail
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var cocktailsMade = new Dictionary<int, string>
            {
                { 150, "Mimosa" },
                {250, "Daiquiri" },
                {300, "Sunshine" },
                {400, "Mojito"}
            };
            var cocktailsToPrint = new Dictionary<string, int>
            {
                {"Mimosa",0 },
                {"Daiquiri",0 },
                {"Sunshine",0 },
                {"Mojito",0 }
            };

            var ingredients = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            var freshness = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            while (ingredients.Any() && freshness.Any())
            {
                var currentIngredient = ingredients.Peek();
                var currentFreshness = freshness.Peek();
                var product = currentFreshness * currentIngredient;

                if (cocktailsMade.ContainsKey(product))
                {
                    var cocktailName = cocktailsMade[product];
                    cocktailsToPrint[cocktailName]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (currentIngredient == 0)
                {
                    ingredients.Dequeue();
                }
                else
                {
                    freshness.Pop();
                    currentIngredient = ingredients.Dequeue();
                    currentIngredient += 5;
                    ingredients.Enqueue(currentIngredient);
                }
            }

            bool isTaskDone = cocktailsToPrint.Any(x => x.Value == 0);

            if (isTaskDone)
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");

            }
            else
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var cocktail in cocktailsToPrint.OrderBy(x => x.Key).Where(x => x.Value > 0))
            {
                Console.WriteLine($" # {cocktail.Key} --> {cocktail.Value}");
            }
        }
    }
}