using System;
using System.Collections.Generic;

namespace Leetcode._20_ValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool IsValid(string s)
        {
            if (s.Length == 1)
            {
                return false;
            }

            var stack = new Stack<char>();

            foreach (var character in s)
            {
                if(character == '(' || character == '{' ||character == '[')
                {
                    stack.Push(character);
                }
                else
                {
                    if(stack.Count == 0)
                    {
                        return false;
                    }

                    var popedCharacter = stack.Pop();
                    if(character == ')' && popedCharacter != '(' || character == '}' && popedCharacter != '{' || character == ']' && popedCharacter != '[')
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
