using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace net
{
    public class twos
    {
        public static void mnwts()
        {
            var solution = new twos();
            Console.WriteLine(
                $"Expected: [0,1], Got: [{String.Join(",", solution.TwoSum(new int[] {2, 7, 11, 15}, 9))}]");
            Console.WriteLine(
                $"Expected: [1,2], Got: [{String.Join(",", solution.TwoSum(new int[] {3, 2, 4}, 6))}]");
            Console.WriteLine(
                $"Expected: [0,1], Got: [{String.Join(",", solution.TwoSum(new int[] {3, 3}, 6))}]");
            Console.WriteLine(
                $"Expected: [1,2], Got: [{String.Join(",", solution.TwoSum(new int[] {2,5,5,11}, 10))}]");
        }

        public int[] TwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length <= 0)
                return new int[] { };

            var dict = new Dictionary<int, List<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                    dict[nums[i]].Add(i);
                else dict.Add(nums[i], new List<int>(new[] {i}));
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];
                if (dict.ContainsKey(diff))
                {
                    foreach (var index in dict[diff])
                        if (index != i)
                            return new[] {i, index};
                }
            }

            return new int[] { };
        }
    }
}