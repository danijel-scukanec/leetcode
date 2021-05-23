using System;

namespace Leetcode._31_NextPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            NextPermutation(new[] { 4, 2, 0, 2, 3, 2, 0 });
            NextPermutation(new[] { 1, 2, 3 });
            NextPermutation(new[] { 3, 2, 1 });
            NextPermutation(new[] { 1, 1, 5 });
            NextPermutation(new[] { 1, 3, 2 });
            NextPermutation(new[] { 1 });
        }

        public static void NextPermutation(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return;
            }

            var leftPointer = nums.Length - 2;
            var rightPointer = nums.Length - 1;

            while(leftPointer < rightPointer)
            {
                if(nums[leftPointer] < nums[rightPointer])
                {
                    var tmp = nums[leftPointer];
                    nums[leftPointer] = nums[rightPointer];
                    nums[rightPointer] = tmp;
                }
                else
                {
                    leftPointer--;
                    rightPointer--;
                }
            }
        }
    }
}
