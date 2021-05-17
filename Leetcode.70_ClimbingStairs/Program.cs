using System;

namespace Leetcode._70_ClimbingStairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ClimbStairs(1));
            Console.WriteLine(ClimbStairs(3));
        }

        public static int ClimbStairs(int n)
        {
            int[] memo = new int[n + 1];
            return ClimbStairsRecursive(0, n, memo);
        }

        public static int ClimbStairsRecursive(int i, int n, int[] memo)
        {
            if (i > n)
            {
                return 0;
            }
            if (i == n)
            {
                return 1;
            }
            if (memo[i] > 0)
            {
                return memo[i];
            }
            memo[i] = ClimbStairsRecursive(i + 1, n, memo) + ClimbStairsRecursive(i + 2, n, memo);
            return memo[i];
        }
    }
}
