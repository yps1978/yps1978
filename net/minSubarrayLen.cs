using System;
using System.Collections.Generic;

namespace net
{
    public class msal
    {
        public static void mnsarrfl()
        {
            Console.WriteLine(new msal().MinSubArrayLen(7, new[] {2, 3, 1, 2, 4, 3}));
            Console.WriteLine(new msal().MinSubArrayLen(4, new[] {1, 4, 4}));
            Console.WriteLine(new msal().MinSubArrayLen(11, new[] {1, 1, 1, 1, 1, 1, 1, 1}));
            Console.WriteLine(new msal().MinSubArrayLen(15, new[] {1, 2, 3, 4, 5}));
        }

        public int MinSubArrayLen(int target, int[] nums)
        {
            int currSum = 0;
            int minLength = int.MaxValue, start = 0;
            bool found = false;

            for (int i = 0; i < nums.Length; i++)
            {
                while (currSum + nums[i] >= target && start <= i)
                {
                    if (currSum + nums[i] >= target && i - start + 1 < minLength)
                    {
                        minLength = i - start + 1;
                        found = true;
                    }

                    currSum -= nums[start++];
                }

                currSum += nums[i];
            }

            return found ? minLength : 0;
        }
    }
}