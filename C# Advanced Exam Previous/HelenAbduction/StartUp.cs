namespace HelenAbduction
{
    using System;
    using System.Collections.Generic;
    class StartUp
    {
        static void Main(string[] args)
        {
            var energy = int.Parse(Console.ReadLine());
            var rows = int.Parse(Console.ReadLine());
            var field = new char[rows][];
            var parisRow = 0;
            var parisCol = 0;

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                field[row] = new char[currentRow.Length];

                for (int col = 0; col < currentRow.Length; col++)
                {
                    field[row][col] = currentRow[col];

                    if (field[row][col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }
                }
            }

            while (true)
            {
                energy--;
                field[parisRow][parisCol] = '-';
                var input = Console.ReadLine().Split();
                var parisDirection = input[0];
                var enemyRow = int.Parse(input[1]);
                var enemyCol = int.Parse(input[2]);

                field[enemyRow][enemyCol] = 'S';

                if (parisDirection == "up")
                {
                    if (isInside(field, parisRow - 1, parisCol))
                    {
                        parisRow--;
                    }
                }
                else if (parisDirection == "down")
                {
                    if (isInside(field, parisRow + 1, parisCol))
                    {
                        parisRow++;
                    }
                }
                else if (parisDirection == "left")
                {
                    if (isInside(field, parisRow, parisCol - 1))
                    {
                        parisCol--;
                    }
                }
                else if (parisDirection == "right")
                {
                    if (isInside(field, parisRow, parisCol + 1))
                    {
                        parisCol++;
                    }
                }

                if (field[parisRow][parisCol] == 'S')
                {
                    energy -= 2;
                }
                else if (field[parisRow][parisCol] == 'H')
                {
                    field[parisRow][parisCol] = '-';
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}"); break;
                }

                if (energy <= 0)
                {
                    Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                    field[parisRow][parisCol] = 'X';
                    break;
                }
            }

            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    Console.Write(field[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static bool isInside(char[][] field, int parisRow, int parisCol)
        {
            return parisRow >= 0 && parisCol >= 0 && parisRow < field.Length && parisCol < field[parisRow].Length;
        }
    }
}