namespace AddVAT
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var listOfNumbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n * 1.2)
                .ToList();

            foreach (var number in listOfNumbers)
            {
                Console.WriteLine($"{number:F2}");
            }
        }
    }
}
