namespace ClubParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class StartUp
    {
        static void Main(string[] args)
        {
            var capacity = int.Parse(Console.ReadLine());
            var input = new Stack<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            var nextHalls = new LinkedList<string>();

            while (input.Any())
            {
                var currentHallCapacity = capacity;
                var numToPrint = new List<int>();

                while (currentHallCapacity > 0 && input.Any())
                {
                    var currentItem = input.Pop();
                    var reservation = 0;
                    var isInt = false;

                    if (int.TryParse(currentItem, out int result))
                    {
                        reservation = int.Parse(currentItem);
                        isInt = true;
                    }
                    else
                    {
                        nextHalls.AddLast(currentItem);
                    }

                    if (nextHalls.Any() && isInt)
                    {
                        currentHallCapacity -= reservation;

                        if (currentHallCapacity >= 0)
                        {
                            numToPrint.Add(reservation);
                        }
                        else
                        {
                            input.Push(currentItem);
                        }
                    }
                }

                if (currentHallCapacity <= 0)
                {
                    Console.WriteLine($"{nextHalls.First()} -> {string.Join(", ", numToPrint)}");
                    nextHalls.RemoveFirst();
                }
            }
        }
    }
}
