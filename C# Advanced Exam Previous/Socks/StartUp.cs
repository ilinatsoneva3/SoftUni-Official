namespace Socks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            var leftSocks = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var rightSocks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var pairs = new Queue<int>();

            while (leftSocks.Any() && rightSocks.Any())
            {
                var leftSock = leftSocks.Peek();
                var rightSock = rightSocks.Peek();

                if (leftSock == rightSock)
                {
                    rightSocks.Dequeue();
                    leftSock = leftSocks.Pop();
                    leftSock++;
                    leftSocks.Push(leftSock);
                }
                else if (leftSock > rightSock)
                {
                    var sum = leftSock + rightSock;
                    pairs.Enqueue(sum);
                    leftSocks.Pop();
                    rightSocks.Dequeue();
                }
                else if (leftSock < rightSock)
                {
                    leftSocks.Pop();
                }
            }

            Console.WriteLine(pairs.Max());
            Console.WriteLine(string.Join(' ', pairs));
        }
    }
}
