using System;
using System.Collections.Generic;

namespace net
{
    public class mm2
    {
        public static void dg()
        {
            Console.WriteLine(new mm2().MinMoves2(new[] {1, 2, 3}));
            Console.WriteLine(new mm2().MinMoves2(new[] {1, 10, 2, 9}));
            Console.WriteLine(new mm2().MinMoves2(new[] {1, 0, 0, 8, 6}));
        }

        public int MinMoves2(int[] nums)
        {
            int n = nums.Length;
            if (n <= 1) return 0;
            int moves = 0;
            Array.Sort(nums);
            int median;
            if (nums.Length % 2 == 1)
                median = nums[n / 2];
            else median = (nums[n / 2] + nums[n / 2 - 1]) / 2;

            for (int i = 0; i < n; i++)
            {
                if (nums[i] < median)
                    moves += median - nums[i];
                else moves += nums[i] - median;
            }

            return moves;
        }
    }
}