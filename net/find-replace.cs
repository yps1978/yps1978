using System;
using System.Collections.Generic;
using System.Text;

namespace net
{
    public class findreplace
    {
        public static void mainfr()
        {
            var solution = new findreplace();
            var res = solution.FindReplaceString("abcd", new[] {0, 2}, new[] {"a", "cd"}, new[] {"eee", "ffff"});
            Console.WriteLine($"Expected: eeebffff, Got: {res}");
            res = solution.FindReplaceString("abcd", new[] {0, 2}, new[] {"ab", "ec"}, new[] {"eee", "ffff"});
            Console.WriteLine($"Expected: eeecd, Got: {res}");
            res = solution.FindReplaceString("vmokgggqzp", new[] {3, 5, 1}, new[] {"kg", "ggq", "mo"},
                new[] {"s", "so", "bfr"});
            Console.WriteLine($"Expected: vbfrssozp, Got: {res}");
            res = solution.FindReplaceString("abcde", new[] {2,2}, new[] {"cdef","bc"}, new[] {"f","fe"});
            Console.WriteLine($"Expected: ?, Got: {res}");
        }

        public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
        {
            var list = new List<Tuple<int, int, string>>();
            for (var i = 0; i < indices.Length; i++)
                if (indices[i]+sources[i].Length<=s.Length && s.Substring(indices[i], sources[i].Length) == sources[i])
                    list.Add(Tuple.Create(indices[i], sources[i].Length, targets[i]));

            list.Sort((x, y) => x.Item1.CompareTo(y.Item1));

            for (int i = list.Count - 1; i >= 0; i--)
                s = s.Substring(0, list[i].Item1) + list[i].Item3 + s.Substring(list[i].Item1 + list[i].Item2);

            return s;
        }
    }
}