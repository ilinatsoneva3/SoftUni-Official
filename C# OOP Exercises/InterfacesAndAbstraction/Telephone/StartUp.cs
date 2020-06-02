namespace Telephone
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var phone = new SmartPhone();
            var numbers = new List<string>(Console.ReadLine().Split());

            foreach (var number in numbers)
            {
                Console.WriteLine(phone.Call(number));
            }

            var URLs = new List<string>(Console.ReadLine().Split());

            foreach (var URL in URLs)
            {
                Console.WriteLine(phone.Browse(URL));
            }
        }
    }
}
