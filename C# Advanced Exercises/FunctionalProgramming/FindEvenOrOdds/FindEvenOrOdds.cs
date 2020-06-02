namespace FindEvenOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();
            var listOFNumbers = new List<int>();

            for (int i = input[0]; i <= input[1]; i++)
            {
                listOFNumbers.Add(i);
            }

            var condition = Console.ReadLine();

            Func<List<int>, string, List<int>> FindResult = (numbers, stringCondition) =>
            {
                switch (stringCondition)
                {
                    case "odd": return numbers.Where(x => x % 2 != 0).ToList();
                    case "even": return numbers.Where(x => x % 2 == 0).ToList();
                    default: return null;
                }
            };

            var finalList = FindResult(listOFNumbers, condition);

            Console.WriteLine(string.Join(" ", finalList));
        }
    }
}
