using System;
using System.Collections.Generic;

namespace net
{
    public class tr2
    {
        public static void mna()
        {
            Console.WriteLine($"Expected: 4, Got: {new tr2().TrapRainWater(new[] {new[] {1, 4, 3, 1, 3, 2}, new[] {3, 2, 1, 3, 2, 4}, new[] {2, 3, 3, 2, 3, 1}})}");
            Console.WriteLine($"Expected: 10, Got: {new tr2().TrapRainWater(new[] {new[] {3, 3, 3, 3, 3}, new[] {3, 2, 2, 2, 3}, new[] {3, 2, 1, 2, 3}, new[] {3, 2, 2, 2, 3}, new[] {3, 3, 3, 3, 3}})}");
            Console.WriteLine($"Expected: 14, Got: {new tr2().TrapRainWater(new[] {new[] {12, 13, 1, 12}, new[] {13, 4, 13, 12}, new[] {13, 8, 10, 12}, new[] {12, 13, 12, 12}, new[] {13, 13, 13, 13}})}");
            Console.WriteLine($"Expected: 0, Got: {new tr2().TrapRainWater(new[] {new[] {2, 3, 4}, new[] {5, 6, 7}, new[] {8, 9, 10}, new[] {11, 12, 13}, new[] {14, 15, 16}})}");
            Console.WriteLine($"Expected: 3, Got: {new tr2().TrapRainWater(new[] {new[] {5, 5, 5, 1}, new[] {5, 1, 1, 5}, new[] {5, 1, 5, 5}, new[] {5, 2, 5, 8}})}");
        }

        public int TrapRainWater(int[][] heightMap)
        {
            int volume = 0;
            int m = heightMap.Length, n = heightMap[0].Length;
            bool[,] visited = new bool[m, n];
            var moves = new[,] {{0, -1}, {1, 0}, {0, 1}, {-1, 0}};

            for (int i = 1; i < m - 1; i++)
            for (int j = 1; j < n - 1; j++)
                if (!visited[i, j])
                {
                    Dictionary<Tuple<int, int>, int> previous = new Dictionary<Tuple<int, int>, int>();
                    Queue<Tuple<int, int>> next = new Queue<Tuple<int, int>>();
                    int x = i, y = j, minWall = int.MaxValue;
                    while (!visited[x, y])
                    {
                        int minAdjacent = int.MaxValue, minGreater = int.MaxValue;
                        for (int k = 0; k < 4; k++)
                        {
                            int mX = x + moves[k, 0], mY = y + moves[k, 1];
                            if (0 <= mX && mX < m && 0 <= mY && mY < n)
                            {
                                if (!previous.ContainsKey(Tuple.Create(mX, mY)))
                                {
                                    if (heightMap[mX][mY] < minAdjacent)
                                        minAdjacent = heightMap[mX][mY];

                                    if (heightMap[mX][mY] > heightMap[x][y] && minGreater > heightMap[mX][mY])
                                        minGreater = heightMap[mX][mY];
                                }

                                if (mX == 0 || mX == m - 1 || mY == 0 || mY == n - 1)
                                {
                                    if (minWall > heightMap[mX][mY])
                                        minWall = heightMap[mX][mY];
                                }

                                if (0 < mX && mX < m - 1 && 0 < mY && !visited[mX, mY] && mY < n - 1)
                                    next.Enqueue(Tuple.Create(mX, mY));
                            }
                        }

                        visited[x, y] = true;
                        foreach (var key in previous.Keys)
                        {
                            int increment = minGreater == int.MaxValue
                                ? 0
                                : minGreater - heightMap[key.Item1][key.Item2];
                            previous[Tuple.Create(key.Item1, key.Item2)] += increment;
                        }

                        previous.Add(Tuple.Create(x, y),
                            (minGreater == int.MaxValue ? heightMap[x][y] : minGreater) - heightMap[x][y]);

                        if (next.Count > 0)
                            (x, y) = next.Dequeue();
                        else break;
                    }

                    foreach (var prev in previous.Keys)
                        if (heightMap[prev.Item1][prev.Item2] > minWall)
                            // volume -= heightMap[prev.Item1][prev.Item2] - minWall;
                            volume += previous[Tuple.Create(prev.Item1, prev.Item2)];
                }

            return volume;
        }

