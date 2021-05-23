using System;

namespace Leetcode._121_BestTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxProfit(new[] { 1, 2, 11, 4, 7 }));
            Console.WriteLine(MaxProfit(new[] { 2, 1, 4 }));
            Console.WriteLine(MaxProfit(new[] { 7, 1, 5, 3, 6, 4 }));
            Console.WriteLine(MaxProfit(new[] { 7, 6, 4, 3, 1 }));
            Console.WriteLine(MaxProfit(new[] { 2, 2, 2, 2, 2 }));
            Console.WriteLine(MaxProfit(new[] { 1, 2, 1, 2, 1 }));
            Console.WriteLine(MaxProfit(new[] { 1, 2, 3, 4, 5, 6, 5, 4, 3, 2, 1 }));
        }

        public static int MaxProfit(int[] prices)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;

            for(var i = 0; i < prices.Length; i++)
            {
                if(prices[i] < minPrice)
                {
                    minPrice = prices[i];
                }
                else if(prices[i] - minPrice > maxProfit)
                {
                    maxProfit = prices[i] - minPrice;
                }
            }

            return maxProfit;
        }
    }
}
