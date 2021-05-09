using System;
using System.Collections.Generic;

namespace Leetcode._15_3Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreeSum(new int[] { });
            ThreeSum(new[] { 0 });
            ThreeSum(new[] { -1, 0, 1, 2, -1, -4 });
            ThreeSum(new[] { 0, 0, 0, 0 });
            ThreeSum(new[] { 0, 0, 0 });
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var triplets = new List<IList<int>>();
            Array.Sort(nums);

            for (var i = 0; i < nums.Length && nums[i] <= 0; i++)
            {
                if (i == 0 || nums[i - 1] != nums[i])
                {
                    var currentTriplets = TwoSum(nums, i);
                    triplets.AddRange(currentTriplets);
                }
            }

            return triplets;
        }

        public static List<int[]> TwoSum(int[] nums, int i)
        {
            var result = new List<int[]>();
            var seen = new HashSet<int>(); 

            for (var j = i + 1; j < nums.Length; j++)
            {
                int complement = -nums[i] - nums[j];
                if (seen.Contains(complement))
                {
                    result.Add(new[] { nums[i], nums[j], complement });
                    while (j + 1 < nums.Length && nums[j] == nums[j + 1])
                    {
                        j++;
                    }
                }

                seen.Add(nums[j]);
            }

            return result;
        }

        public static List<int[]> TwoSumII(int[] nums, int i)
        {
            var list = new List<int[]>();

            var leftPointer = i + 1;
            var rightPointer = nums.Length - 1;

            while (leftPointer < rightPointer)
            {
                int sum = nums[i] + nums[leftPointer] + nums[rightPointer];
                if (sum < 0)
                {
                    leftPointer++;
                }
                else if (sum > 0)
                {
                    rightPointer--;
                }
                else
                {
                    list.Add(new[] { nums[i], nums[leftPointer], nums[rightPointer] });
                    leftPointer++;
                    rightPointer--;

                    while (leftPointer < rightPointer && nums[leftPointer] == nums[leftPointer - 1])
                    {
                        leftPointer++;
                    }
                }
            }

            return list;
        }
    }
}
