namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new List<IBirthable>();

            var input = Console.ReadLine().Split().ToList();

            while (input[0]!="End")
            {
                if (input[0]=="Citizen")
                {
                    list.Add(new Citizen(input[1], int.Parse(input[2]), input[3], input[4]));
                }
                else if (input[0]=="Pet")
                {
                    list.Add(new Pet(input[1], input[2]));
                }

                input = Console.ReadLine().Split().ToList();
            }

            string filter = Console.ReadLine();

            list
                .Where(x => x.BirthDate.EndsWith(filter))
                .Select(x => x.BirthDate)
                .ToList()
                .ForEach(x=>Console.WriteLine(x));
        }
    }
}
