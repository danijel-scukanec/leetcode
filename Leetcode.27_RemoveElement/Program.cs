using System;

namespace Leetcode._27_RemoveElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var result1 = RemoveElement(new int[] { 3, 2, 2, 3 }, 3);
        }

        public static int RemoveElement(int[] nums, int val)
        {
            var i = 0;
            for (var j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }

            return i;
        }
    }
}
