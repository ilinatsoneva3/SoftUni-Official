namespace RecursiveDrawing
{
    using System;

    class RecursiveDrawing
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(new string('*', number));
            PrintFigure(number-1);
            Console.WriteLine(new string('#', number));
            
        }

       
        private static void PrintFigure(int number)
        {
            if (number==0)
            {
                return;
            }

            Console.WriteLine(new string('*', number));

            PrintFigure(number - 1);

            Console.WriteLine(new string('#', number));
        }
    }
}
