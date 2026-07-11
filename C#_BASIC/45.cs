using System;
using System.Collections.Generic;

namespace CSharpBasic;

public class AvlTreeAdvancedDemo
{
    private class Node
    {
        public int Value;
        public Node Left;
        public Node Right;
        public int Height;
        public int Size;
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
            return Contains(_root, value);
        }

        public int Height()
        {
            return _root?.Height ?? 0;
        }

        public int Size()
        {
            return _root?.Size ?? 0;
        }

        public int Rank(int value)
        {
            return Rank(_root, value);
        }

        public int Kth(int k)
        {
            var node = Kth(_root, k);
            return node?.Value ?? -1;
        }

        public int LowerBound(int value)
        {
            var node = LowerBound(_root, value);
            return node?.Value ?? -1;
        }

        public int UpperBound(int value)
        {
            var node = UpperBound(_root, value);
            return node?.Value ?? -1;
        }

        public List<int> InOrder()
        {
            var result = new List<int>();
            InOrder(_root, result);
            return result;
        }

        private Node Insert(Node node, int value)
        {
            if (node == null)
            {
                return new Node { Value = value, Height = 1, Size = 1 };
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

            return Balance(Update(node));
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

                var successor = Min(node.Right);
                node.Value = successor.Value;
                node.Right = Delete(node.Right, successor.Value);
            }

            return Balance(Update(node));
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

        private int Rank(Node node, int value)
        {
            if (node == null)
            {
                return 0;
            }

            if (value <= node.Value)
            {
                return Rank(node.Left, value);
            }

            return GetSize(node.Left) + 1 + Rank(node.Right, value);
        }

        private Node Kth(Node node, int k)
        {
            if (node == null || k <= 0 || k > GetSize(node))
            {
                return null;
            }

            var leftSize = GetSize(node.Left);
            if (k <= leftSize)
            {
                return Kth(node.Left, k);
            }

            if (k == leftSize + 1)
            {
                return node;
            }

            return Kth(node.Right, k - leftSize - 1);
        }

        private Node LowerBound(Node node, int value)
        {
            Node result = null;
            while (node != null)
            {
                if (node.Value >= value)
                {
                    result = node;
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            return result;
        }

        private Node UpperBound(Node node, int value)
        {
            Node result = null;
            while (node != null)
            {
                if (node.Value > value)
                {
                    result = node;
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            return result;
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

        private Node RotateRight(Node y)
        {
            var x = y.Left;
            var t = x.Right;
            x.Right = y;
            y.Left = t;
            y = Update(y);
            return Update(x);
        }

        private Node RotateLeft(Node x)
        {
            var y = x.Right;
            var t = y.Left;
            y.Left = x;
            x.Right = t;
            x = Update(x);
            return Update(y);
        }

        private Node Update(Node node)
        {
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
            node.Size = 1 + GetSize(node.Left) + GetSize(node.Right);
            return node;
        }

        private int GetHeight(Node node)
        {
            return node?.Height ?? 0;
        }

        private int GetSize(Node node)
        {
            return node?.Size ?? 0;
        }

        private int GetBalance(Node node)
        {
            return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        }

        private Node Min(Node node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
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
    }

    public void Run()
    {
        var tree = new AvlTree();
        var values = new[] { 40, 20, 60, 10, 30, 50, 70, 5, 15, 25, 35, 45, 55, 65, 75 };

        foreach (var value in values)
        {
            tree.Insert(value);
        }

        Console.WriteLine("InOrder: " + string.Join(", ", tree.InOrder()));
        Console.WriteLine("Height: " + tree.Height());
        Console.WriteLine("Size: " + tree.Size());
        Console.WriteLine("Contains 25: " + tree.Contains(25));
        Console.WriteLine("Contains 100: " + tree.Contains(100));
        Console.WriteLine("Rank of 45: " + tree.Rank(45));
        Console.WriteLine("3rd element: " + tree.Kth(3));
        Console.WriteLine("LowerBound 33: " + tree.LowerBound(33));
        Console.WriteLine("UpperBound 33: " + tree.UpperBound(33));

        tree.Delete(20);
        tree.Delete(60);

        Console.WriteLine("After delete: " + string.Join(", ", tree.InOrder()));
        Console.WriteLine("Height after delete: " + tree.Height());
        Console.WriteLine("Size after delete: " + tree.Size());
    }
}
