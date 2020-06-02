namespace OpinionPoll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class StartUp
    {
        static void Main(string[] args)
        {
            var numberOfFamilyMembers = int.Parse(Console.ReadLine());
            var listOfPeople = new List<Person>();

            for (int i = 0; i < numberOfFamilyMembers; i++)
            {
                var input = Console.ReadLine().Split().ToList();
                var name = input[0];
                var age = int.Parse(input[1]);
                var person = new Person(name, age);
                listOfPeople.Add(person);
            }

            foreach (var member in listOfPeople.Where(x => x.Age > 30).OrderBy(x => x.Name))
            {
                Console.WriteLine($"{member.Name} - {member.Age}");
            }
        }
    }
}
