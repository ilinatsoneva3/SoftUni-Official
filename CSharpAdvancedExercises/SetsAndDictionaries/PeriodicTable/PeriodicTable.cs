using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var chemicalSet = new HashSet<string>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine().Split();
                for (int j = 0; j < input.Length; j++)
                {
                    chemicalSet.Add(input[j]);
                }
            }

            var chemicalList = new List<String>();

            foreach (var item in chemicalSet)
            {
                chemicalList.Add(item);
            }

            chemicalList.Sort();
            Console.WriteLine(string.Join(' ', chemicalList));
        }
    }
}
