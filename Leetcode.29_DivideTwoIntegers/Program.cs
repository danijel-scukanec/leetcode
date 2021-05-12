using System;

namespace Leetcode._29_DivideTwoIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Divide_1(10, 3));
            Console.WriteLine(Divide_1(7, -3));
            Console.WriteLine(Divide_1(0, 1));
            Console.WriteLine(Divide_1(1, 1));
            Console.WriteLine(Divide_1(-6, -9));
            Console.WriteLine(Divide_1(-120, -20));
            Console.WriteLine(Divide_1(-2147483648, -1));
            Console.WriteLine(Divide_1(-2147483648, 4));
        }

        public static int Divide_1(int dividend, int divisor)
        {
            if (dividend == divisor)
            {
                return 1;
            }

            if (dividend == 0)
            {
                return 0;
            }

            if (divisor == 1)
            {
                return dividend;
            }

            if (dividend == -2147483648 && divisor == -1)
            {
                return 2147483647;
            }

            bool isResultNegative = dividend < 0 && divisor > 0 || dividend >= 0 && divisor < 0;

            if (dividend < 0)
            {
                dividend = -dividend;
            }

            if (divisor < 0)
            {
                divisor = -divisor;
            }

            var result = 0;
            for (var i = dividend - divisor; i >= 0; i -= divisor)
            {
                result++;
            }

            if (isResultNegative)
            {
                result *= -1;
            }

            return result;
        }

        private static int HALF_INT_MIN = -1073741824;

        public static int Divide_2(int dividend, int divisor)
        {
            // Special case: overflow.
            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }

            /* We need to convert both numbers to negatives.
             * Also, we count the number of negatives signs. */
            int negatives = 2;
            if (dividend > 0)
            {
                negatives--;
                dividend = -dividend;
            }
            if (divisor > 0)
            {
                negatives--;
                divisor = -divisor;
            }

            int quotient = 0;
            /* Once the divisor is bigger than the current dividend,
             * we can't fit any more copies of the divisor into it. */
            while (divisor >= dividend)
            {
                /* We know it'll fit at least once as divivend >= divisor.
                 * Note: We use a negative powerOfTwo as it's possible we might have
                 * the case divide(INT_MIN, -1). */
                int powerOfTwo = -1;
                int value = divisor;
                /* Check if double the current value is too big. If not, continue doubling.
                 * If it is too big, stop doubling and continue with the next step */
                while (value >= HALF_INT_MIN && value + value >= dividend)
                {
                    value += value;
                    powerOfTwo += powerOfTwo;
                }
                // We have been able to subtract divisor another powerOfTwo times.
                quotient += powerOfTwo;
                // Remove value so far so that we can continue the process with remainder.
                dividend -= value;
            }

            /* If there was originally one negative sign, then
             * the quotient remains negative. Otherwise, switch
             * it to positive. */
            if (negatives != 1)
            {
                return -quotient;
            }
            return quotient;
        }
    }
}
