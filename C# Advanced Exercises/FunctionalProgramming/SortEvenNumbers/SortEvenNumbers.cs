namespace SortEvenNumbers
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var listOfNumbers = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList()
                .Where(x=>x%2==0)
                .OrderBy(x=>x);
            Console.WriteLine(string.Join(", ", listOfNumbers));
        }
    }
}
