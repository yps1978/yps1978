using System;
using System.Collections.Generic;
using System.Text;

namespace net
{
    public class SolP
    {
        public static void Mainsss()
        {
            var solution = new SolP();
            var res = solution.LongestPalindrome("babad");
            Console.WriteLine($"Expected: bab Got: {res}");

            res = solution.LongestPalindrome("cbbd");
            Console.WriteLine($"Expected: bb Got: {res}");

            res = solution.LongestPalindrome("aacabdkacaa");
            Console.WriteLine($"Expected: aca Got: {res}");
        }

        public string LongestPalindrome(string s)
        {
            if (s.Length <= 1)
                return s;
            var longest = int.MinValue;
            var longPal = "";
            int len = s.Length;
            for (int l = 0; l < len - 1; l++)
            {
                var r = len - 1;
                while (l <= r)
                {
                    if (s[l] == s[r])
                    {
                        //search if this is symmetric
                        var mid = (l + r) % 2 + (l + r) / 2;
                        bool palindrome = true;
                        for (int i = l + 1; i < mid; i++)
                            if (s[i] != s[r - (i - l)])
                            {
                                palindrome = false;
                                break;
                            }

                        if (palindrome && longest < r - l)
                        {
                            longest = r - l;
                            longPal = s.Substring(l, r - l + 1);
                        }
                    }

                    r--;
                }
            }

            return longPal;
        }
    }
}