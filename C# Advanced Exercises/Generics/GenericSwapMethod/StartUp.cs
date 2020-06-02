namespace GenericSwapMethod
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                var line = double.Parse(Console.ReadLine());
                box.List.Add(line);
            }

            var comparer = double.Parse(Console.ReadLine());

            var result = box.FindCountOfGreaterItems(comparer);
            Console.WriteLine(result);
        }
    }
}
