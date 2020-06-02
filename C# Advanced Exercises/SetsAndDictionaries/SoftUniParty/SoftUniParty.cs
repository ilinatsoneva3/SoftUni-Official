using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var vipSet = new HashSet<string>();
            var regularSet = new HashSet<string>();

            var input = string.Empty;

            while ((input=Console.ReadLine())!="PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vipSet.Add(input);
                }
                else
                {
                    regularSet.Add(input);
                }
            }

            while ((input = Console.ReadLine()) != "END")
            {
                if (char.IsDigit(input[0]))
                {
                    vipSet.Remove(input);
                }
                else
                {
                    regularSet.Remove(input);
                }
            }

            Console.WriteLine(vipSet.Count+regularSet.Count);

            if (vipSet.Count>0)
            {
                foreach (var item in vipSet)
                {
                    Console.WriteLine(item);
                }
            }
            if (regularSet.Count>0)
            {
                foreach (var item in regularSet)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
