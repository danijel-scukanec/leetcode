using System;

namespace Leetcode._415_AddStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AddStrings("11", "123"));
        }

        public static string AddStrings(string num1, string num2)
        {           
            string result = "";

            var num1Pointer = num1.Length - 1;
            var num2Pointer = num2.Length - 1;

            int remainder = 0;            
            while(num1Pointer >= 0 || num2Pointer >= 0)
            {
                int currentDigit1 = 0;
                int currentDigit2 = 0;

                if(num1Pointer >= 0)
                {
                    currentDigit1 = int.Parse(num1[num1Pointer].ToString());
                }

                if (num2Pointer >= 0)
                {
                    currentDigit2 = int.Parse(num2[num2Pointer].ToString());
                }

                var digitSum = currentDigit1 + currentDigit2 + remainder;
                result = result.Insert(0, (digitSum % 10).ToString());
                remainder = digitSum / 10;

                num1Pointer--;
                num2Pointer--; 
            }

            if(remainder > 0)
            {
                result = result.Insert(0, remainder.ToString());
            }

            return result;
        }
    }
}
