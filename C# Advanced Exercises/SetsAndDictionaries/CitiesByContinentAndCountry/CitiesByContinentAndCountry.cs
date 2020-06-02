using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            var countryCatalogues = new Dictionary<string, Dictionary<string, List<string>>>();
            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();
                var continent = input[0];
                var country = input[1];
                var city = input[2];

                if (!countryCatalogues.ContainsKey(continent))
                {
                    countryCatalogues[continent] = new Dictionary<string, List<string>>();
                }
                if (!countryCatalogues[continent].ContainsKey(country))
                {
                    countryCatalogues[continent][country] = new List<string>();
                }
                countryCatalogues[continent][country].Add(city);
            }

            foreach (var kvp in countryCatalogues)
            {
                Console.WriteLine(kvp.Key+":");

                foreach (var kvpValue in kvp.Value)
                {
                    Console.WriteLine($"{kvpValue.Key} -> {string.Join(", ", kvpValue.Value)}");
                }
            }
        }
    }
}
