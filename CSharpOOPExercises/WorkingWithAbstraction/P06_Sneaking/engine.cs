using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P06_Sneaking
{
    public class Engine
    {
        private char[][] matrix;

        public Engine()
        {
            this.matrix = new char[0][];
        }

        public void Run()
        {
            int rowsCount = int.Parse(Console.ReadLine());
            this.matrix = new char[rowsCount][];

            int[] playerCoordinates = InitializeMatrix();

            string command = Console.ReadLine();

            foreach (var move in command)
            {
                this.UpdateEnemies();
                this.CheckEnemies();
                this.MovePlayer(move, playerCoordinates);
                this.CheckOppositePlayer();
            }
        }

        private void CheckOppositePlayer()
        {
            for (var line = 0; line < matrix.Length; line++)
            {
                if (this.matrix[line].Contains('N') && this.matrix[line].Contains('S'))
                {
                    this.matrix[line][Array.IndexOf(this.matrix[line], 'N')] = 'X';
                    Console.WriteLine($"Nikoladze killed!");
                    PrintMatrix();
                }
            }
        }

        private void MovePlayer(char move, int[] coordinates)
        {
            switch (move)
            {
                case 'U':
                    this.matrix[coordinates[0]][coordinates[1]] = '.';
                    this.matrix[--coordinates[0]][coordinates[1]] = 'S';
                    break;
                case 'D':
                    this.matrix[coordinates[0]][coordinates[1]] = '.';
                    this.matrix[++coordinates[0]][coordinates[1]] = 'S';
                    break;
                case 'L':
                    this.matrix[coordinates[0]][coordinates[1]] = '.';
                    this.matrix[coordinates[0]][--coordinates[1]] = 'S';
                    break;
                case 'R':
                    this.matrix[coordinates[0]][coordinates[1]] = '.';
                    this.matrix[coordinates[0]][++coordinates[1]] = 'S';
                    break;
                default:
                    break;
            }
        }

        private void CheckEnemies()
        {
            for (var line = 0; line < matrix.Length; line++)
            {
                if (this.matrix[line].Contains('b') && this.matrix[line].Contains('S'))
                {
                    if (Array.IndexOf(this.matrix[line], 'b') < Array.IndexOf(this.matrix[line], 'S'))
                    {
                        this.matrix[line][Array.IndexOf(this.matrix[line], 'S')] = 'X';
                        Console.WriteLine($"Sam died at {line}, {Array.IndexOf(matrix[line], 'X')}");
                        PrintMatrix();
                    }
                }
                else if (this.matrix[line].Contains('d') && this.matrix[line].Contains('S'))
                {
                    if (Array.IndexOf(this.matrix[line], 'd') > Array.IndexOf(this.matrix[line], 'S'))
                    {
                        this.matrix[line][Array.IndexOf(this.matrix[line], 'S')] = 'X';
                        Console.WriteLine($"Sam died at {line}, {Array.IndexOf(this.matrix[line], 'X')}");
                        PrintMatrix();
                    }
                }
            }
        }

        private void PrintMatrix()
        {
            foreach (var line in this.matrix)
            {
                Console.WriteLine(String.Join("", line));
            }
            Environment.Exit(0);
        }

        private void UpdateEnemies()
        {
            for (int i = 0; i < this.matrix.Length; i++)
            {
                for (int j = 0; j < this.matrix[i].Length; j++)
                {
                    if (this.matrix[i][j] == 'b')
                    {
                        if (j == this.matrix[i].Length - 1)
                        {
                            this.matrix[i][j] = 'd';
                        }
                        else
                        {
                            this.matrix[i][j] = '.';
                            this.matrix[i][++j] = 'b';
                        }
                    }
                    else if (this.matrix[i][j] == 'd')
                    {
                        if (j == 0)
                        {
                            this.matrix[i][j] = 'b';
                        }
                        else
                        {
                            this.matrix[i][j] = '.';
                            this.matrix[i][j - 1] = 'd';
                        }
                    }
                }
            }
        }

        private int[] InitializeMatrix()
        {
            int[] coordinates = null;
            for (int i = 0; i < this.matrix.Length; i++)
            {
                string line = Console.ReadLine();

                this.matrix[i] = line.ToCharArray();

                if (this.matrix[i].Contains('S'))
                {
                    coordinates = new int[] { i, Array.IndexOf(matrix[i], 'S') };
                }
            }

            return coordinates;
        }
    }
}
