using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace net
{
    public class fbunif
    {
        public static void unf()
        {
            var solution = new fbunif();
            Console.WriteLine($"Expected: 5, Got: {solution.getUniformIntegerCountInInterval(75, 300)}");
            Console.WriteLine($"Expected: 9, Got: {solution.getUniformIntegerCountInInterval(1, 9)}");
            Console.WriteLine($"Expected: 1, Got: {solution.getUniformIntegerCountInInterval(999999999999, 999999999999)}");
            Console.WriteLine($"Expected: 2, Got: {solution.getUniformIntegerCountInInterval(75, 95)}");
        }

        public int getUniformIntegerCountInInterval(long A, long B)
        {
            var result = 0;
            long start = 0;
            for (int i = 0; i < A.ToString().Length; i++)
                start += Convert.ToInt64(Math.Pow(10, i));
    
            long end = 0;
            for (int i = 0; i < B.ToString().Length; i++)
                end += Convert.ToInt64(Math.Pow(10, i));

            var aux = Convert.ToInt64(A.ToString().Substring(0, 1));
            while (start <= end)
            {
                var increment = start;
                aux = aux * start;

                var nextStop = Math.Pow(10, start.ToString().Length);
                while (aux < nextStop)
                {
                    if (aux >= A && aux <= B)
                        result++;
                    aux += increment;
                }

                start = Convert.ToInt64($"{start}1");
                aux = 1;
            }

            return result;
        }
    }
}