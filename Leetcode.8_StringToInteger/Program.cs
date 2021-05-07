using System;
using System.Linq;

namespace Leetcode._8_StringToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MyAtoi("42"));
            Console.WriteLine(MyAtoi("   -42"));
            Console.WriteLine(MyAtoi("4193 with words"));
            Console.WriteLine(MyAtoi("words and 987"));
            Console.WriteLine(MyAtoi("-91283472332"));
            Console.WriteLine(MyAtoi("-9223372036854775809"));
        }

        public static int MyAtoi(string s)
        {
            //whitespace trimming
            s = s.TrimStart();

            if (s.Length == 0)
            {
                return 0;
            }

            var processedString = "";
            var digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            bool isPositive = true;

            //check sign
            var currentCharIndex = 0;
            if (s[currentCharIndex] == '+' || s[currentCharIndex] == '-')
            {
                int temp = 0;
                if (s.Length == 1 || !int.TryParse(s[currentCharIndex + 1].ToString(), out temp))
                {
                    return 0;
                }

                isPositive = s[currentCharIndex] == '+';
                currentCharIndex++;
            }

            for (var i = currentCharIndex; i < s.Length; i++)
            {
                //check leading zeroes
                if (processedString.Length == 0 && s[i] == '0')
                {
                    continue;
                }

                if (!digits.Contains(s[i]))
                {
                    break;
                }

                processedString += s[i];
            }

            if (processedString.Length == 0)
            {
                return 0;
            }

            int result = 0;
            var isSuccess = int.TryParse(processedString, out result);
            if (isSuccess && !isPositive)
            {
                result *= -1;
            }
            else if (!isSuccess)
            {
                result = isPositive ? int.MaxValue : int.MinValue;
            }           

            return result;
        }
    }
}
