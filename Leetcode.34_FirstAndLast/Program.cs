using System;

namespace Leetcode._34_FirstAndLast
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SearchRange(new int[] { 2, 2 }, 2));
            Console.WriteLine(SearchRange(new int[] { 1 }, 1));
            Console.WriteLine(SearchRange(new[] { 5, 7, 7, 8, 8, 10 }, 8));
            Console.WriteLine(SearchRange(new[] { 5, 7, 7, 8, 8, 10 }, 6));
            Console.WriteLine(SearchRange(new int[] { }, 0));
            Console.WriteLine(SearchRange(new int[] { }, 0));
        }

        public static int[] SearchRange(int[] nums, int target)
        {
            int leftPointer = 0;
            int rightPointer = nums.Length - 1;

            int leftIndex = -1;
            int rightIndex = -1;
            while (leftPointer <= rightPointer)
            {
                int middlePointer = leftPointer + (rightPointer - leftPointer) / 2;

                if (target < nums[middlePointer])
                {
                    rightPointer = middlePointer - 1;
                }
                else if (target > nums[middlePointer])
                {
                    leftPointer = middlePointer + 1;
                }
                else
                {
                    leftIndex = middlePointer;
                    rightIndex = middlePointer;

                    while (leftIndex - 1 >= 0 && nums[leftIndex - 1] == target)
                    {
                        leftIndex--;
                    }
                    while (rightIndex + 1 <= nums.Length - 1 && nums[rightIndex + 1] == target)
                    {
                        rightIndex++;
                    }
                    break;
                }
            }

            return new[] { leftIndex, rightIndex };
        }
    }
}
