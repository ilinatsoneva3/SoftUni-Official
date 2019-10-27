namespace GenericBoxOfString
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var currentInput = new Box<string>(Console.ReadLine());
                Console.WriteLine(currentInput);
            }
        }
    }
}
