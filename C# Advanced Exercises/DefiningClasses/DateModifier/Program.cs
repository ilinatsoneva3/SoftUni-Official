namespace DateModifier
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();
            var datesDifference = new DateModifier();
            Console.WriteLine(datesDifference.CalculateDate(firstDate, secondDate));
        }
    }
}
