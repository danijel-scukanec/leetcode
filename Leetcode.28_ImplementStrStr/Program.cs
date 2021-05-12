using System;

namespace Leetcode._28_ImplementStrStr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StrStr("hello", "ll"));
            Console.WriteLine(StrStr("aaaaa", "bba"));
            Console.WriteLine(StrStr("", ""));
            Console.WriteLine(StrStr("mississippi", "issip"));
            Console.WriteLine(StrStr("mississippi", "issipi"));
            Console.WriteLine(StrStr("mississippi", "pi"));
        }

        public static int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0)
            {
                return 0;
            }

            if (needle.Length > haystack.Length)
            {
                return -1;
            }

            int firstOccurrencePointer = -1;
            int needlePointer = 0;

            for (var i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle[needlePointer])
                {
                    if (firstOccurrencePointer == -1)
                    {
                        firstOccurrencePointer = i;
                    }

                    needlePointer++;
                    if (needlePointer == needle.Length)
                    {
                        break;
                    }
                }
                else
                {
                    if (firstOccurrencePointer != -1)
                    {
                        i = firstOccurrencePointer;
                    }

                    firstOccurrencePointer = -1;
                    needlePointer = 0;
                }
            }

            if (needlePointer < needle.Length)
            {
                return -1;
            }

            return firstOccurrencePointer;
        }
    }
}
