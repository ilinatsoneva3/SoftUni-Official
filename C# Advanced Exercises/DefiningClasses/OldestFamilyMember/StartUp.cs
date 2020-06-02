namespace OldestFamilyMember
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var numberOfFamilyMembers = int.Parse(Console.ReadLine());
            var family = new Family();

            for (int i = 0; i < numberOfFamilyMembers; i++)
            {
                var input = Console.ReadLine().Split().ToList();
                var name = input[0];
                var age = int.Parse(input[1]);
                var person = new Person(name, age);
                family.AddMember(person);
            }

            var oldestMember = family.GetOldestMember();

            Console.WriteLine(oldestMember.Name + " " + oldestMember.Age);
        }
    }
}
