namespace P03_SalesDatabase.Data.IOManagement
{
    using P03_SalesDatabase.Data.IOManagement.Contracts;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
