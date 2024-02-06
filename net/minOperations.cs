using System;
using System.Collections.Generic;

namespace net
{
    public class mo
    {
        public static void minop()
        {
            Console.WriteLine(new mo().MinOperations(new[] {1, 1, 4, 2, 3}, 5));
            Console.WriteLine(new mo().MinOperations(new[] {5, 6, 7, 8, 9}, 4));
            Console.WriteLine(new mo().MinOperations(new[] {3, 2, 20, 1, 1, 3}, 10));
            Console.WriteLine(new mo().MinOperations(new[] {8828, 9581, 49, 9818, 9974, 9869, 9991, 10000, 10000, 10000, 9999, 9993, 9904, 8819, 1231, 6309},134365));
        }

        public int MinOperations(int[] nums, int x)
        {
            int minOps = -1;
            long sum = 0;
            for (int i = 0; i < nums.Length; i++)
                sum += nums[i];

            long sumToFind = sum - x; //we are looking for the longst subarray that sums this value

            int start = 0, innerSum = 0, maxLength = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                while (innerSum + nums[i] > sumToFind && start <= i)
                    innerSum -= nums[start++];

                if (innerSum + nums[i] == sumToFind)
                {
                    if (i - start > maxLength)
                    {
                        maxLength = i - start;
                        minOps = nums.Length - (i - start) - 1;
                    }
                }

                innerSum += nums[i];
            }

            return minOps;
        }
    }
}