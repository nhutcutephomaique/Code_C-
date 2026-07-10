using System;
using System.Collections.Generic;

namespace CSharpBasic;

public class BinaryTreeAdvancedDemo
{
    private class Node
    {
        public int Value;
        public Node Left;
        public Node Right;
    }

    private class BinarySearchTree
    {
        private Node _root;

        public void Insert(int value)
        {
            _root = Insert(_root, value);
        }

        public void Delete(int value)
        {
            _root = Delete(_root, value);
        }

        public bool Contains(int value)
        {
            return Contains(_root, value);
        }

        public int Height()
        {
            return Height(_root);
        }

        public List<int> InOrder()
        {
            var result = new List<int>();
            InOrder(_root, result);
            return result;
        }

        public List<int> PreOrder()
        {
            var result = new List<int>();
            PreOrder(_root, result);
            return result;
        }

        public List<int> PostOrder()
        {
            var result = new List<int>();
            PostOrder(_root, result);
            return result;
        }

        public List<int> LevelOrder()
        {
            var result = new List<int>();
            if (_root == null)
            {
                return result;
            }

            var queue = new Queue<Node>();
            queue.Enqueue(_root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                result.Add(node.Value);

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }

            return result;
        }

        public bool IsBalanced()
        {
            return IsBalanced(_root, out _);
        }

        public int Diameter()
        {
            return Diameter(_root, out _);
        }

        public int LowestCommonAncestor(int first, int second)
        {
            var node = LowestCommonAncestor(_root, first, second);
            return node?.Value ?? -1;
        }

        private Node Insert(Node node, int value)
        {
            if (node == null)
            {
                return new Node { Value = value };
            }

            if (value < node.Value)
            {
                node.Left = Insert(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = Insert(node.Right, value);
            }

            return node;
        }

        private Node Delete(Node node, int value)
        {
            if (node == null)
            {
                return null;
            }

            if (value < node.Value)
            {
                node.Left = Delete(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = Delete(node.Right, value);
            }
            else
            {
                if (node.Left == null)
                {
                    return node.Right;
                }

                if (node.Right == null)
                {
                    return node.Left;
                }

                var minNode = FindMin(node.Right);
                node.Value = minNode.Value;
                node.Right = Delete(node.Right, minNode.Value);
            }

            return node;
        }

        private bool Contains(Node node, int value)
        {
            while (node != null)
            {
                if (value < node.Value)
                {
                    node = node.Left;
                }
                else if (value > node.Value)
                {
                    node = node.Right;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        private int Height(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        private void InOrder(Node node, List<int> result)
        {
            if (node == null)
            {
                return;
            }

            InOrder(node.Left, result);
            result.Add(node.Value);
            InOrder(node.Right, result);
        }

        private void PreOrder(Node node, List<int> result)
        {
            if (node == null)
            {
                return;
            }

            result.Add(node.Value);
            PreOrder(node.Left, result);
            PreOrder(node.Right, result);
        }

        private void PostOrder(Node node, List<int> result)
        {
            if (node == null)
            {
                return;
            }

            PostOrder(node.Left, result);
            PostOrder(node.Right, result);
            result.Add(node.Value);
        }

        private bool IsBalanced(Node node, out int height)
        {
            if (node == null)
            {
                height = 0;
                return true;
            }

            if (!IsBalanced(node.Left, out var leftHeight) || !IsBalanced(node.Right, out var rightHeight))
            {
                height = 0;
                return false;
            }

            height = 1 + Math.Max(leftHeight, rightHeight);
            return Math.Abs(leftHeight - rightHeight) <= 1;
        }

        private int Diameter(Node node, out int height)
        {
            if (node == null)
            {
                height = 0;
                return 0;
            }

            var leftDiameter = Diameter(node.Left, out var leftHeight);
            var rightDiameter = Diameter(node.Right, out var rightHeight);
            height = 1 + Math.Max(leftHeight, rightHeight);
            return Math.Max(Math.Max(leftDiameter, rightDiameter), leftHeight + rightHeight);
        }

        private Node LowestCommonAncestor(Node node, int first, int second)
        {
            if (node == null)
            {
                return null;
            }

            if (first < node.Value && second < node.Value)
            {
                return LowestCommonAncestor(node.Left, first, second);
            }

            if (first > node.Value && second > node.Value)
            {
                return LowestCommonAncestor(node.Right, first, second);
            }

            return node;
        }

        private Node FindMin(Node node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }
    }

    public void Run()
    {
        var tree = new BinarySearchTree();
        var values = new[] { 50, 30, 70, 20, 40, 60, 80, 10, 25, 35, 45, 55, 65, 75, 85 };

        foreach (var value in values)
        {
            tree.Insert(value);
        }

        Console.WriteLine("In Order: " + string.Join(", ", tree.InOrder()));
        Console.WriteLine("Pre Order: " + string.Join(", ", tree.PreOrder()));
        Console.WriteLine("Post Order: " + string.Join(", ", tree.PostOrder()));
        Console.WriteLine("Level Order: " + string.Join(", ", tree.LevelOrder()));
        Console.WriteLine("Height: " + tree.Height());
        Console.WriteLine("Balanced: " + tree.IsBalanced());
        Console.WriteLine("Diameter: " + tree.Diameter());
        Console.WriteLine("Contains 55: " + tree.Contains(55));
        Console.WriteLine("Contains 99: " + tree.Contains(99));
        Console.WriteLine("LCA 20 and 45: " + tree.LowestCommonAncestor(20, 45));

        tree.Delete(30);
        Console.WriteLine("After delete 30: " + string.Join(", ", tree.InOrder()));
    }
}
