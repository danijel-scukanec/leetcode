using System;
using System.Collections.Generic;

namespace Leetcode._3_LongestSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            var result1 = LengthOfLongestSubstring("abcabcbb");
            var result2 = LengthOfLongestSubstring(" ");
            var result3 = LengthOfLongestSubstring("tmmzuxt");
        }

        public static int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0)
            {
                return 0;
            }

            var lowerIndex = 0;
            var dictionary = new Dictionary<char, int>();
            var maxLength = 0;

            for (var i = 0; i < s.Length; i++)
            {
                if (!dictionary.ContainsKey(s[i]) || dictionary.ContainsKey(s[i]) && dictionary[s[i]] < lowerIndex)
                {
                    if (dictionary.ContainsKey(s[i]))
                    {
                        dictionary[s[i]] = i;
                    }
                    else
                    {
                        dictionary.Add(s[i], i);
                    }

                    var currentLength = i - lowerIndex + 1;
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }

                    continue;
                }

                var repeatedIndex = dictionary[s[i]];
                lowerIndex = repeatedIndex + 1;

                dictionary[s[i]] = i;
            }

            return maxLength;
        }
    }
}
