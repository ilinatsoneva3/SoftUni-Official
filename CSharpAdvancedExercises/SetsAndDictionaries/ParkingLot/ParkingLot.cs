using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<string>();

            string input = string.Empty;

            while ((input=Console.ReadLine())!="END")
            {
                var currentInput = input.Split(", ");
                if (currentInput[0]=="IN")
                {
                    set.Add(currentInput[1]);
                }
                else
                {
                    set.Remove(currentInput[1]);
                }
            }

            if (set.Count!=0)
            {
                foreach (var item in set)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
