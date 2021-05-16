using System;

namespace Leetcode._35_SearchInsertPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SearchInsert_2(new int[] { 1, 3, 5, 6 }, 5));
            Console.WriteLine(SearchInsert_2(new int[] { 1, 3, 5, 6 }, 2));
            Console.WriteLine(SearchInsert_2(new int[] { 1, 3, 5, 6 }, 7));
            Console.WriteLine(SearchInsert_2(new int[] { 1, 3, 5, 6 }, 0));
            Console.WriteLine(SearchInsert_2(new int[] { 1 }, 0));
        }

        public static int SearchInsert_1(int[] nums, int target)
        {
            int leftPointer = 0;
            int rightPointer = nums.Length - 1;
            int middlePointer = -1;

            while (leftPointer <= rightPointer)
            {
                var currentLength = rightPointer - leftPointer + 1;
                middlePointer = leftPointer + (currentLength / 2);

                if (currentLength % 2 == 0)
                {
                    middlePointer -= 1;
                }

                if (nums[middlePointer] == target)
                {
                    return middlePointer;
                }
                else if (nums[middlePointer] < target)
                {
                    leftPointer = middlePointer + 1;
                }
                else
                {
                    rightPointer = middlePointer - 1;
                }
            }

            if (nums[middlePointer] < target)
            {
                middlePointer += 1;
            }

            return middlePointer;
        }

        public static int SearchInsert_2(int[] nums, int target)
        {
            int pivot, left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                pivot = left + (right - left) / 2;
                if (nums[pivot] == target) return pivot;
                if (target < nums[pivot]) right = pivot - 1;
                else left = pivot + 1;
            }
            return left;
        }
    }
}
