namespace _0_1_Vectors
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            var arr = new int[number];

            GenerateVectors(arr, 0);
        }

        private static void GenerateVectors(int[] arr, int index)
        {
            if (index==arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = 0; i <=1; i++)
                {
                    arr[index] = i;
                    GenerateVectors(arr, index + 1);
                }
            }
        }
    }
}
