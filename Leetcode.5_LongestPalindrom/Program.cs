using System;
using System.Collections.Generic;

namespace Leetcode._5_LongestPalindrom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestPalindrome_3("babad"));
            Console.WriteLine(LongestPalindrome_3("cbbd"));
            Console.WriteLine(LongestPalindrome_3("a"));
            Console.WriteLine(LongestPalindrome_3("ac"));
            Console.WriteLine(LongestPalindrome_3("bb"));
            Console.WriteLine(LongestPalindrome_3("aabaa"));
        }

        public static string LongestPalindrome_1(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || s.Length == 1)
            {
                return s;
            }

            var longestPalindrome = "";

            for (var i = 0; i < s.Length; i++)
            {
                for (var j = i + 1; j <= s.Length; j++)
                {
                    var substring = s.Substring(i, j - i);
                    if (substring.Length > longestPalindrome.Length && IsPalindrome(substring))
                    {
                        longestPalindrome = substring;
                    }
                }
            }

            return longestPalindrome;
        }

        public static string LongestPalindrome_2(string s)
        {
            var dictionary = new Dictionary<string, bool>();

            if (string.IsNullOrWhiteSpace(s) || s.Length == 1)
            {
                return s;
            }

            var longestPalindrome = "";

            for (var i = 0; i < s.Length; i++)
            {
                for (var j = i + 1; j <= s.Length; j++)
                {
                    if (j - i <= longestPalindrome.Length)
                    {
                        continue;
                    }

                    var substring = s.Substring(i, j - i);
                    bool isPalindrome;
                    if (dictionary.ContainsKey(substring))
                    {
                        isPalindrome = dictionary[substring];
                    }
                    else
                    {
                        isPalindrome = IsPalindrome(substring);
                    }

                    if (isPalindrome)
                    {
                        longestPalindrome = substring;
                    }
                }
            }

            return longestPalindrome;
        }

        public static string LongestPalindrome_3(string s)
        {
            if (s == null || s.Length < 1) return "";

            var start = 0;
            var end = 0;

            for (var i = 0; i < s.Length; i++)
            {
                int len1 = ExpandFromMiddle(s, i, i);
                int len2 = ExpandFromMiddle(s, i, i + 1);
                int len = Math.Max(len1, len2);

                if (len > end - start)
                {
                    start = i - ((len - 1) / 2);
                    end = i + (len / 2);
                }
            }

            return s.Substring(start, end - start + 1);
        }

        private static int ExpandFromMiddle(string s, int left, int right)
        {
            if (s == null || left > right) return 0;

            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            return right - left - 1;
        }

        public static bool IsPalindrome(string s)
        {
            if (s.Length == 1)
            {
                return true;
            }

            var leftIndex = 0;
            var rightIndex = s.Length - 1;

            while (leftIndex < rightIndex)
            {
                if (s[leftIndex] != s[rightIndex])
                {
                    return false;
                }

                leftIndex++;
                rightIndex--;
            }

            return true;
        }
    }
}
