using System;
using System.Collections.Generic;
using System.Text;

namespace net
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
    }

    public class addtn
    {
        public static void Maintn()
        {
            var solution = new addtn();
            var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
            var res = solution.AddTwoNumbers(l1, l2);
            var sum = 0;
            while (res != null)
            {
                sum = (sum * 10) + res.val;
                res = res.next;
            }

            Console.WriteLine($"Expected: 708, Got: {sum}");
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var result = new ListNode(0);
            bool firstTime = true;
            var currentNode = result;
            int mod = 0;
            while (l1 != null || l2 != null)
            {
                if (!firstTime)
                {
                    currentNode.next = new ListNode(0);
                    currentNode = currentNode.next;
                }

                firstTime = false;

                var val1 = l1?.val ?? 0;
                var val2 = l2?.val ?? 0;
                var aux = mod + val1 + val2;
                currentNode.val = aux % 10;
                mod = aux / 10;
                l1 = l1?.next;
                l2 = l2?.next;
            }

            if (mod > 0)
                currentNode.next = new ListNode(mod, null);
            else currentNode.next = null;

            return result;
        }
    }
}