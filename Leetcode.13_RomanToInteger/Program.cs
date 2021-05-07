using System;

namespace Leetcode._13_RomanToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RomanToInt_2("III"));
            Console.WriteLine(RomanToInt_2("IV"));
            Console.WriteLine(RomanToInt_2("IX"));
            Console.WriteLine(RomanToInt_2("LVIII"));
            Console.WriteLine(RomanToInt_2("MCMXCIV"));
            Console.WriteLine(RomanToInt_2("DCXXI"));
        }

        public static int RomanToInt_1(string s)
        {
            int result = 0;

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == 'M')
                {
                    if (i - 1 >= 0 && s[i - 1] == 'C')
                    {
                        result += 900;
                    }
                    else
                    {
                        result += 1000;
                    }
                }
                else if (s[i] == 'D')
                {
                    if (i - 1 >= 0 && s[i - 1] == 'C')
                    {
                        result += 400;
                    }
                    else
                    {
                        result += 500;
                    }
                }
                else if (s[i] == 'C')
                {
                    if (i - 1 >= 0 && s[i - 1] == 'X')
                    {
                        result += 90;
                    }
                    else if (i + 1 == s.Length || (s[i + 1] != 'D' && s[i + 1] != 'M'))
                    {
                        result += 100;
                    }
                }
                else if (s[i] == 'L')
                {
                    if (i - 1 >= 0 && s[i - 1] == 'X')
                    {
                        result += 40;
                    }
                    else
                    {
                        result += 50;
                    }
                }
                else if (s[i] == 'X')
                {
                    if (i - 1 >= 0 && s[i - 1] == 'I')
                    {
                        result += 9;
                    }
                    else if (i + 1 == s.Length || (s[i + 1] != 'L' && s[i + 1] != 'C'))
                    {
                        result += 10;
                    }
                }
                else if (s[i] == 'V')
                {
                    if (i - 1 >= 0 && s[i - 1] == 'I')
                    {
                        result += 4;
                    }
                    else
                    {
                        result += 5;
                    }
                }
                else if (i + 1 == s.Length || (s[i + 1] != 'V' && s[i + 1] != 'X'))
                {
                    result += 1;
                }
            }

            return result;
        }

        public static int RomanToInt_2(string s)
        {
            int result = 0;

            for (var i = 0; i < s.Length;)
            {
                if (i + 1 < s.Length && GetValue(s[i]) < GetValue(s[i + 1]))
                {
                    result += GetValue(s[i + 1]) - GetValue(s[i]);
                    i += 2;
                }
                else
                {
                    result += GetValue(s[i]);
                    i++;
                }
            }

            return result;
        }

        private static int GetValue(char s)
        {
            switch (s)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    throw new ArgumentOutOfRangeException(nameof(s));
            }
        }
    }
}
