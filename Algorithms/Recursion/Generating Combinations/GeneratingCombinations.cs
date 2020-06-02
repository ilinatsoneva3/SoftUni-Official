namespace Generating_Combinations
{
    using System;
    using System.Linq;

    class GeneratingCombinations
    {
        static void Main(string[] args)
        {
           var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var number = int.Parse(Console.ReadLine());
            var output = new int[number];

            GenerateCombinations(input, output, 0, 0);
        }

        private static void GenerateCombinations(int[] input, int[] output, int index, int border)
        {
            if (index == output.Length)
            {
                Console.WriteLine(string.Join(" ", output));
            }
            else
            {
                for (int i = border; i < input.Length; i++)
                {
                    output[index] = input[i];
                    GenerateCombinations(input, output, index + 1, i + 1);
                }
            }
        }
    }
}
