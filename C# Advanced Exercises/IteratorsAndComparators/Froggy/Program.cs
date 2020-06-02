namespace Froggy
{
    using System;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            var lake = new Lake(Console.ReadLine().Split(", ").Select(int.Parse).ToList());
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
