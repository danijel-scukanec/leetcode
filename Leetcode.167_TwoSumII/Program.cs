using System;
using System.Collections.Generic;

namespace Leetcode._167_TwoSumII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(' ', TwoSum_2(new[] { 2, 7, 11, 15 }, 9)));
        }

        public static int[] TwoSum_1(int[] numbers, int target)
        {
            var dictionary = new Dictionary<int, int>();
            for (var i = 0; i < numbers.Length; i++)
            {
                var numberToFind = target - numbers[i];
                if (dictionary.ContainsKey(numberToFind))
                {
                    return new int[] { dictionary[numberToFind] + 1, i + 1 };
                }

                if (!dictionary.ContainsKey(numbers[i]))
                {
                    dictionary.Add(numbers[i], i);
                }
            }

            throw new Exception("Not found");
        }

        public static int[] TwoSum_2(int[] numbers, int target)
        {
            var leftPointer = 0;
            var rightPointer = numbers.Length - 1;

            while (leftPointer < rightPointer)
            {
                var currentResult = numbers[leftPointer] + numbers[rightPointer];
                if (currentResult == target)
                {
                    return new[] { leftPointer + 1, rightPointer + 1 };
                }
                else if (currentResult < target)
                {
                    leftPointer++;
                }
                else
                {
                    rightPointer--;
                }
            }

            throw new Exception("Not found");
        }
    }
}
