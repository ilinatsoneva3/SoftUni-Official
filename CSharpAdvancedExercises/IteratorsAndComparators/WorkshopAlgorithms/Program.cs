namespace Workshop24102019
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    class Workshop
    {
        static void Main()
        {
            #region recursion sum array
            //int[] array = { 1, 2, 3, 4,5 };
            //int index = 0;
            //int result = SumArray(array, index);
            //Console.WriteLine(result); 
            #endregion recursion sum 

            #region recursion factorial
            //int number = 5;
            //int result = Factorial(number);
            //Console.WriteLine(result);
            #endregion recursion

            #region greedy
            //int[] coins = { 1, 1, 1, 2, 2, 5, 5, 5, 10, 10 };
            //int targetSum = 18;
            //int currentSum = 0;
            //Array.Sort(coins);
            //Array.Reverse(coins);
            //int counter = 0;

            //while (currentSum<targetSum)
            //{
            //    if (counter==coins.Length)
            //    {
            //        break;
            //    }
            //    if (coins[counter]+currentSum<=targetSum)
            //    {
            //        currentSum += coins[counter];
            //    }
            //    counter++;
            //}

            //if (currentSum==targetSum)
            //{
            //    Console.WriteLine(true);
            //}
            //else
            //{
            //    Console.WriteLine(false);
            //}
            #endregion

            #region sorting selection, bubble sort
            //int[] array = { 3, 4, 2, 1, 100, 5, 9, 7, -50 };
            //SelectionSort(array);
            //BubbleSort(array);
            //Console.WriteLine(string.Join(" ", array));
            #endregion

            #region search binary

            //var list = new List<int>();

            //for (int i = 1; i <= 1000; i++)
            //{
            //    list.Add(i);
            //}

            //var sw = Stopwatch.StartNew();

            //int result = 0;

            //try
            //{
            //    result = BinarySearch(list, list.Count, 394);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //Console.WriteLine(result);

            //Console.WriteLine(sw.Elapsed);

            #endregion

            int a = 5;
            IncrementNumber(ref a);
            Console.WriteLine(a);
            int b = 3;
            int result = 0;
            SumNumbers(ref result, ref a, ref b);
            Console.WriteLine(a);
            Console.WriteLine(result);
        }

        private static void SumNumbers(ref int result, ref int a, ref int b)
        {
            a += 10;
            b += 3;
            result = a + b;
        }

        private static int IncrementNumber(ref int a)
        {
            a += 5;
            return a;
        }

        private static int BinarySearch(List<int> array, int length, int value)
        {
            int middle = length / 2;

            while (array[middle] != value)
            {
                if (middle == 0 || middle == length - 1)
                {
                    throw new InvalidOperationException("No such value");
                }

                if (array[middle] > value)
                {
                    middle /= 2;
                }
                else
                {
                    middle += (length / 2 - middle) / 2;
                }
            }

            return middle;
        }

        private static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        private static void SelectionSort(int[] array)
        {
            int minIndex = 0;

            for (int index = 0; index < array.Length; index++)
            {
                minIndex = index;

                for (int currentIndex = index + 1; currentIndex < array.Length; currentIndex++)
                {
                    if (array[minIndex] > array[currentIndex])
                    {
                        minIndex = currentIndex;
                    }
                }

                int temp = array[index];
                array[index] = array[minIndex];
                array[minIndex] = temp;
            }
        }

        private static int Factorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }

        private static int SumArray(int[] array, int index)
        {
            //define end case first
            if (index == array.Length)
            {
                return 0;
            }

            return array[index] + SumArray(array, index + 1);
            //operations coming back from stack return the result after returning 0

            /*
             * if (index<array.Length)
             * {
             * return array[index] + SumArray(array, index+1);
             * }
             * return 0;
             */
        }
    }
}
