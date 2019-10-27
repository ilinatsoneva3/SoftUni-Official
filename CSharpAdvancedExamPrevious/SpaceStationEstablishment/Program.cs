namespace SpaceStationEstablishment
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var matrix = new char[rows, rows];
            var playerCurrentPositionRow = 0;
            var playerCurrentPositionCol = 0;
            var firstBlackholeRow = -1;
            var firstBlackholeCol = -1;
            var secondBlackholeRow = -1;
            var secondBlackholeCol = -1;
            var isOver = true;

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rows; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (currentRow[col] == 'S')
                    {
                        playerCurrentPositionRow = row;
                        playerCurrentPositionCol = col;
                    }

                    if (currentRow[col] == 'O')
                    {
                        if (firstBlackholeRow != -1)
                        {
                            secondBlackholeRow = row;
                            secondBlackholeCol = col;
                        }
                        else
                        {
                            firstBlackholeRow = row;
                            firstBlackholeCol = col;
                        }
                    }
                }
            }

            var starsCollected = 0;

            while (starsCollected < 50)
            {
                var command = Console.ReadLine();

                if (command == "right")
                {
                    matrix[playerCurrentPositionRow, playerCurrentPositionCol] = '-';

                    if (playerCurrentPositionCol + 1 >= rows)
                    {
                        FailGame(matrix, starsCollected);
                        isOver = false;
                        break;
                    }

                    if (matrix[playerCurrentPositionRow, playerCurrentPositionCol + 1] == 'O')
                    {
                        matrix[playerCurrentPositionRow, playerCurrentPositionCol] = '-';

                        if (playerCurrentPositionRow == firstBlackholeRow && playerCurrentPositionCol + 1 == firstBlackholeCol)
                        {
                            playerCurrentPositionRow = secondBlackholeRow;
                            playerCurrentPositionCol = secondBlackholeCol;
                        }
                        else if (playerCurrentPositionRow == secondBlackholeRow && playerCurrentPositionCol + 1 == secondBlackholeCol)
                        {
                            playerCurrentPositionRow = firstBlackholeRow;
                            playerCurrentPositionCol = firstBlackholeCol;
                        }
                        matrix[firstBlackholeRow, firstBlackholeCol] = '-';
                        matrix[secondBlackholeRow, secondBlackholeCol] = '-';
                    }
                    else if (matrix[playerCurrentPositionRow, playerCurrentPositionCol + 1] == '-')
                    {
                        playerCurrentPositionCol++;
                    }
                    else
                    {
                        var currentStars = matrix[playerCurrentPositionRow, playerCurrentPositionCol + 1].ToString();
                        starsCollected += int.Parse(currentStars);
                        playerCurrentPositionCol++;
                    }
                }
                else if (command == "left")
                {
                    matrix[playerCurrentPositionRow, playerCurrentPositionCol] = '-';

                    if (playerCurrentPositionCol - 1 < 0)
                    {
                        FailGame(matrix, starsCollected);
                        isOver = false;
                        break;
                    }

                    if (matrix[playerCurrentPositionRow, playerCurrentPositionCol - 1] == 'O')
                    {
                        matrix[playerCurrentPositionRow, playerCurrentPositionCol] = '-';

                        if (playerCurrentPositionRow == firstBlackholeRow && playerCurrentPositionCol - 1 == firstBlackholeCol)
                        {
                            playerCurrentPositionRow = secondBlackholeRow;
                            playerCurrentPositionCol = secondBlackholeCol;
                        }
                        else if (playerCurrentPositionRow == secondBlackholeRow && playerCurrentPositionCol - 1 == secondBlackholeCol)
                        {
                            playerCurrentPositionRow = firstBlackholeRow;
                            playerCurrentPositionCol = firstBlackholeCol;
                        }
                        matrix[firstBlackholeRow, firstBlackholeCol] = '-';
                        matrix[secondBlackholeRow, secondBlackholeCol] = '-';
                    }
                    else if (matrix[playerCurrentPositionRow, playerCurrentPositionCol - 1] == '-')
                    {
                        playerCurrentPositionCol--;
                    }
                    else
                    {
                        starsCollected += int.Parse(matrix[playerCurrentPositionRow, playerCurrentPositionCol - 1].ToString());
                        playerCurrentPositionCol--;
                    }
                }
                else if (command == "down")
                {
                    matrix[playerCurrentPositionRow, playerCurrentPositionCol] = '-';

                    if (playerCurrentPositionRow + 1 >= rows)
                    {
                        FailGame(matrix, starsCollected);
                        isOver = false;
                        break;
                    }

                    if (matrix[playerCurrentPositionRow + 1, playerCurrentPositionCol] == 'O')
                    {
                        matrix[playerCurrentPositionRow, playerCurrentPositionCol] = '-';

                        if (playerCurrentPositionRow + 1 == firstBlackholeRow && playerCurrentPositionCol == firstBlackholeCol)
                        {
                            playerCurrentPositionRow = secondBlackholeRow;
                            playerCurrentPositionCol = secondBlackholeCol;
                        }
                        else if (playerCurrentPositionRow + 1 == secondBlackholeRow && playerCurrentPositionCol == secondBlackholeCol)
                        {
                            playerCurrentPositionRow = firstBlackholeRow;
                            playerCurrentPositionCol = firstBlackholeCol;
                        }
                        matrix[firstBlackholeRow, firstBlackholeCol] = '-';
                        matrix[secondBlackholeRow, secondBlackholeCol] = '-';
                    }
                    else if (matrix[playerCurrentPositionRow + 1, playerCurrentPositionCol] == '-')
                    {
                        playerCurrentPositionRow++;
                    }
                    else
                    {
                        starsCollected += int.Parse(matrix[playerCurrentPositionRow + 1, playerCurrentPositionCol].ToString());
                        playerCurrentPositionRow++;
                    }
                }
                else if (command == "up")
                {
                    matrix[playerCurrentPositionRow, playerCurrentPositionCol] = '-';

                    if (playerCurrentPositionRow - 1 < 0)
                    {
                        FailGame(matrix, starsCollected);
                        isOver = false;
                        break;
                    }

                    if (matrix[playerCurrentPositionRow - 1, playerCurrentPositionCol] == 'O')
                    {
                        matrix[playerCurrentPositionRow, playerCurrentPositionCol] = '-';

                        if (playerCurrentPositionRow - 1 == firstBlackholeRow && playerCurrentPositionCol == firstBlackholeCol)
                        {
                            playerCurrentPositionRow = secondBlackholeRow;
                            playerCurrentPositionCol = secondBlackholeCol;
                        }
                        else if (playerCurrentPositionRow - 1 == secondBlackholeRow && playerCurrentPositionCol == secondBlackholeCol)
                        {
                            playerCurrentPositionRow = firstBlackholeRow;
                            playerCurrentPositionCol = firstBlackholeCol;
                        }
                        matrix[firstBlackholeRow, firstBlackholeCol] = '-';
                        matrix[secondBlackholeRow, secondBlackholeCol] = '-';
                    }
                    else if (matrix[playerCurrentPositionRow - 1, playerCurrentPositionCol] == '-')
                    {
                        playerCurrentPositionRow--;
                    }
                    else
                    {
                        starsCollected += int.Parse(matrix[playerCurrentPositionRow - 1, playerCurrentPositionCol].ToString());
                        playerCurrentPositionRow--;
                    }
                }

                matrix[playerCurrentPositionRow, playerCurrentPositionCol] = 'S';
            }

            if (isOver)
            {
                SuccessGame(matrix, starsCollected);
            }
        }

        private static void SuccessGame(char[,] matrix, int starsCollected)
        {
            Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            Console.WriteLine($"Star power collected: {starsCollected}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void FailGame(char[,] matrix, int starsCollected)
        {
            Console.WriteLine("Bad news, the spaceship went to the void.");
            Console.WriteLine($"Star power collected: {starsCollected}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
