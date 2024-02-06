using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace net
{
    public class mindays
    {
        public static void Mainee()
        {
            var solution = new mindays();
            var minDays = solution.MinDays(new int[] {2, 3, 1, 1, 4});
            Console.WriteLine($"Expected: 2, Got: {minDays}");

            minDays = solution.MinDays(new int[] {1, 1, 1, 1, 1, 1, 4});
            Console.WriteLine($"Expected: 6, Got: {minDays}");

            minDays = solution.MinDays(new int[] {2, 1, 1, 1, 1, 1, 4});
            Console.WriteLine($"Expected: 5, Got: {minDays}");

            minDays = solution.MinDays(new int[] {2, 1, 2, 1, 2, 1, 4});
            Console.WriteLine($"Expected: 3, Got: {minDays}");

            minDays = solution.MinDays(new int[] {1, 3, 4, 1, 1, 1, 1, 5});
            Console.WriteLine($"Expected: 4, Got: {minDays}");
            
            minDays = solution.MinDays(new int[] {1, 2, 3, 4, 5, 4, 3, 1});
            Console.WriteLine($"Expected: 3, Got: {minDays}");
        }

        public int MinDays(int[] arr)
        {
            if (arr == null) return 0;
            var bests = new int[arr.Length];
            for (int i = 1; i < bests.Length - 1; i++)
                bests[i] = int.MaxValue;
            bests[0] = 0;
            bests[arr.Length - 1] = arr.Length;

            var lastBest = 1;
            bests[0] = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                var jump = Math.Min(i + arr[i], arr.Length - 1);
                if (i > 0 && bests[i] == int.MaxValue)
                    bests[i] = lastBest;

                if (bests[jump] > bests[i] + 1)
                {
                    bests[jump] = bests[i] + 1;
                    lastBest = bests[i] + 1;
                }
            }

            return bests[arr.Length - 1];
        }


        public class TreeNode
        {
            public int val;
            public int index;
            public List<TreeNode> children;
        }

        public int MinDaysX(int[] arr)
        {
            int i = 0;
            TreeNode root = new TreeNode {val = arr[0], index = 0};
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (i < arr.Length)
            {
                while (queue.Count > 0)
                {
                    i++;
                    var node = queue.Dequeue();
                    var list = new List<TreeNode>();
                    var k = node.index + 1;
                    for (var j = 0; j < node.val && k < arr.Length; j++)
                    {
                        var newNode = new TreeNode {val = arr[k], index = k};
                        list.Add(newNode);
                        queue.Enqueue(newNode);
                        k++;
                    }

                    node.children = list.Count > 0 ? list : null;
                }
            }

            // calculate height
            return GetTreeHeight(root);
        }

        public int GetTreeHeight(TreeNode node)
        {
            if (node == null || node.children == null)
                return 0;

            var maxHeight = int.MaxValue;
            for (int i = 0; i < node.children?.Count; i++)
            {
                var aux = GetTreeHeight(node.children[i]);
                if (aux < maxHeight)
                    maxHeight = aux;
            }

            return 1 + maxHeight;
        }
    }
}