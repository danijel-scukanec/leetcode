using System;
using System.Collections.Generic;

namespace Leetcode._953_Alien
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsAlienSorted(new[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz"));
            Console.WriteLine(IsAlienSorted(new[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz"));
        }

        public static bool IsAlienSorted(string[] words, string order)
        {
            if (words.Length == 1)
            {
                return true;
            }

            var dictionary = new Dictionary<char, int>();
            for (var i = 0; i < order.Length; i++)
            {
                dictionary.Add(order[i], i);
            }

            for (int i = 0; i < words.Length - 1; i++)
            {

                for (int j = 0; j < words[i].Length; j++)
                {
                    // If we do not find a mismatch letter between words[i] and words[i + 1],
                    // we need to examine the case when words are like ("apple", "app").
                    if (j >= words[i + 1].Length) return false;

                    if (words[i][j] != words[i + 1][j])
                    {
                        char currentWordChar = words[i][j];
                        char nextWordChar = words[i + 1][j];
                        if (dictionary[currentWordChar] > dictionary[nextWordChar]) return false;
                        // if we find the first different letter and they are sorted,
                        // then there's no need to check remaining letters
                        else break;
                    }
                }
            }


            return true;
        }
    }
}
