namespace PredicateForNames
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var maxLenght = int.Parse(Console.ReadLine());
            var listOfNames = Console.ReadLine().Split();
            Func<string, bool> nameValidator = name => name.Length <= maxLenght;

            foreach (var name in listOfNames.Where(nameValidator))
            {
                Console.WriteLine(name);
            }
        }
    }
}
