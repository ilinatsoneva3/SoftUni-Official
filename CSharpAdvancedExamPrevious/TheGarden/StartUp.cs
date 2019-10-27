namespace TheGarden
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var garden = new string[rows][];
            var vegetablesCollected = new Dictionary<string, int>
            {
                {"Carrots", 0 },
                {"Potatoes", 0 },
                { "Lettuce", 0 }
            };
            var harmedVegetables = 0;

            for (int row = 0; row < rows; row++)
            {
                garden[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            var command = Console.ReadLine();

            while (command != "End of Harvest")
            {
                var input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var action = input[0];
                var row = int.Parse(input[1]);
                var col = int.Parse(input[2]);

                if (row < 0 || col < 0 || row >= rows || col >= garden[row].Length)
                {
                    command = Console.ReadLine();
                    continue;
                }

                if (action == "Harvest")
                {
                    if (garden[row][col] == "P")
                    {
                        vegetablesCollected["Potatoes"]++;
                        garden[row][col] = " ";
                    }
                    else if (garden[row][col] == "L")
                    {
                        vegetablesCollected["Lettuce"]++;
                        garden[row][col] = " ";
                    }
                    else if (garden[row][col] == "C")
                    {
                        vegetablesCollected["Carrots"]++;
                        garden[row][col] = " ";
                    }
                }
                else if (action == "Mole")
                {
                    var direction = input[3];

                    if (garden[row][col] != " ")
                    {
                        garden[row][col] = " ";
                        harmedVegetables++;
                    }

                    if (direction == "left")
                    {
                        for (int currentCol = col - 2; currentCol >= 0; currentCol -= 2)
                        {
                            if (garden[row][currentCol] != " ")
                            {
                                garden[row][currentCol] = " ";
                                harmedVegetables++;
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int currentCol = col + 2; currentCol < garden[row].Length; currentCol += 2)
                        {
                            if (garden[row][currentCol] != " ")
                            {
                                garden[row][currentCol] = " ";
                                harmedVegetables++;
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int currentRow = row + 2; currentRow < rows; currentRow += 2)
                        {
                            if (garden[currentRow][col] != " ")
                            {
                                garden[currentRow][col] = " ";
                                harmedVegetables++;
                            }
                        }
                    }
                    else if (direction == "up")
                    {
                        for (int currentRow = row - 2; currentRow >= 0; currentRow -= 2)
                        {
                            if (garden[currentRow][col] != " ")
                            {
                                garden[currentRow][col] = " ";
                                harmedVegetables++;
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(" ", garden[row]));
            }

            foreach (var vegetable in vegetablesCollected)
            {
                Console.WriteLine($"{vegetable.Key}: {vegetable.Value}");
            }

            Console.WriteLine($"Harmed vegetables: {harmedVegetables}");
        }
    }
}
