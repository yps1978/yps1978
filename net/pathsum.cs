using System;
using System.Collections.Generic;
using System.Linq;

namespace net
{
    public class pts
    {
        public static void kshdf()
        {
            var solution = new pts();
            var root = solution.GetTree(new int?[] {5,4,8,11,null,13,4,7,2,null,null,5,1});
            solution.PrintGlobalList(solution.PathSum(root, 22));

            root = solution.GetTree(new int?[] {1, 2, 3});
            solution.PrintGlobalList(solution.PathSum(root, 5));
        }

        private void PrintGlobalList(IList<IList<int>> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Count; j++)
                    Console.Write($"{list[i][j]} ");
                Console.WriteLine();
            }
        }

        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            return PathSum2(root, targetSum, 0, new Stack<int>(), new List<IList<int>>());
        }

        private IList<IList<int>> PathSum2(TreeNode root, int targetSum, int sum, Stack<int> path,
            IList<IList<int>> main)
        {
            if (root == null) return new List<IList<int>>();

            path.Push(root.val);
            if (root.left == null && root.right == null && targetSum == sum + root.val)
                main.Add(new List<int>(path.Reverse()));

            if (root.left != null)
                PathSum2(root.left, targetSum, sum + root.val, path, main);

            if (root.right != null)
                PathSum2(root.right, targetSum, sum + root.val, path, main);

            path.Pop();
            return main;
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