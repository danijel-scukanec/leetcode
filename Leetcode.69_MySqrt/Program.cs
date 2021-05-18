using System;

namespace Leetcode._69_MySqrt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MySqrt_2(8));
        }

        public int MySqrt_1(int x)
        {
            double result = Math.Sqrt(x);
            return (int)Math.Floor(result);
        }

        public static int MySqrt_2(int x)
        {
            if (x < 2)
            {
                return x;
            }

            int leftBoundary = 2;
            int rightBoundary = x / 2;

            while (leftBoundary <= rightBoundary)
            {
                int middlePointer = leftBoundary + (rightBoundary - leftBoundary) / 2;

                long number = (long)middlePointer * (long)middlePointer;
                if (x < number)
                {
                    rightBoundary = middlePointer - 1;
                }
                else if (x > number)
                {
                    leftBoundary = middlePointer + 1;
                }
                else
                {
                    return middlePointer;
                }
            }

            return rightBoundary;
        }
    }
}
