using System;
using System.Collections.Generic;

namespace Leetcode._204_CountPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountPrimes_1(10));
            Console.WriteLine(CountPrimes_2(10));
        }

        public static int CountPrimes_1(int n)
        {
            if (n <= 2)
            {
                return 0;
            }

            var counter = 1;
            var hashset = new HashSet<int>();

            for (var currentPrime = 2; currentPrime < n;)
            {
                var currentNumber = currentPrime + currentPrime;
                hashset.Add(currentNumber);

                while (currentNumber < n)
                {
                    currentNumber += currentPrime;
                    hashset.Add(currentNumber);
                }

                currentPrime++;
                while (hashset.Contains(currentPrime))
                {
                    currentPrime++;
                }

                if (currentPrime < n)
                {
                    counter++;
                }
            }

            return counter;
        }

        public static int CountPrimes_2(int n)
        {
            if (n <= 2)
            {
                return 0;
            }

            bool[] numbers = new bool[n];
            for (int p = 2; p <= (int)Math.Sqrt(n); ++p)
            {
                if (numbers[p] == false)
                {
                    for (int j = p * p; j < n; j += p)
                    {
                        numbers[j] = true;
                    }
                }
            }

            int numberOfPrimes = 0;
            for (int i = 2; i < n; i++)
            {
                if (numbers[i] == false)
                {
                    ++numberOfPrimes;
                }
            }

            return numberOfPrimes;
        }
    }
}
