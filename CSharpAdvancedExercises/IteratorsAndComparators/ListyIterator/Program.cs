namespace ListyIterator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            List<string> command = Console.ReadLine().Split().Skip(1).ToList();
            var myList = new ListyIterator<string>(command);

            string nextOperation = Console.ReadLine();

            while (nextOperation != "END")
            {
                switch (nextOperation)
                {
                    case "HasNext":
                        Console.WriteLine(myList.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            Console.WriteLine(myList.Print());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Move":
                        Console.WriteLine(myList.Move());
                        break;
                    case "PrintAll":

                        foreach (var item in myList)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                        break;
                }

                nextOperation = Console.ReadLine();
            }
        }
    }
}
