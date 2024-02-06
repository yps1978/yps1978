using System;
using System.Collections.Generic;

namespace net
{
    public class trie
    {
        public class Node
        {
            public Dictionary<char, Node> children;
            public string value;
            public bool leaf = true;
        }

        public static void triemain()
        {
            var solution = new trie();
            Node root = new Node();
            solution.insert(root, "yasel", "efiu-sniff");
            solution.insert(root, "yaselin", "in-efiu");
            solution.insert(root, "yaselon", "on-efiu");
            solution.insert(root, "yaselan", "an-efiu");
            solution.insert(root, "liaydis", "xyz");
            solution.insert(root, "yas", "short-yas");
            Console.WriteLine(solution.search(root, "liaydis"));
            Console.WriteLine(solution.search(root, "yaselon"));
            Console.WriteLine(solution.search(root, "yaselin"));
            Console.WriteLine(solution.search(root, "yasel"));
            Console.WriteLine(solution.search(root, "yas"));
            // solution.delete(root, "liaydis");
            Console.WriteLine(solution.search(root, "liaydis"));
            // solution.delete(root, "yas");
            Console.WriteLine(solution.search(root, "yas"));
            Console.WriteLine(solution.search(root, "yasel"));
            Console.WriteLine(solution.search(root, "yaselon"));
            Console.WriteLine(solution.search(root, "yaselin"));
            solution.display(root, "");
        }

        public void display(Node root, string keyPath)
        {
            if (root == null)
                return;

            if (root.value != null)
                Console.WriteLine($"key:{keyPath}, value:{root.value}");

            if (root.children != null)
                foreach (var node in root.children)
                    display(node.Value, keyPath + node.Key);
        }

        public void insert(Node node, string key, string value)
        {
            for (int i = 0; i < key.Length; i++)
            {
                node.children ??= new Dictionary<char, Node>();
                if (!node.children.ContainsKey(key[i]))
                    node.children[key[i]] = new Node();

                node.leaf = false;
                node = node.children[key[i]];
            }

            node.value = value;
        }

        public string search(Node node, string key)
        {
            for (int i = 0; i < key.Length; i++)
            {
                if (!node.children.ContainsKey(key[i])) return null;

                node = node.children[key[i]];
            }

            return node.value;
        }

        public void delete(Node node, string key)
        {
            Stack<Tuple<char, Node>> trace = new Stack<Tuple<char, Node>>();
            for (int i = 0; i < key.Length; i++)
            {
                if (node.children[key[i]] == null) return;

                trace.Push(Tuple.Create(key[i], node));
                node = node.children[key[i]];
            }

            if (node.leaf)
                while (trace.Count > 0)
                {
                    var (localChar, localNode) = trace.Pop();
                    localNode.children.Remove(localChar);
                    if (localNode.children.Count > 0)
                        break;
                }
            else node.value = null;
        }
    }
}