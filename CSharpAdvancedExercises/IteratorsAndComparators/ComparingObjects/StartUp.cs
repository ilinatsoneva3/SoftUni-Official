namespace ComparingObjects
{
    using System;
    using System.Collections.Generic;
    class StartUp
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            var command = Console.ReadLine();

            while (command != "END")
            {
                var tokens = command.Split();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var town = tokens[2];
                people.Add(new Person(name, age, town));
                command = Console.ReadLine();
            }

            var n = int.Parse(Console.ReadLine());
            var numebrOfEqualPeople = 1;
            var personToCompare = people[n - 1];

            foreach (var person in people)
            {
                if (personToCompare.CompareTo(person) == 0 && !personToCompare.Equals(person))
                {
                    numebrOfEqualPeople++;
                }
            }

            if (numebrOfEqualPeople != 1)
            {
                Console.WriteLine($"{numebrOfEqualPeople} {people.Count - numebrOfEqualPeople} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
