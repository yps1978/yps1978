using System;
using System.Collections.Generic;
using System.Text;

namespace net
{
    public class getways
    {
        public static void Mainw()
        {
            var solution = new getways();
            Console.WriteLine($"getways: 3 Got: {solution.GetWays(3)}");
            Console.WriteLine($"Expected: 5 Got: {solution.GetWays(4)}");
            Console.WriteLine($"Expected: 8 Got: {solution.GetWays(5)}");
            Console.WriteLine($"Expected: 13 Got: {solution.GetWays(6)}");
            Console.WriteLine($"Expected: 21 Got: {solution.GetWays(7)}");
            Console.WriteLine($"Expected: 34 Got: {solution.GetWays(8)}");
            Console.WriteLine();
            Console.WriteLine($"Expected: 3 Got: {solution.GetWaysDP(3)}");
            Console.WriteLine($"Expected: 5 Got: {solution.GetWaysDP(4)}");
            Console.WriteLine($"Expected: 8 Got: {solution.GetWaysDP(5)}");
            Console.WriteLine($"Expected: 13 Got: {solution.GetWaysDP(6)}");
            Console.WriteLine($"Expected: 21 Got: {solution.GetWaysDP(7)}");
            Console.WriteLine($"Expected: 34 Got: {solution.GetWaysDP(8)}");
        }

        public int GetWays(int n)
        {
            if (n <= 2)
                return n;
            return GetWays(n - 1) + GetWays(n - 2);
        }

        public int GetWaysDP(int n)
        {
            int e0 = 0, e1 = 1;

            for (int i = 1; i < n; i++)
                (e0, e1) = (e1, e0 + e1);

            return e0 + e1;
        }
    }
}