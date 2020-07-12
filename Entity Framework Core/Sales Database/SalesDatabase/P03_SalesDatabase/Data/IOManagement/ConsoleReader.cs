namespace P03_SalesDatabase.Data.IOManagement
{
    using P03_SalesDatabase.Data.IOManagement.Contracts;
    using System;

    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
