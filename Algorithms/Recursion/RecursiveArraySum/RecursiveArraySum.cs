namespace RecursiveArraySum
{
    using System;
    using System.Linq;

    class RecursiveArraySum
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var result = Sum(input, 0);
            Console.WriteLine(result);
        }

        //variable result in the below method starts accumulating the sum after the index reaches the array length
        //and the stack starts emptying backwards. the last number from the array will be added first, then the last but one, etc.

        public static int Sum(int[] input, int index)
        {
            

            if (index == input.Length)
            {
                return 0;
            }

            var result = input[index] + Sum(input, index + 1);

            return result;
        }
    }
}
