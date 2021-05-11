using System;

namespace Leetcode._26_RemoveDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var result1 = RemoveDuplicates_1(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 });
            var result2 = RemoveDuplicates_1(new int[] { 1, 1 });
            var result3 = RemoveDuplicates_1(new int[] { 1, 1, 2, 3 });
        }

        public static int RemoveDuplicates_1(int[] nums)
        {
            if (nums.Length < 2)
            {
                return nums.Length;
            }

            int newLength = 1;

            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    while (nums[i] == nums[i - 1])
                    {
                        i++;
                        if (i == nums.Length)
                        {
                            return newLength;
                        }
                    }
                }

                nums[newLength] = nums[i];
                newLength++;
            }

            return newLength;
        }

        public static int RemoveDuplicates_2(int[] nums)
        {
            if (nums.Length < 2)
            {
                return nums.Length;
            }

            var i = 0;
            for (var j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }

            return i + 1;
        }

    }
}
