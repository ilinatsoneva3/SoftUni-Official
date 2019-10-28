using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionaryOfSymbols = new SortedDictionary<char, int>();
            var input = Console.ReadLine().ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                var currChar = input[i];
                if (!dictionaryOfSymbols.ContainsKey(currChar))
                {
                    dictionaryOfSymbols[currChar] = 0;
                }
                dictionaryOfSymbols[currChar]++;
            }

            foreach (var kvp in dictionaryOfSymbols)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
