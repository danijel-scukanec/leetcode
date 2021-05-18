using System;

namespace Leetcode._88_MergeSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Merge(new[] { 1, 2, 3, 0, 0, 0 }, 3, new[] { 2, 5, 6 }, 3);
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int[] memo = new int[m];
            for (var i = 0; i < m; i++)
            {
                memo[i] = nums1[i];
            }

            var memoPointer = 0;
            var nums2Pointer = 0;
            var nums1Pointer = 0;

            while (memoPointer < m || nums2Pointer < n)
            {
                if (memoPointer == m)
                {
                    while(nums2Pointer < n)
                    {
                        nums1[nums1Pointer] = nums2[nums2Pointer];
                        nums2Pointer++;
                        nums1Pointer++;
                    }

                    break;
                }

                if (nums2Pointer == n)
                {
                    while (memoPointer < m)
                    {
                        nums1[nums1Pointer] = memo[memoPointer];
                        memoPointer++;
                        nums1Pointer++;
                    }

                    break;
                }

                if (memo[memoPointer] < nums2[nums2Pointer])
                {
                    nums1[nums1Pointer] = memo[memoPointer];                 
                    memoPointer++;
                    nums1Pointer++;
                }
                else if (memo[memoPointer] > nums2[nums2Pointer])
                {
                    nums1[nums1Pointer] = nums2[nums2Pointer];
                    nums2Pointer++;
                    nums1Pointer++;
                }
                else
                {
                    nums1[nums1Pointer] = memo[memoPointer];
                    nums1Pointer++;
                    memoPointer++;

                    nums1[nums1Pointer] = nums2[nums2Pointer];
                    nums2Pointer++;
                    nums1Pointer++;
                }
            }
        }
    }
}
