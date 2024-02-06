using System;
using System.Collections.Generic;

namespace net
{
    public class tr
    {
        public static void ta()
        {
            Console.WriteLine(new tr().Trap(new[] {0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1}));
            Console.WriteLine(new tr().Trap(new[] {4, 2, 0, 3, 2, 5}));
            Console.WriteLine(new tr().Trap(new[] {4, 2, 0, 3, 2, 4}));
            Console.WriteLine(new tr().Trap(new[] {4, 2, 0, 3, 2, 3}));
            Console.WriteLine(new tr().Trap(new[] {2, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1}));
            Console.WriteLine(new tr().Trap(new[] {2, 0, 2}));
            Console.WriteLine(new tr().Trap(new[] {4, 2, 3}));
            Console.WriteLine(new tr().Trap(new[] {0, 2, 0}));
            Console.WriteLine(new tr().Trap(new[] {5, 4, 1, 2}));
            Console.WriteLine(new tr().Trap(new[] {1, 0, 5, 2, 6, 3, 0, 1}));
            Console.WriteLine(new tr().Trap(new[] {3, 0, 5, 0, 4, 5}));
        }


        public int Trap(int[] height)
        {
            int waterArea = 0;
            int peakLeft = 0, peakRight = 0;
            for (int l = 0, r = height.Length - 1; l < r;)
            {
                if (height[l] < height[r])
                {
                    peakLeft = Math.Max(peakLeft, height[l]);
                    waterArea += peakLeft - height[l++];
                }
                else
                {
                    peakRight = Math.Max(peakRight, height[r]);
                    waterArea += peakRight - height[r--];
                }
            }

            return waterArea;
        }
    }
}