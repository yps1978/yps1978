using System;
using System.Collections.Generic;

namespace net
{
    public class artphoto2
    {
        public static void arp()
        {
            var solution = new artphoto2();
            Console.WriteLine($"Expected: 1, Got: {solution.getArtisticPhotographCount(5, "APABA", 1, 2)}");
            Console.WriteLine($"Expected: 0, Got: {solution.getArtisticPhotographCount(5, "APABA", 2, 3)}");
            Console.WriteLine($"Expected: 3, Got: {solution.getArtisticPhotographCount(8, ".PBAAP.B", 1, 3)}");
            Console.WriteLine($"Expected: 0, Got: {solution.getArtisticPhotographCount(10, "BBBBBPPPPP", 1, 3)}");
            Console.WriteLine($"Expected:11, Got: {solution.getArtisticPhotographCount(9, "PAPBAPBAB", 1, 9)}");
            Console.WriteLine($"Expected: 1, Got: {solution.getArtisticPhotographCount(9, "PAPBAPBAB", 4, 4)}");
        
            Console.WriteLine($"Expected: ?, Got: {solution.getArtisticPhotographCount(9, "B.APABA.P", 1, 5)}");
        }

        public long getArtisticPhotographCount(int N, string C, int X, int Y)
        {
            long count = 0;

            int p1 = 0;
            Queue<int> pQueue = new Queue<int>();
            Queue<int> bQueue = new Queue<int>();
            List<Tuple<int, int, int>> aidxs = new List<Tuple<int, int, int>>();

            while (p1 < C.Length)
            {
                while (aidxs.Count > 0 && p1 - aidxs[0].Item1 > Y)
                    aidxs.RemoveAt(0);

                switch (C[p1])
                {
                    case 'P':
                        pQueue.Enqueue(p1);

                        foreach (var tuple in aidxs)
                            if (p1 - tuple.Item1 >= X)
                                count += tuple.Item3;
                        break;

                    case 'B':
                        bQueue.Enqueue(p1);

                        foreach (var tuple in aidxs)
                            if (p1 - tuple.Item1 >= X)
                                count += tuple.Item2;
                        break;

                    case 'A':
                        if (pQueue.Count > 0)
                        {
                            var p = pQueue.Peek();
                            while (pQueue.Count > 0 && p1 - p > Y)
                                p = pQueue.Dequeue();
                        }

                        if (bQueue.Count > 0)
                        {
                            var b = bQueue.Peek();
                            while (bQueue.Count > 0 && p1 - b > Y)
                                b = bQueue.Dequeue();
                        }

                        var pCount = 0;
                        foreach (var idx in pQueue)
                            if (p1 - idx >= X)
                                pCount++;

                        var bCount = 0;
                        foreach (var idx in bQueue)
                            if (p1 - idx >= X)
                                bCount++;

                        aidxs.Add(Tuple.Create(p1, pCount, bCount));
                        break;
                }

                p1++;
            }

            return count;
        }
    }
}
/*
PAPBAPBAB
P......AB
P...A...B
P...A.B..
PA.B.....
PA....B..
PA......B
..P....AB
..P.A...B
..P.A.B..
.....P.AB
...BAP...
 */