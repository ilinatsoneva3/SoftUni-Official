namespace SpaceshipCrafting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class StartUp
    {
        static void Main(string[] args)
        {
            var materials = new Dictionary<int, string>
            {
                {25, "Glass" },
                { 50, "Aluminium"},
                {75, "Lithium" },
                {100,"Carbon fiber" }
            };

            var materialsCollected = new Dictionary<string, int>
            {
                {"Glass" , 0},
                {"Aluminium", 0},
                {"Lithium", 0 },
                {"Carbon fiber",0 }
            };

            var liquids = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var physicalItems = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            while (liquids.Any() && physicalItems.Any())
            {
                var currentLiquid = liquids.Peek();
                var currentPhysicalItem = physicalItems.Peek();
                var sum = currentLiquid + currentPhysicalItem;

                if (materials.ContainsKey(sum))
                {
                    var material = materials[sum];
                    materialsCollected[material]++;
                    liquids.Dequeue();
                    physicalItems.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    currentPhysicalItem = physicalItems.Pop();
                    currentPhysicalItem += 3;
                    physicalItems.Push(currentPhysicalItem);
                }
            }

            if (materialsCollected.Any(x => x.Value == 0))
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }
            else
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }

            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (physicalItems.Any())
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", physicalItems)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            foreach (var material in materialsCollected.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}