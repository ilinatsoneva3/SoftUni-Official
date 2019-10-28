using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionaryOfNumbers = new Dictionary<int, int>();

            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());

                if (!dictionaryOfNumbers.ContainsKey(currentNumber))
                {
                    dictionaryOfNumbers[currentNumber] = 0;
                }
                dictionaryOfNumbers[currentNumber]++;
            }

            foreach (var item in dictionaryOfNumbers.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
