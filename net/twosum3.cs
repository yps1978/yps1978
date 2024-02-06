using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace net
{
    public class tws3
    {
        public static void mnska()
        {
            var solution = new tws3();
            var root = solution.GetTree(new int?[] {5, 3, 6, 2, 4, null, 7});
            Console.WriteLine($"Expected: true, Got: {solution.FindTarget(root, 9)}");

            root = solution.GetTree(new int?[] {5, 3, 6, 2, 4, null, 7});
            Console.WriteLine($"Expected: false, Got: {solution.FindTarget(root, 28)}");

            root = solution.GetTree(new int?[] {2, 0, 3, -4, 1});
            Console.WriteLine($"Expected: true, Got: {solution.FindTarget(root, -1)}");

            root = solution.GetTree(new int?[] {1, 0, 4, -2, null, 3});
            Console.WriteLine($"Expected: true, Got: {solution.FindTarget(root, 7)}");

            root = solution.GetTree(new int?[] {2, null, 3});
            Console.WriteLine($"Expected: false, Got: {solution.FindTarget(root, 6)}");

            root = solution.GetTree(new int?[] {2, 0, 3, -1, 1});
            Console.WriteLine($"Expected: true, Got: {solution.FindTarget(root, -1)}");
        }

        public bool FindTarget(TreeNode root, int k)
        {
            var elements = PopulateList(root);
            return TwoSum(elements, k);
        }

        public bool TwoSum(List<int> elements, int k)
        {
            int p1 = 0, p2 = elements.Count - 1;
            while (p1 < p2)
            {
                if (elements[p1] + elements[p2] == k)
                    return true;

                if (k - elements[p1] < elements[p2])
                    p2--;
                else p1++;
            }

            return false;
        }

        public List<int> PopulateList(TreeNode node)
        {
            if (node == null)
                return null;

            var result = new List<int>();
            var subList = PopulateList(node.left);
            if (subList != null) result.AddRange(subList);

            result.Add(node.val);

            subList = PopulateList(node.right);
            if (subList != null)
                result.AddRange(subList);

            return result;
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