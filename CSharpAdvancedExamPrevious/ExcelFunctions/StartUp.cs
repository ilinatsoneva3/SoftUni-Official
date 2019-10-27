namespace ExcelFunctions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var table = new string[n][];

            for (int row = 0; row < n; row++)
            {
                table[row] = Console.ReadLine().Split(", ");
            }

            var filtersData = Console.ReadLine().Split();
            var command = filtersData[0];
            var header = filtersData[1];
            var headerIndex = Array.IndexOf(table[0], header);

            if (command == "hide")
            {
                for (int row = 0; row < table.Length; row++)
                {
                    var list = new List<string>();
                    list.AddRange(table[row].Take(headerIndex).ToList());
                    list.AddRange(table[row].Skip(headerIndex + 1).ToList());
                    Console.WriteLine(string.Join(" | ", list));
                }
            }
            else if (command == "sort")
            {
                var currentHeader = table[0];
                Console.WriteLine(string.Join(" | ", currentHeader));

                table = table.OrderBy(x => x[headerIndex]).ToArray();

                foreach (var row in table)
                {
                    if (row == currentHeader)
                    {
                        continue;
                    }

                    Console.WriteLine(string.Join(" | ", row));
                }
            }
            else if (command == "filter")
            {
                var currentHeader = table[0];
                Console.WriteLine(string.Join(" | ", currentHeader));
                var value = filtersData[2];

                for (int i = 1; i < table.Length; i++)
                {
                    if (table[i][headerIndex] == value)
                    {
                        Console.WriteLine(string.Join(" | ", table[i]));
                    }
                }
            }
        }
    }
}
