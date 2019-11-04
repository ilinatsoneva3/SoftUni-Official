using System;
using System.Text;

namespace RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Rhombus figure = new Rhombus();
            Console.WriteLine(figure.DrawRhombus(number));
        }
    }
}
