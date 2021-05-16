using System;

namespace Leetcode._58_LengthOfLastWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int LengthOfLastWord(string s)
        {
            var lastWordLength = 0;
            for(var i = s.Length - 1; i >= 0; i--)
            {
                if(s[i] == ' ' && lastWordLength == 0)
                {                    
                    continue;
                }
                else if(s[i] == ' ' && lastWordLength > 0)
                {
                    break;
                }

                lastWordLength++;
            }

            return lastWordLength;
        }
    }
}
