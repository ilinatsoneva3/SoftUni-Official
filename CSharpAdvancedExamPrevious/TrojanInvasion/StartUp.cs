namespace TrojanInvasion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class StartUp
    {
        static void Main(string[] args)
        {
            var waves = int.Parse(Console.ReadLine());
            var plates = new LinkedList<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var warriors = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                if (plates.Count == 0)
                {
                    break;
                }

                var currentWave = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                if (i % 3 == 0)
                {
                    plates.AddLast(int.Parse(Console.ReadLine()));
                }

                for (int j = 0; j < currentWave.Count; j++)
                {
                    warriors.Push(currentWave[j]);
                }

                while (plates.Any() && warriors.Any())
                {
                    var warrior = warriors.Pop();
                    var plate = plates.First();

                    if (warrior < plate)
                    {
                        plate -= warrior;
                        plates.RemoveFirst();
                        plates.AddFirst(plate);
                    }
                    else if (warrior > plate)
                    {
                        warrior -= plate;
                        plates.RemoveFirst();
                        warriors.Push(warrior);
                    }
                    else
                    {
                        plates.RemoveFirst();
                    }

                }
            }

            if (plates.Any())
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else if (warriors.Any())
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", warriors)}");
            }
        }
    }
}
