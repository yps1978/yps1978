using System;
using System.Collections.Generic;

namespace net
{
    public class ps2
    {
        public static void mps2n()
        {
            var solution = new ps2();
            var root = solution.GetTree(new int?[] {10, 5, -3, 3, 2, null, 11, 3, -2, null, 1});
            Console.WriteLine($"Expected: 3, Got: {solution.PathSum(root, 8)}");

            root = solution.GetTree(new int?[] {5, 4, 8, 11, null, 13, 4, 7, 2, null, null, 5, 1});
            Console.WriteLine($"Expected: 3, Got: {solution.PathSum(root, 22)}");

            root = solution.GetTree(new int?[] {1});
            Console.WriteLine($"Expected: 0, Got: {solution.PathSum(root, 0)}");

            root = solution.GetTree(new int?[] {-2, null, -3});
            Console.WriteLine($"Expected: 1, Got: {solution.PathSum(root, -3)}");

            root = solution.GetTree(new int?[] {1, -2, -3});
            Console.WriteLine($"Expected: 2, Got: {solution.PathSum(root, -2)}");

            root = solution.GetTree(new int?[] {1});
            Console.WriteLine($"Expected: 1, Got: {solution.PathSum(root, 1)}");
            
            root = solution.GetTree(new int?[] {0, 1, 1});
            Console.WriteLine($"Expected: 4, Got: {solution.PathSum(root, 1)}");

            root = solution.GetTree(new int?[] {1000000000,1000000000,null,294967296,null,1000000000,null,1000000000,null,1000000000});
            Console.WriteLine($"Expected: 0, Got: {solution.PathSum(root, 0)}");
        }

        public int PathSum(TreeNode root, int targetSum)
        {
            return PathSum2(root, targetSum, 0, new List<int>(), 0);
        }

        private int PathSum2(TreeNode root, int targetSum, long sum, List<int> path, int topIdx)
        {
            if (root == null) return 0;
            int count = 0;

            path.Add(root.val);
            sum += root.val;
            var auxSum = sum;
            for (int i = 0; i < path.Count; i++)
            {
                if (targetSum == auxSum)
                    count++;
                auxSum -= path[i];
            }

            if (root.left != null)
                count += PathSum2(root.left, targetSum, sum, path, topIdx);

            if (topIdx > 0 && targetSum < sum + path[topIdx - 1])
                topIdx--;

            if (root.right != null)
                count += PathSum2(root.right, targetSum, sum, path, topIdx);

            path.RemoveAt(path.Count - 1);

            return count;
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
                        if (i == arr.Length)
                            break;
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