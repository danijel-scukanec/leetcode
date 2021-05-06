using System;

namespace Leetcode._9_PalindromeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPalindrome(121));
            Console.WriteLine(IsPalindrome(-121));
            Console.WriteLine(IsPalindrome(10));
            Console.WriteLine(IsPalindrome(-101));
        }

        public static bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }

            if (x / 10 == 0)
            {
                return true;
            }

            var xString = x.ToString();
            var startIndex = 0;
            var endIndex = xString.Length - 1;

            while (startIndex < endIndex)
            {
                if (xString[startIndex] != xString[endIndex])
                {
                    return false;
                }

                startIndex++;
                endIndex--;
            }

            return true;
        }
    }
}
