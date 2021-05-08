using System;

namespace Leetcode._11_ContainerWithMostWater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxArea_2(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
        }

        public static int MaxArea_1(int[] height)
        {
            var maxArea = 0;
            for (var i = 0; i < height.Length; i++)
            {
                for (var j = 1; j < height.Length; j++)
                {
                    var currentArea = Math.Min(height[i], height[j]) * (j - i);
                    maxArea = Math.Max(maxArea, currentArea);
                }
            }

            return maxArea;
        }

        public static int MaxArea_2(int[] height)
        {
            var leftIndex = 0;
            var rightIndex = height.Length - 1;
            var maxArea = 0;

            while (leftIndex < rightIndex)
            {
                var area = Math.Min(height[leftIndex], height[rightIndex]) * (rightIndex - leftIndex);
                maxArea = Math.Max(maxArea, area);

                if (height[leftIndex] < height[rightIndex])
                {
                    leftIndex++;
                }
                else
                {
                    rightIndex--;
                }
            }

            return maxArea;
        }
    }
}
