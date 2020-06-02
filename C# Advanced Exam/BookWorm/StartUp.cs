namespace BookWorm
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var result = new LinkedList<char>(Console.ReadLine().ToCharArray());
            var rows = int.Parse(Console.ReadLine());
            var field = new char[rows][];
            var playerRow = 0;
            var playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            var command = Console.ReadLine();

            while (command != "end")
            {
                bool isOutside = true;

                switch (command)
                {
                    case "left":
                        isOutside = CheckBoundaries(playerRow, playerCol - 1, field);
                        break;
                    case "right":
                        isOutside = CheckBoundaries(playerRow, playerCol + 1, field);
                        break;
                    case "up":
                        isOutside = CheckBoundaries(playerRow - 1, playerCol, field);
                        break;
                    case "down":
                        isOutside = CheckBoundaries(playerRow + 1, playerCol, field);
                        break;
                }

                if (!isOutside)
                {
                    if (result.Any())
                    {
                        result.RemoveLast();
                    }
                }
                else
                {
                    field[playerRow][playerCol] = '-';

                    switch (command)
                    {
                        case "left":
                            playerCol -= 1;
                            break;
                        case "right":
                            playerCol += 1;
                            break;
                        case "up":
                            playerRow -= 1;
                            break;
                        case "down":
                            playerRow += 1;
                            break;
                    }

                    if (char.IsLetter(field[playerRow][playerCol]))
                    {
                        result.AddLast(field[playerRow][playerCol]);
                    }

                    field[playerRow][playerCol] = 'P';
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join("", result));

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join("", field[row]));
            }
        }
        private static bool CheckBoundaries(int row, int col, char[][] field)
        {
            return row >= 0 && col >= 0 && row < field.Length && col < field[row].Length;
        }
    }
}
