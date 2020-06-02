namespace PredicateParty
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> predicate;

            var listOfNames = Console.ReadLine().Split().ToList();

            while (true)
            {
                var command = Console.ReadLine().Split();

                if (command[0] == "Party!")
                {
                    break;
                }

                var action = command[0];
                var condition = command[1];
                var value = command[2];

                predicate = GetPredicate(condition, value);

                switch (action)
                {
                    case "Remove":
                        listOfNames.RemoveAll(predicate);
                        break;

                    case "Double":
                        var doubledGuests = listOfNames.FindAll(predicate);

                        foreach (var guest in doubledGuests)
                        {
                            var index = listOfNames.IndexOf(guest);
                            listOfNames.Insert(index + 1, guest);
                        }
                        break;
                    default:
                        break;
                }
            }

            if (listOfNames.Any())
            {
                Console.WriteLine(string.Join(", ", listOfNames) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string condition, string value)
        {
            switch (condition)
            {
                case "StartsWith": return name => name.StartsWith(value);
                case "EndsWith": return name => name.EndsWith(value);
                case "Length": return name => name.Length == int.Parse(value);
                default: return null;
            }
        }
    }
}
