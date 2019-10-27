namespace Tuple
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            var firstAndLastName = input[0] + " " + input[1];
            var address = input[2];
            var town = input[3];

            if (input.Count == 5)
            {
                town += " " + input[4];
            }

            var firstTuple = new Threeuple<string, string, string>(firstAndLastName, address, town);
            Console.WriteLine(firstTuple);

            input = Console.ReadLine().Split().ToList();
            var name = input[0];
            var beer = int.Parse(input[1]);
            bool isDrunk = false;

            if (input[2] == "drunk")
            {
                isDrunk = true;
            }

            var secondTuple = new Threeuple<string, int, bool>(name, beer, isDrunk);
            Console.WriteLine(secondTuple);

            input = Console.ReadLine().Split().ToList();
            name = input[0];
            var balance = double.Parse(input[1]);
            var bankName = input[2];
            var thirdTuple = new Threeuple<string, double, string>(name, balance, bankName);
            Console.WriteLine(thirdTuple);
        }
    }
}
