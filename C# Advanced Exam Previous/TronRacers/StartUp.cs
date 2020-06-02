namespace TronRacers
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var field = new char[rows][];
            var fRow = 0;
            var fCol = 0;
            var sRow = 0;
            var sCol = 0;

            for (int row = 0; row < rows; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'f')
                    {
                        fRow = row;
                        fCol = col;
                    }
                    else if (field[row][col] == 's')
                    {
                        sRow = row;
                        sCol = col;
                    }
                }
            }

            while (true)
            {
                var coordinates = Console.ReadLine().Split();
                var fCoordinate = coordinates[0];
                var sCoordinate = coordinates[1];

                switch (fCoordinate)
                {
                    case "right":
                        if (fCol + 1 >= rows)
                        {
                            fCol = 0;
                        }
                        else
                        {
                            fCol++;
                        }
                        break;
                    case "left":
                        if (fCol - 1 < 0)
                        {
                            fCol = rows - 1;
                        }
                        else
                        {
                            fCol--;
                        }
                        break;
                    case "down":
                        if (fRow + 1 >= rows)
                        {
                            fRow = 0;
                        }
                        else
                        {
                            fRow++;
                        }
                        break;
                    case "up":
                        if (fRow - 1 < 0)
                        {
                            fRow = rows - 1;
                        }
                        else
                        {
                            fRow--;
                        }
                        break;
                }

                if (field[fRow][fCol] == 's')
                {
                    field[fRow][fCol] = 'x';
                    break;
                }

                field[fRow][fCol] = 'f';

                switch (sCoordinate)
                {
                    case "right":
                        if (sCol + 1 >= rows)
                        {
                            sCol = 0;
                        }
                        else
                        {
                            sCol++;
                        }
                        break;
                    case "left":
                        if (sCol - 1 < 0)
                        {
                            sCol = rows - 1;
                        }
                        else
                        {
                            sCol--;
                        }
                        break;
                    case "down":
                        if (sRow + 1 >= rows)
                        {
                            sRow = 0;
                        }
                        else
                        {
                            sRow++;
                        }
                        break;
                    case "up":
                        if (sRow - 1 < 0)
                        {
                            sRow = rows - 1;
                        }
                        else
                        {
                            sRow--;
                        }
                        break;
                }

                if (field[sRow][sCol] == 'f')
                {
                    field[sRow][sCol] = 'x';
                    break;
                }

                field[sRow][sCol] = 's';
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join("", field[row]));
            }
        }
    }
}
