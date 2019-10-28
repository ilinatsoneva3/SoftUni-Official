namespace SumNumbers
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
               .ToList();
            Console.WriteLine(listOfNumbers.Count);
            Console.WriteLine(listOfNumbers.Sum());
        }
    }
}
