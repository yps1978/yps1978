using System;
using System.Text;

namespace net
{
    class plnd
    {
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }

            public class Solution
            {
                public bool IsPalindrome(ListNode head)
                {
                    if (head == null)
                        return true;
                    StringBuilder sb = new StringBuilder();
                    while (head != null)
                    {
                        sb.Append(head.val);
                        head = head.next;
                    }

                    var str = sb.ToString();
                    var n = sb.Length;
                    for (int i = 0; i < n / 2; i++)
                    {
                        if (str[i] != str[n - i - 1])
                            return false;
                    }

                    return true;
                }
            }
        }
    }
}