        public int TrapRainWater4(int[][] heightMap)
        {
            int volume = 0;
            int m = heightMap.Length, n = heightMap[0].Length;
            bool[,] visited = new bool[m, n];
            var moves = new[,] {{0, -1}, {1, 0}, {0, 1}, {-1, 0}};

            for (int i = 1; i < m - 1; i++)
            for (int j = 1; j < n - 1; j++)
            {
                Dictionary<Tuple<int, int>, int> previous = new Dictionary<Tuple<int, int>, int>();
                Queue<Tuple<int, int>> next = new Queue<Tuple<int, int>>();
                int x = i, y = j;
                while (!visited[x, y])
                {
                    int minGreater = int.MaxValue;
                    for (int k = 0; k < 4; k++)
                    {
                        int mX = x + moves[k, 0], mY = y + moves[k, 1];
                        if (0 <= mX && mX < m && 0 <= mY && mY < n && !visited[mX, mY])
                        {
                            if (heightMap[mX][mY] > heightMap[x][y]
                                && heightMap[mX][mY] < minGreater
                                && !previous.ContainsKey(Tuple.Create(mX, mY)))
                                minGreater = heightMap[mX][mY];

                            if (heightMap[mX][mY] <= heightMap[x][y] &&
                                (mX == 0 || mX == m - 1 || mY == 0 || mY == n - 1))
                                minGreater = heightMap[x][y];

                            if (minGreater < int.MaxValue && 0 < mX && mX < m - 1 && 0 < mY && mY < n - 1
                                && !visited[mX, mY] && heightMap[mX][mY] >= heightMap[x][y])
                                next.Enqueue(Tuple.Create(mX, mY));
                        }
                    }

                    visited[x, y] = true;
                    if (minGreater < int.MaxValue && minGreater != heightMap[x][y])
                    {
                        var increment = minGreater - heightMap[x][y];
                        foreach (var key in previous.Keys)
                            if (heightMap[key.Item1][key.Item2] < heightMap[x][y])
                            {
                                previous[key] += increment;
                                heightMap[key.Item1][key.Item2] += increment;
                            }

                        previous[Tuple.Create(x, y)] = increment;
                    }

                    if (next.Count > 0)
                        (x, y) = next.Dequeue();
                    else break;
                }

                foreach (var elem in previous)
                    volume += elem.Value;
            }

            return volume;
        }

        public int TrapRainWater2(int[][] heightMap)
        {
            int waterArea = 0;
            int i;
            for (i = 1; i < heightMap.Length / 2; i++)
            {
                waterArea += GetRowArea(ref heightMap[i], heightMap[i - 1], heightMap[i]);
                int j = heightMap.Length - i;
                waterArea += GetRowArea(ref heightMap[j - 1], heightMap[j], heightMap[j - 1]);
            }

            if (heightMap.Length % 2 == 1)
            {
                waterArea += GetRowArea(ref heightMap[i], heightMap[i - 1], heightMap[i + 1]);
            }

            return waterArea;
        }

        private int GetRowArea(ref int[] row, int[] previousRow, int[] nextRow)
        {
            int rowArea = 0;
            int peakLeft = 0, peakRight = 0;
            for (int l = 0, r = row.Length - 1; l < r;)
            {
                if (row[l] < row[r])
                {
                    peakLeft = Math.Max(peakLeft, row[l]);
                    int top = Math.Max(peakLeft, Math.Min(nextRow[l], previousRow[l]));
                    rowArea += top - row[l++];
                    row[l - 1] = top - row[l - 1];
                }
                else
                {
                    peakRight = Math.Max(peakRight, row[r]);
                    int top = Math.Max(peakRight, Math.Min(nextRow[r], previousRow[r]));
                    rowArea += top - row[r--];
                    row[r + 1] = top - row[r + 1];
                }
            }

            return rowArea;
        }

        public int TrapRainWater3(int[][] heightMap)
        {
            int waterArea = 0;
            int peakLf = 0, peakLb = 0, peakRf = 0, peakRb = 0;
            for (int l = 0, r = heightMap.Length - 1, f = 0, b = heightMap[0].Length - 1; l <= r && f <= b;)
            {
                if (heightMap[l][f] < Math.Min(heightMap[l][b], Math.Min(heightMap[r][f], heightMap[r][b])))
                {
                    peakLf = Math.Max(peakLf, heightMap[l][f]);
                    if (heightMap[l][f] >= 0)
                        waterArea += peakLf - heightMap[l][f];
                    heightMap[l][f] = -1;
                    AdvanceCell(heightMap, ref l, ref f, 1, 1);
                }
                else if (heightMap[l][b] < Math.Min(heightMap[l][f], Math.Min(heightMap[r][f], heightMap[r][b])))
                {
                    peakLb = Math.Max(peakLb, heightMap[l][b]);
                    if (heightMap[l][b] >= 0)
                        waterArea += peakLb - heightMap[l][b];
                    heightMap[l][b] = -1;
                    AdvanceCell(heightMap, ref l, ref b, 1, -1);
                }
                else if (heightMap[r][f] < Math.Min(heightMap[l][f], Math.Min(heightMap[l][b], heightMap[r][b])))
                {
                    peakRf = Math.Max(peakRf, heightMap[r][f]);
                    if (heightMap[r][f] >= 0)
                        waterArea += peakRf - heightMap[r][f];
                    heightMap[r][f] = -1;
                    AdvanceCell(heightMap, ref r, ref f, -1, 1);
                }
                else
                {
                    peakRb = Math.Max(peakRb, heightMap[r][b]);
                    if (heightMap[r][b] >= 0)
                        waterArea += peakRb - heightMap[r][b];
                    heightMap[r][b] = -1;
                    AdvanceCell(heightMap, ref r, ref b, -1, -1);
                }
            }

            return waterArea;
        }

        private void AdvanceCell(int[][] heightMap, ref int x, ref int y, short movX, short movY)
        {
            if (heightMap[x + movX][y] < Math.Min(heightMap[x][y + movY], heightMap[x + movX][y + movY]))
                x += movX;
            else if (heightMap[x][y + movY] < Math.Min(heightMap[x + movX][y], heightMap[x + movX][y + movY]))
                y += movY;
            else
            {
                x += movX;
                y += movY;
            }
        }
    }
}