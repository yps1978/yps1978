using System;
using System.Collections.Generic;

namespace net
{
    public class mm
    {
        public static void xsd()
        {
            Console.WriteLine(new mm().MinMoves(new[] {1, 2, 3}));
            Console.WriteLine(new mm().MinMoves(new[] {1, 1, 1}));
            Console.WriteLine(new mm().MinMoves(new[] {5, 6, 8, 8, 5}));
        }


        public int MinMoves(int[] nums)
        {
            int n = nums.Length;
            if (n <= 1) return 0;

            int moves = 0;
            if (n == 2) return Math.Abs(nums[1] - nums[0]);

            int min = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] < min)
                    min = nums[i];
            for (int i = 1; i < nums.Length; i++)
                moves += nums[i] - min;
            
            return moves;
        }
    }
}