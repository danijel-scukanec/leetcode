using System;
using System.Text;

namespace Leetcode._12_IntegerToRoman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IntToRoman_2(3));
            Console.WriteLine(IntToRoman_2(4));
            Console.WriteLine(IntToRoman_2(9));
            Console.WriteLine(IntToRoman_2(58));
            Console.WriteLine(IntToRoman_2(1994));
            Console.WriteLine(IntToRoman_2(60));
        }

        public static string IntToRoman_1(int num)
        {
            var romanNum = "";

            var thousands = num / 1000;
            if (thousands > 0)
            {
                for (var i = 0; i < thousands; i++)
                {
                    romanNum += "M";
                }
                num %= 1000;
            }

            var hundreds = num / 100;
            if (hundreds > 0)
            {
                if (hundreds == 9)
                {
                    romanNum += "CM";
                }
                else if (hundreds >= 5)
                {
                    romanNum += "D";
                    for (var i = 0; i < hundreds - 5; i++)
                    {
                        romanNum += "C";
                    }
                }
                else if (hundreds == 4)
                {
                    romanNum += "CD";
                }
                else
                {
                    for (var i = 0; i < hundreds; i++)
                    {
                        romanNum += "C";
                    }
                }

                num %= 100;
            }

            var tens = num / 10;
            if (tens > 0)
            {
                if (tens == 9)
                {
                    romanNum += "XC";
                }
                else if (tens >= 5)
                {
                    romanNum += "L";
                    for (var i = 0; i < tens - 5; i++)
                    {
                        romanNum += "X";
                    }
                }
                else if (tens == 4)
                {
                    romanNum += "XL";
                }
                else
                {
                    for (var i = 0; i < tens; i++)
                    {
                        romanNum += "X";
                    }
                }

                num %= 10;
            }

            if (num == 9)
            {
                romanNum += "IX";
            }
            else if (num >= 5)
            {
                romanNum += "V";
                for (var i = 0; i < num - 5; i++)
                {
                    romanNum += "I";
                }
            }
            else if (num == 4)
            {
                romanNum += "IV";
            }
            else
            {
                for (var i = 0; i < num; i++)
                {
                    romanNum += "I";
                }
            }

            return romanNum;
        }

        private static int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private static string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        public static string IntToRoman_2(int num)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < values.Length && num > 0; i++)
            {
                while (values[i] <= num)
                {
                    num -= values[i];
                    sb.Append(symbols[i]);
                }
            }
            return sb.ToString();
        }
    }
}
