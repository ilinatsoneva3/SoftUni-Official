using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var setsCount = Console.ReadLine().Split().Select(int.Parse).ToList();
            var setOne = new HashSet<int>();
            var setTwo = new HashSet<int>();

            for (int i = 0; i < setsCount[0]; i++)
            {
                setOne.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < setsCount[1]; i++)
            {
                setTwo.Add(int.Parse(Console.ReadLine()));
            }

            var finalQueue = new Queue<int>();

            foreach (var item in setOne)
            {
                if (setTwo.Contains(item))
                {
                    finalQueue.Enqueue(item);
                }
            }

            Console.WriteLine(string.Join(' ', finalQueue));
        }
    }
}
