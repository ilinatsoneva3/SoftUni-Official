namespace CountUpperCaseWords
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpper = w => char.IsUpper(w[0]);

            var listOfWords = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Where(isUpper).ToList();

            foreach (var word in listOfWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
