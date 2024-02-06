using System;
using System.Collections.Generic;

namespace net
{
    public class mr
    {
        public static void mn()
        {
            Console.WriteLine(new mr().MinimumRemoval(new[] {4, 1, 6, 5}));
            Console.WriteLine(new mr().MinimumRemoval(new[] {2, 10, 3, 2}));
            Console.WriteLine(new mr().MinimumRemoval(new[] {14, 53, 54}));
            Console.WriteLine(new mr().MinimumRemoval(new[] {66, 90, 47, 25, 92, 90, 76, 85, 22, 3}));
        }

        public long MinimumRemoval(int[] beans)
        {
            long minRemovals = long.MaxValue;

            Array.Sort(beans);
            long sum = 0, n = beans.Length;
            for (int i = 0; i < n; i++)
                sum += beans[i];

            for (int i = 0; i < n; i++)
                if (sum - beans[i] * (n - i) < minRemovals)
                    minRemovals = sum - beans[i] * (n - i);

            return minRemovals;
        }
    }
}