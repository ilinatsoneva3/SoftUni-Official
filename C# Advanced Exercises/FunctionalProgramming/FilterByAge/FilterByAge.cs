namespace FilterByAge
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var peopleDetails = new Dictionary<string, int>();
            var people = int.Parse(Console.ReadLine());

            for (int i = 0; i < people; i++)
            {
                var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                peopleDetails.Add(input[0], int.Parse(input[1]));
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var print = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, age); //filters according to the conditions
            Action<KeyValuePair<string, int>> printer = CreatePrinter(print);

            foreach (var person in peopleDetails)
            {
                if (tester(person.Value))
                {
                    printer(person);
                }
            }

        }
        
        public static Action<KeyValuePair<string, int>> CreatePrinter(string print)
        {
            switch (print)
            {
                case "name": return person => Console.WriteLine($"{person.Key}");
                case "name age": return person => Console.WriteLine($"{person.Key} - {person.Value}");
                case "age": return person => Console.WriteLine($"{person.Value}");
                default: return null;
            }
        }

        private static Func<int, bool> CreateTester(string condition, int age)
        {
            switch (condition)
            {
                case "younger": return x=> x < age;
                case "older": return x => x >= age;
                default: return null;
            }
        }
    }
}
