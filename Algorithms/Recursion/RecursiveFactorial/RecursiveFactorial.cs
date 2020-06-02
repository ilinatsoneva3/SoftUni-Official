namespace RecursiveFactoriel
{
    using System;
    class RecursiveFactorial
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            var result = CalculateFactorial(number);
            Console.WriteLine(result);
        }

        private static int CalculateFactorial(int number)
        {
            if (number == 1)
            {
                return 1;
            }

            return number * CalculateFactorial(number - 1);
        }
    }
}
