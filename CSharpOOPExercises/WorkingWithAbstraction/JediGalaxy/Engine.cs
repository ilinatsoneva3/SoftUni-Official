namespace JediGalaxy
{
    using System;
    using System.Linq;
    public class Engine
    {
        private int[,] matrix;
        private long sum = 0;

        public void Run()
        {
            int[] dimentions = Console.ReadLine()
               .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            int rows = dimentions[0];
            int cols = dimentions[1];

            this.CreateMatrix(rows, cols);

            string command = Console.ReadLine();
           
            while (command != "Let the Force be with you")
            {
                int[] playerCoordinates = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int[] evilCoordinates
                    = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evilRow = evilCoordinates[0];
                int evilCol = evilCoordinates[1];

                this.MoveEvil(evilRow, evilCol);

                int playerRow = playerCoordinates[0];
                int playerCol = playerCoordinates[1];

                this.MovePlayer(playerRow, playerCol);

                command = Console.ReadLine();
            }

            Console.WriteLine(this.sum);
        }

        private void MovePlayer(int playerRow, int playerCol)
        {
            while (playerRow >= 0 && playerCol < matrix.GetLength(1))
            {
                if (this.IsInside(playerRow, playerCol))
                {
                    this.sum += this.matrix[playerRow, playerCol];
                }

                playerCol++;
                playerRow--;
            }
        }

        private void MoveEvil(int evilRow, int evilCol)
        {
            while (evilRow >= 0 && evilCol >= 0)
            {
                if (this.IsInside(evilRow, evilCol))
                {
                    this.matrix[evilRow, evilCol] = 0;
                }

                evilRow--;
                evilCol--;
            }
        }

        private bool IsInside(int targetRow, int targetCol)
        {
            return targetRow >= 0
                && targetRow < this.matrix.GetLength(0)
                && targetCol >= 0
                && targetCol < this.matrix.GetLength(1);
        }

        private void CreateMatrix(int rows, int cols)
        {
            this.matrix = new int[rows, cols];

            int value = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    this.matrix[row, col] = value++;
                }
            }
        }
    }
}
