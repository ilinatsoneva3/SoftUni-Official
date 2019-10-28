namespace ReverseAndExclude
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var listOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var divider = int.Parse(Console.ReadLine());
            listOfNumbers = listOfNumbers.Where(x => x % divider != 0).ToList();
            listOfNumbers.Reverse();
            Console.WriteLine(string.Join(" ", listOfNumbers));
        }
    }
}
