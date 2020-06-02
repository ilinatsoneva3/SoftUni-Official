namespace TriFunction
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var listOfNames = Console.ReadLine().Split().ToList();

            Func<string, int, bool> isGreaterSum = (name, length) => name.ToCharArray().Select(symbol => (int)symbol).Sum() >= length;

            Func<List<string>, int, Func<string, int, bool>, string> firstName = (list, num, function) 
                => list.FirstOrDefault(str => function(str, num));

            var result = firstName(listOfNames, number, isGreaterSum);
            Console.WriteLine(result);
        }
    }
}
