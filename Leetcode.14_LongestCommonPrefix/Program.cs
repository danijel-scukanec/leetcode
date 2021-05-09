using System;

namespace Leetcode._14_LongestCommonPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestCommonPrefix_2(new[] { "flower", "flow", "flight" }));
            Console.WriteLine(LongestCommonPrefix_2(new[] { "dog", "racecar", "car" }));
            Console.WriteLine(LongestCommonPrefix_2(new[] { "ac", "ac", "a", "a" }));
        }

        public static string LongestCommonPrefix_1(string[] strs)
        {
            if (strs.Length == 1)
            {
                return strs[0];
            }

            var longestPrefix = "";

            if(strs[0].Length == 0 || strs[0].Length == 0)
            {
                return "";
            }

            var charIndex = 0;
            while (charIndex < Math.Min(strs[0].Length, strs[1].Length))
            {
                if (strs[0][charIndex] != strs[1][charIndex])
                {
                    break;
                }

                longestPrefix += strs[0][charIndex];
                charIndex++;
            }

            if (longestPrefix.Length == 0 || strs.Length == 2)
            {
                return longestPrefix;
            }

            for (var i = 2; i < strs.Length; i++)
            {
                if(strs[i].Length < longestPrefix.Length)
                {
                    longestPrefix = longestPrefix.Substring(0, strs[i].Length);
                }

                charIndex = 0;
                while (charIndex < longestPrefix.Length)
                {
                    if (longestPrefix[charIndex] != strs[i][charIndex])
                    {
                        longestPrefix = longestPrefix.Remove(charIndex);
                        if (longestPrefix.Length == 0)
                        {
                            return longestPrefix;
                        }

                        break;
                    }

                    charIndex++;
                }
            }

            return longestPrefix;
        }

        public static string LongestCommonPrefix_2(string[] strs)
        {
            if (strs.Length == 0) return "";
            var prefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
                while (strs[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                    if (prefix == "") return "";
                }
            return prefix;
        }

    }
}
