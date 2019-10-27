using System;
using System.Diagnostics;
using System.Linq;

namespace WorkshopCustomDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new CustomList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            Debug.Assert(list[2] == 2); // checks if codes works correctly (unit testing)

            list.RemoveAt(2);
            Debug.Assert(list[2] == 3);
            Debug.Assert(list.Count == 9);

            list.Reverse();
            Debug.Assert(list[0] == 9);
            Debug.Assert(list.Count == 9);

            Console.WriteLine(list.ToString());

            var stack = new CustomStack<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            Debug.Assert(stack.Count == 10);
            
            Console.WriteLine(string.Join(", ",stack.Where(x => x % 2 == 0))); 
        }
    }
}
