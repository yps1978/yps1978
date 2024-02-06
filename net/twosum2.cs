using System;

namespace net
{
    public class ts2
    {
        public static void mnts2()
        {
            var solution = new ts2();
            Console.WriteLine(
                $"Expected: [1,2], Got: [{String.Join(",", solution.TwoSum(new int[] {2, 7, 11, 15}, 9))}]");
            Console.WriteLine(
                $"Expected: [1,3], Got: [{String.Join(",", solution.TwoSum(new int[] {2, 3, 4}, 6))}]");
            Console.WriteLine(
                $"Expected: [1,2], Got: [{String.Join(",", solution.TwoSum(new int[] {-1, 0}, -1))}]");
            Console.WriteLine(
                $"Expected: [2,3], Got: [{String.Join(",", solution.TwoSum(new int[] {5, 25, 75}, 100))}]");
            Console.WriteLine(
                $"Expected: [3,6], Got: [{String.Join(",", solution.TwoSum(new int[] {3, 24, 50, 79, 88, 150, 345}, 200))}]");
        }

        public int[] TwoSum(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length <= 1)
                return new int[] { };

            int p1 = 0, p2 = numbers.Length - 1;
            while (numbers[p2] + numbers[0] > target && p2 > 0)
                p2--;

            while (p1 < p2)
            {
                var sum = numbers[p1] + numbers[p2];
                if (sum == target)
                    return new[] {p1 + 1, p2 + 1};

                if (sum < target)
                    p1++;
                else p2--;
            }

            return new int[] { };
        }
    }
}