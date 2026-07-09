using System;
using System.Collections.Generic;

namespace CSharpBasic;

public class AvlTreeExample
{
    private class Node
    {
        public int Value;
        public Node Left;
        public Node Right;
        public int Height;
    }

    public void Run()
    {
        var tree = new AvlTree();
        var values = new[] { 30, 20, 40, 10, 25, 35, 50, 5, 15, 45, 60 };
        foreach (var value in values)
        {
            tree.Insert(value);
        }

        Console.WriteLine("In-order:");
        Console.WriteLine(string.Join(", ", tree.InOrder()));
        Console.WriteLine("Pre-order:");
        Console.WriteLine(string.Join(", ", tree.PreOrder()));
        Console.WriteLine("Height: " + tree.Height());
        Console.WriteLine("Contains 25: " + tree.Contains(25));
        Console.WriteLine("Contains 100: " + tree.Contains(100));

        tree.Delete(20);
        Console.WriteLine("After delete 20 in-order:");
        Console.WriteLine(string.Join(", ", tree.InOrder()));
    }

    private class AvlTree
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
            var node = _root;
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

        public int Height()
        {
            return GetHeight(_root);
        }

        public List<int> InOrder()
        {
            var result = new List<int>();
            TraverseInOrder(_root, result);
            return result;
        }

        public List<int> PreOrder()
        {
            var result = new List<int>();
            TraversePreOrder(_root, result);
            return result;
        }

        private Node Insert(Node node, int value)
        {
            if (node == null)
            {
                return new Node { Value = value, Height = 1 };
            }

            if (value < node.Value)
            {
                node.Left = Insert(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = Insert(node.Right, value);
            }
            else
            {
                return node;
            }

            UpdateHeight(node);
            return Balance(node);
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
                if (node.Left == null || node.Right == null)
                {
                    node = node.Left ?? node.Right;
                }
                else
                {
                    var successor = GetMin(node.Right);
                    node.Value = successor.Value;
                    node.Right = Delete(node.Right, successor.Value);
                }
            }

            if (node == null)
            {
                return null;
            }

            UpdateHeight(node);
            return Balance(node);
        }

        private Node GetMin(Node node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        private Node Balance(Node node)
        {
            var balance = GetBalance(node);
            if (balance > 1)
            {
                if (GetBalance(node.Left) < 0)
                {
                    node.Left = RotateLeft(node.Left);
                }
                return RotateRight(node);
            }

            if (balance < -1)
            {
                if (GetBalance(node.Right) > 0)
                {
                    node.Right = RotateRight(node.Right);
                }
                return RotateLeft(node);
            }

            return node;
        }

        private Node RotateRight(Node node)
        {
            var left = node.Left;
            node.Left = left.Right;
            left.Right = node;
            UpdateHeight(node);
            UpdateHeight(left);
            return left;
        }

        private Node RotateLeft(Node node)
        {
            var right = node.Right;
            node.Right = right.Left;
            right.Left = node;
            UpdateHeight(node);
            UpdateHeight(right);
            return right;
        }

        private void UpdateHeight(Node node)
        {
            node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        }

        private int GetHeight(Node node)
        {
            return node?.Height ?? 0;
        }

        private int GetBalance(Node node)
        {
            return GetHeight(node.Left) - GetHeight(node.Right);
        }

        private void TraverseInOrder(Node node, List<int> result)
        {
            if (node == null)
            {
                return;
            }
            TraverseInOrder(node.Left, result);
            result.Add(node.Value);
            TraverseInOrder(node.Right, result);
        }

        private void TraversePreOrder(Node node, List<int> result)
        {
            if (node == null)
            {
                return;
            }
            result.Add(node.Value);
            TraversePreOrder(node.Left, result);
            TraversePreOrder(node.Right, result);
        }
    }
}
