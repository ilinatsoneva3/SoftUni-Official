namespace Stack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var myStack = new MyStack<int>();

            var command = Console.ReadLine();

            while (command != "END")
            {
                var input = command.Split();
                var action = input[0];

                if (action == "Push")
                {
                    var data = command.Substring(5);
                    var numbers = data.Split(", ").Select(int.Parse).ToList();

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        myStack.Push(numbers[i]);
                    }
                }
                else if (action == "Pop")
                {
                    try
                    {
                        myStack.Pop();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var item in myStack)
                {
                    Console.WriteLine(item);
                }
            }

        }
    }
}
