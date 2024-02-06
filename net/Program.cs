using System;
using System.Collections.Generic;
using System.Text;

namespace net
{
    public class Solution
    {
        public static void Main()
        {
            var solution = new Solution();
            Console.WriteLine($"Expected: 4 Got: {solution.SingleNonDuplicate(new[] {1, 1, 2, 2, 3, 3, 4, 5, 5})}");
            Console.WriteLine($"Expected: 2 Got: {solution.SingleNonDuplicate(new[] {1, 1, 2, 3, 3, 4, 4, 8, 8})}");
            Console.WriteLine($"Expected: 10 Got: {solution.SingleNonDuplicate(new[] {3, 3, 7, 7, 10, 11, 11})}");
            Console.WriteLine($"Expected: 1 Got: {solution.SingleNonDuplicate(new[] {1, 2, 2})}");
            Console.WriteLine($"Expected: 1 Got: {solution.SingleNonDuplicate(new[] {1, 2, 2, 7, 7, 9, 9})}");
            Console.WriteLine($"Expected: 2 Got: {solution.SingleNonDuplicate(new[] {1, 1, 2})}");
        }

        public int SingleNonDuplicate(int[] nums)
        {
            if (nums.Length <= 0 || nums.Length % 2 == 0)
                throw new Exception("invalid input");

            if (nums.Length == 1) return nums[0];

            int left = 0, right = nums.Length - 1;

            while (right - left > 2)
            {
                int midIdx = left + ((right - left) / 2);
                if (midIdx == left || midIdx == right)
                    break;

                bool even = midIdx % 2 == 0;

                if (even && nums[midIdx] != nums[midIdx + 1])
                    right = midIdx;
                else
                    left = (even ? 2 : 1) + midIdx;
            }

            if (nums[left] == nums[left + 1])
                return nums[right];

            if (nums[right] == nums[right - 1])
                return nums[left];

            return nums[(right - left) / 2];
        }
    }
}