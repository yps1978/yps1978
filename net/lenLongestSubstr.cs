using System;
using System.Collections.Generic;
using System.Text;

namespace net
{

    public class llsbs
    {
        public static void mlsubss()
        {
            var solution = new llsbs();
            var res = solution.LengthOfLongestSubstring("tmmzuxt");
            Console.WriteLine($"Expected: 5, Got: {res}");
        }
        
        public int LengthOfLongestSubstring(string s)
        {
            int longestSubStr = 0;
            var queue = new Queue<char>();
            var hash = new HashSet<char>();
            for (int i = 0; i < s.Length; i++)
            {
                var chr = s[i];
                char aux;
                if (hash.Contains(chr))
                    while (queue.Count > 0 && (aux = queue.Dequeue()) != chr)
                        hash.Remove(aux);
                queue.Enqueue(chr);
                hash.Add(chr);
                if (longestSubStr < queue.Count)
                    longestSubStr = queue.Count;
            }

            return longestSubStr;
        }
    }
}