using System;
using System.Collections.Generic;

namespace RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<string>();
            var count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine();
                set.Add(input);
            }

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}
