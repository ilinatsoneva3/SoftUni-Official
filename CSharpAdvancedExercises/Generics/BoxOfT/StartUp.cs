namespace BoxOfT
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            var list = new Box<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            Console.WriteLine(list.Remove());
            Console.WriteLine(list.Count);
        }
    }
}
