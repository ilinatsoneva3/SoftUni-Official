namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var rebellions = new List<Identifiable>();

            var input = Console.ReadLine().Split().ToList();

            while (input[0]!="End")
            {
                Identifiable rebellion = null;

                if (input.Count ==2)
                {
                    rebellion = new Robot(input[0], input[1]);
                }
                else
                {
                    rebellion = new Citizen(input[0], int.Parse(input[1]), input[2]);
                }

                rebellions.Add(rebellion);

                input = Console.ReadLine().Split().ToList();
            }

            var fakeId = Console.ReadLine();

            foreach (var rebellion in rebellions)
            {
                if (rebellion.CheckForFakeID(fakeId))
                {
                    Console.WriteLine(rebellion.Id);
                }
            }
        }
    }
}
