using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var currentInput = Console.ReadLine().Split(new string[] {" -> "},StringSplitOptions.None);
                var color = currentInput[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                var clothesInput = currentInput[1].Split(',');

                for (int j = 0; j < clothesInput.Length; j++)
                {
                    var currentClothing = clothesInput[j];

                    if (!wardrobe[color].ContainsKey(currentClothing))
                    {
                        wardrobe[color][currentClothing] = 0;
                    }
                    wardrobe[color][currentClothing]++;
                }
            }

            var clothesToFind = Console.ReadLine().Split();

            foreach (var kvp in wardrobe)
            {
                var colorToFind = clothesToFind[0];
                var pieceToFind = clothesToFind[1];

                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var item in kvp.Value)
                {
                    if (kvp.Key==colorToFind && item.Key == pieceToFind) ////
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
