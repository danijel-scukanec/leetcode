using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode._17_LetterCombinationsPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(',', LetterCombinations_2("23")));
            Console.WriteLine(string.Join(',', LetterCombinations_2("")));
            Console.WriteLine(string.Join(',', LetterCombinations_2("2")));
            Console.WriteLine(string.Join(',', LetterCombinations_2("237")));
        }

        public static IList<string> LetterCombinations_1(string digits)
        {
            var combinations = new List<string>();
            var dictionary = GetLettersDictionary();

            if (digits.Length == 0)
            {
                return combinations;
            }

            combinations = dictionary[(digits[0])].ToList();
            for (var digitIndex = 1; digitIndex < digits.Length; digitIndex++)
            {
                var letters = dictionary[digits[digitIndex]];
                var newCombinations = new List<string>();

                for (var combinationIndex = 0; combinationIndex < combinations.Count; combinationIndex++)
                {
                    for (var letterIndex = 0; letterIndex < letters.Length; letterIndex++)
                    {
                        newCombinations.Add(combinations.ElementAt(combinationIndex) + letters[letterIndex]);
                    }
                }

                combinations = newCombinations;
            }

            return combinations;
        }

        private static string _phoneDigits;
        private static List<string> _combinations;
        private static Dictionary<char, string[]> _letters = GetLettersDictionary();

        public static IList<string> LetterCombinations_2(string digits)
        {
            _combinations = new List<string>();

            if (digits.Length == 0)
            {
                return _combinations;
            }

            _phoneDigits = digits;
            Backtrack(0, new StringBuilder());
            return _combinations;
        }

        private static void Backtrack(int index, StringBuilder path)
        {
            // If the path is the same length as digits, we have a complete combination
            if (path.Length == _phoneDigits.Length)
            {
                _combinations.Add(path.ToString());
                return; // Backtrack
            }

            // Get the letters that the current digit maps to, and loop through them
            var possibleLetters = _letters[_phoneDigits[index]];
            foreach (var letter in possibleLetters)
            {
                // Add the letter to our current path
                path.Append(letter);
                // Move on to the next digit
                Backtrack(index + 1, path);
                // Backtrack by removing the letter before moving onto the next
                path.Remove(path.Length - 1, 1);
            }
        }

        private static Dictionary<char, string[]> GetLettersDictionary()
        {
            var dictionary = new Dictionary<char, string[]>();

            dictionary.Add('2', new[] { "a", "b", "c" });
            dictionary.Add('3', new[] { "d", "e", "f" });
            dictionary.Add('4', new[] { "g", "h", "i" });
            dictionary.Add('5', new[] { "j", "k", "l" });
            dictionary.Add('6', new[] { "m", "n", "o" });
            dictionary.Add('7', new[] { "p", "q", "r", "s" });
            dictionary.Add('8', new[] { "t", "u", "v" });
            dictionary.Add('9', new[] { "w", "x", "y", "z" });

            return dictionary;
        }
    }
}
