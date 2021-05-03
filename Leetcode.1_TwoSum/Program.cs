using System;
using System.Collections.Generic;

namespace Leetcode._1_TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int[] TwoSum_1(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new[] { i, j };
                    }
                }
            }

            throw new Exception("Not found");
        }

        public static int[] TwoSum_2(int[] nums, int target)
        {
            var dictionary = new Dictionary<int, int>();
            for(var i = 0; i < nums.Length; i++)
            {
                if(dictionary.ContainsKey(target - nums[i]))
                {
                    return new[] { dictionary[target - nums[i]], i };
                }

                dictionary.Add(nums[i], i);
            }

            throw new Exception("Not found");
        }
    }
}
