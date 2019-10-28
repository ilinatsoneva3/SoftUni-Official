namespace ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var endNumber = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToList();

            List<int> listOfNumbers = GetNumbers(endNumber, dividers);

            Console.WriteLine(string.Join(" ", listOfNumbers));
        }

        private static List<int> GetNumbers(int number, List<int> dividers)
        {
            List<int> result = new List<int>();
            for (int i = 1; i <= number; i++)
            {
                bool isValid = true;
                foreach (var d in dividers)
                {
                    Predicate<int> uncleanCut = x => i % x != 0;
                    if (uncleanCut(d))
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                {
                    result.Add(i);
                }
            }
            return result;
        }
    }
}
