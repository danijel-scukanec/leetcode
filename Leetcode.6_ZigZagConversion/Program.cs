using System;
using System.Collections.Generic;

namespace Leetcode._6_ZigZagConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Convert_2("PAYPALISHIRING", 3));
            Console.WriteLine(Convert_2("PAYPALISHIRING", 4));
            Console.WriteLine(Convert_2("A", 1));
            Console.WriteLine(Convert_2("AB", 1));
            Console.WriteLine(Convert_2("AB", 3));
        }

        public static string Convert_1(string s, int numRows)
        {
            if (s.Length == 1 || numRows == 1)
            {
                return s;
            }

            var convertedString = "";

            for (var rowIndex = 0; rowIndex < numRows; rowIndex++)
            {
                var numOfCharsToSkipDown = (numRows - 1 - rowIndex) * 2;
                var numOfCharsToSkipUp = (rowIndex - 0) * 2;

                var charIndex = rowIndex;

                var zigzag = 0;
                while (charIndex < s.Length)
                {
                    convertedString += s[charIndex];

                    if (zigzag % 2 == 0 && numOfCharsToSkipDown > 0 || numOfCharsToSkipUp == 0)
                    {
                        charIndex += numOfCharsToSkipDown;
                    }
                    else if (zigzag % 2 != 0 && numOfCharsToSkipUp > 0 || numOfCharsToSkipDown == 0)
                    {
                        charIndex += numOfCharsToSkipUp;
                    }

                    zigzag++;
                }
            }

            return convertedString;
        }

        public static string Convert_2(string s, int numRows)
        {
            if (s.Length == 1 || numRows == 1)
            {
                return s;
            }

            var array = new List<char>[numRows];

            var listIndex = 0;
            var isDownsideTrend = true;

            for (var i = 0; i < s.Length; i++)
            {
                if(array[listIndex] == null)
                {
                    array[listIndex] = new List<char>();
                }

                array[listIndex].Add(s[i]);

                if (isDownsideTrend && listIndex < numRows - 1)
                {
                    listIndex++;
                }
                else if(!isDownsideTrend && listIndex == 0)
                {
                    listIndex++;
                    isDownsideTrend = true;
                }
                else
                {
                    isDownsideTrend = false;
                    listIndex--;
                }
            }

            var convertedString = "";

            foreach(var list in array)
            {
                convertedString += list != null ? new string(list.ToArray()) : "";
            }

            return convertedString;
        }
    }
}
