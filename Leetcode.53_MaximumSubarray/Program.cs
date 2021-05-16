using System;

namespace Leetcode._53_MaximumSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxSubArray_2(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
        }

        public static int MaxSubArray_1(int[] nums)
        {
            var maxSum = int.MinValue;
            for (var i = 0; i < nums.Length; i++)
            {
                var sumSubarray = 0;
                for (var j = i; j < nums.Length; j++)
                {
                    sumSubarray += nums[j];
                    maxSum = Math.Max(maxSum, sumSubarray);
                }
            }

            return maxSum;
        }

        public static int MaxSubArray_2(int[] nums)
        {
            var currentSum = nums[0];
            var maxSum = nums[0];

            for (var i = 1; i < nums.Length; i++)
            {
                currentSum = Math.Max(nums[i], nums[i] + currentSum);
                maxSum = Math.Max(currentSum, maxSum);
            }

            return maxSum;
        }
    }
}
