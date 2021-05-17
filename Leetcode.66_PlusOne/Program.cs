using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode._66_PlusOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PlusOne(new[] { 1, 2, 3 }));
            Console.WriteLine(PlusOne(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }));
        }

        public static int[] PlusOne(int[] digits)
        {
            List<int> result;

            for (var i = digits.Length; i >= 0; i--)
            {
                if (digits[i] == 9 )
                {
                    continue;
                }
                else
                {
                    if (i == 0)
                    {

                    }
                    else
                    {
                        digits[i]++;
                        if (i + 1 < digits.Length)
                        {
                            i++;
                            while (i < digits.Length)
                            {
                                digits[i] = 0;
                            }
                        }

                        result = digits.ToList();
                    }
                }
            }
        }
    }
}
