namespace PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var trainers = new Dictionary<string, Trainer>();

            while (input != "Tournament")
            {
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                var tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                var trainerName = tokens[0];

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                var trainer = trainers[trainerName];
                var pokemonName = tokens[1];
                var pokemonElement = tokens[2];
                var pokemonHealth = int.Parse(tokens[3]);
                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainer.Pokemons.Add(pokemon);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(x => x.Element == input))
                    {
                        trainer.Value.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Value.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }

                input = Console.ReadLine();
            }

            var result = trainers.OrderByDescending(x => x.Value.Badges).ToDictionary(x => x.Key, x => x.Value);

            foreach (var trainer in result)
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
