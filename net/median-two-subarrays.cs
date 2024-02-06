using System;
using System.Collections.Generic;
using System.Text;

namespace net
{
    public class solmed
    {
        public static void Mainsn()
        {
            var solution = new solmed();
            var res = solution.FindMedianSortedArrays(new[] {1, 3}, new[] {2});
            Console.WriteLine($"Expected: 2.000000, Got: {res}");

            res = solution.FindMedianSortedArrays(new[] {1, 2}, new[] {3, 4});
            Console.WriteLine($"Expected: 2.500000, Got: {res}");

            res = solution.FindMedianSortedArrays(new[] {1, 3, 4, 6}, new[] {25, 28, 30, 35, 36});
            Console.WriteLine($"Expected: 25, Got: {res}");

            res = solution.FindMedianSortedArrays(new int[] { }, new[] {1});
            Console.WriteLine($"Expected: 1, Got: {res}");
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
                return FindMedianSortedArrays(nums2, nums1);

            int n1 = nums1.Length, n2 = nums2.Length;
            var mid = (n1 + n2 - 1) / 2;

            int l = 0, r = mid > n1 ? n1 : mid;

            while (l < r)
            {
                var m1 = (l + r) / 2;
                var m2 = mid - m1;
                if (nums1[m1] < nums2[m2])
                    // search between m1+1 and r
                    l = m1 + 1;
                else
                    // search between l and m1
                    r = m1;
            }

            var e1 = Math.Max(l > 0 ? nums1[l - 1] : int.MinValue, mid - l >= 0 ? nums2[mid - l] : int.MinValue);
            if ((n1 + n2) % 2 == 1)
                return e1 * 1.0;

            var e2 = Math.Min(l < n1 ? nums1[l] : int.MaxValue, mid - l + 1 < n2 ? nums2[mid - l + 1] : int.MaxValue);

            return (e1 + e2) / 2.0;
        }
    }
}