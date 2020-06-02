namespace AppliedArithmetics
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var listOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            var command = string.Empty;

            Action<string> changeList = condition =>
             {
                 switch (condition)
                 {
                     case "add":
                         listOfNumbers = listOfNumbers.Select(x => x+1).ToList(); break;
                     case "multiply":
                         listOfNumbers=  listOfNumbers.Select(x => x * 2).ToList(); break;
                     case "subtract":
                         listOfNumbers = listOfNumbers.Select(x => x-1).ToList(); break;
                    case "print":
                         Console.WriteLine(string.Join(" ", listOfNumbers)); break;                     
                 }
             };

            while ((command=Console.ReadLine())!="end")
            {
                changeList(command);
            }
        }
    }
}
