using System;
using System.Linq;

namespace Leetcode._67_AddBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AddBinary("1111", "1111"));
            Console.WriteLine(AddBinary("0", "0"));
            Console.WriteLine(AddBinary("1", "0"));
            Console.WriteLine(AddBinary("1", "1"));
            Console.WriteLine(AddBinary("11", "1"));
            Console.WriteLine(AddBinary("1010", "1011"));
        }

        public static string AddBinary(string a, string b)
        {
            int length;
            if (a.Length < b.Length)
            {
                length = b.Length;
                while (a.Length < b.Length)
                {
                    a = a.Insert(0, "0");
                }
            }
            else if (a.Length > b.Length)
            {
                length = a.Length;
                while (a.Length > b.Length)
                {
                    b = b.Insert(0, "0");
                }
            }
            else
            {
                length = a.Length;
            }

            string result = "";

            bool haveResidue = false;
            for (var i = length - 1; i >= 0; i--)
            {
                char aChar = a[i];
                char bChar = b[i];

                if (aChar == '0' && bChar == '0')
                {
                    result = result.Insert(0, haveResidue ? "1" : "0");
                    haveResidue = false;
                }
                else if (aChar == '0' && bChar == '1' || aChar == '1' && bChar == '0')
                {
                    result = result.Insert(0, haveResidue ? "0" : "1");
                }
                else if (aChar == '1' && bChar == '1')
                {
                    result = result.Insert(0, haveResidue ? "1" : "0");
                    haveResidue = true;
                }
            }

            if (haveResidue)
            {
                result = result.Insert(0, "1");
            }

            return result;
        }
    }
}
