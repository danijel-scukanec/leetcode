using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode._56_MergeIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            Merge_1(new[] { new[] { 2, 3 }, new[] { 4, 5 }, new[] { 6, 7 }, new[] { 8, 9 }, new[] { 1, 10 } });
            Merge_1(new[] { new[] { 1, 3 }, new[] { 2, 6 }, new[] { 8, 10 }, new[] { 15, 18 } });
        }

        public static int[][] Merge_1(int[][] intervals)
        {
            for (var i = 0; i < intervals.Length; i++)
            {
                if (intervals[i] == null)
                {
                    continue;
                }

                for (var j = i + 1; j < intervals.Length; j++)
                {
                    if (intervals[i] == null || intervals[j] == null)
                    {
                        continue;
                    }

                    if (intervals[i][0] <= intervals[j][1] && intervals[j][0] <= intervals[i][1])
                    {
                        intervals[j] = new[] { Math.Min(intervals[i][0], intervals[j][0]), Math.Max(intervals[i][1], intervals[j][1]) };
                        intervals[i] = null;
                    }
                }
            }

            return intervals.Where(x => x != null).ToArray();
        }
    }
}
