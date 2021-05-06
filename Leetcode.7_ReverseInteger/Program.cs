using System;

namespace Leetcode._7_ReverseInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Reverse(123));
            Console.WriteLine(Reverse(-123));
            Console.WriteLine(Reverse(120));
            Console.WriteLine(Reverse(4));
        }

        public static int Reverse(int x)
        {
            var xString = x.ToString();
            var xStringReversed = "";

            for (var i = xString.Length - 1; i >= 0; i--)
            {
                if (i == 0 && xString[i] == '-')
                {
                    break;
                }

                xStringReversed += xString[i];
            }

            int xReversed = 0;

            var isInteger = int.TryParse(xStringReversed, out xReversed);
            if (isInteger && xString[0] == '-')
            {
                xReversed *= -1;
            }

            return xReversed;
        }
    }
}
