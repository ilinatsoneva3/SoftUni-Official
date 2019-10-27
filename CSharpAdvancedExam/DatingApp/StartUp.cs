namespace DatingApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var males = new Stack<int>(Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse));
            var females = new Queue<int>(Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse));
            var matches = 0;

            while (females.Any() && males.Any())
            {
                var currentFemale = females.Peek();
                var currentMale = males.Peek();

                if (currentFemale <= 0)
                {
                    females.Dequeue();
                }
                else if (currentMale <= 0)
                {
                    males.Pop();
                }
                else if (currentFemale % 25 == 0)
                {
                    females.Dequeue();
                    if (females.Any())
                    {
                        females.Dequeue();
                    }
                }
                else if (currentMale % 25 == 0)
                {
                    males.Pop();
                    if (males.Any())
                    {
                        males.Pop();
                    }
                }
                else if (currentFemale == currentMale)
                {
                    females.Dequeue();
                    males.Pop();
                    matches++;
                }
                else if (currentFemale != currentMale)
                {
                    females.Dequeue();
                    males.Pop();
                    currentMale -= 2;
                    males.Push(currentMale);
                }
            }

            Console.WriteLine($"Matches: {matches}");

            if (males.Any())
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (females.Any())
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
