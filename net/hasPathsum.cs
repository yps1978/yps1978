using System;
using System.Collections.Generic;

namespace net
{
    /**
 * Definition for a binary tree node.
 */
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class hps
    {
        public static void msnj()
        {
            var solution = new hps();
            var root = solution.GetTree(new int?[] {5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1});
            Console.WriteLine($"Expected: true, Got: {solution.HasPathSum(root, 22)}");
            
            
            root = solution.GetTree(new int?[] {1,2,3});
            Console.WriteLine($"Expected: false, Got: {solution.HasPathSum(root, 3)}");
        }


        public bool HasPathSum(TreeNode root, int targetSum)
        {
            return HasPathSum2(root, targetSum, 0);
        }

        private bool HasPathSum2(TreeNode root, int targetSum, int sum)
        {
            if (root != null && root.left == null && root.right == null && targetSum == sum + root.val)
                return true;

            var leftSum = root?.left != null && HasPathSum2(root.left, targetSum, sum + root.val);
            if (leftSum) return true;

            var rightsum = root?.right != null && HasPathSum2(root.right, targetSum, sum + root.val);
            if (rightsum) return true;

            return false;
        }

        private TreeNode GetTree(int?[] arr)
        {
            int level = 0, i = 0;
            TreeNode root = null;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            while (i < arr.Length)
            {
                if (queue.Count <= 0)
                    queue.Enqueue(root = new TreeNode(arr[i++].GetValueOrDefault(), null, null));
                else
                {
                    var repeats = Math.Pow(2, level);
                    for (int k = 0; i < arr.Length && k < repeats; k++)
                    {
                        var node = queue.Dequeue();
                        if (arr[i] != null)
                            queue.Enqueue(node.left = new TreeNode(arr[i].Value, null, null));
                        i++;
                        if (arr[i] != null)
                            queue.Enqueue(node.right = new TreeNode(arr[i].Value, null, null));
                        i++;
                        k++;
                    }
                }

                level++;
            }

            return root;
        }
    }
}