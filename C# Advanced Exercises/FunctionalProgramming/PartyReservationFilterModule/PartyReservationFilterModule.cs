namespace PartyReservationFilterModule
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, bool> startsWithFilter = (name, param) => name.StartsWith(param);
            Func<string, string, bool> endsWithFilter = (name, param) => name.EndsWith(param);
            Func<string, int, bool> lengthFilter = (name, param) => name.Length==param;
            Func<string, string, bool> containsFilter = (name, param) => name.Contains(param);

            var listOfNames = Console.ReadLine().Split().ToList();
            var filters = new List<string>();

            while (true)
            {
                var command = Console.ReadLine().Split(';');

                if (command[0]=="Print")
                {
                    break;
                }

                var action = command[0];
                var currentFilter = command[1];
                var value = command[2];

                if (action == "Add filter")
                {
                    filters.Add($"{currentFilter};{value}");
                }
                else if (action == "Remove filter")
                {
                    filters.Remove($"{currentFilter};{value}");
                }
            }

            foreach (var filter in filters)
            {
                var currentFilter = filter.Split(';');
                var currentAction = currentFilter[0];
                var value = currentFilter[1];

                switch (currentAction)
                {
                    case "Starts with":
                        listOfNames = listOfNames.Where(name => !startsWithFilter(name, value)).ToList();
                        break;
                    case "Ends with":
                        listOfNames = listOfNames.Where(name => !endsWithFilter(name, value)).ToList();
                        break;
                    case "Length":
                        listOfNames = listOfNames.Where(name => !lengthFilter(name, int.Parse(value))).ToList();
                        break;
                    case "Contains":
                        listOfNames = listOfNames.Where(name => !containsFilter(name, value)).ToList();
                        break;
                }
            }

            Console.WriteLine(string.Join(' ', listOfNames));
        }
    }
}
