using System;
using System.Collections.Generic;

namespace CSharpBasic;

public class TreeNode
{
    public int Value;
    public TreeNode? Left;
    public TreeNode? Right;

    public TreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinarySearchTree
{
    public TreeNode? Root;

    public void Insert(int value)
    {
        Root = Insert(Root, value);
    }

    private TreeNode? Insert(TreeNode? node, int value)
    {
        if (node == null)
        {
            return new TreeNode(value);
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

    public bool Search(int value)
    {
        return Search(Root, value);
    }

    private bool Search(TreeNode? node, int value)
    {
        if (node == null)
        {
            return false;
        }

        if (value == node.Value)
        {
            return true;
        }

        return value < node.Value ? Search(node.Left, value) : Search(node.Right, value);
    }

    public void PreOrder(List<int> result)
    {
        PreOrder(Root, result);
    }

    private void PreOrder(TreeNode? node, List<int> result)
    {
        if (node == null)
        {
            return;
        }

        result.Add(node.Value);
        PreOrder(node.Left, result);
        PreOrder(node.Right, result);
    }

    public void InOrder(List<int> result)
    {
        InOrder(Root, result);
    }

    private void InOrder(TreeNode? node, List<int> result)
    {
        if (node == null)
        {
            return;
        }

        InOrder(node.Left, result);
        result.Add(node.Value);
        InOrder(node.Right, result);
    }

    public void PostOrder(List<int> result)
    {
        PostOrder(Root, result);
    }

    private void PostOrder(TreeNode? node, List<int> result)
    {
        if (node == null)
        {
            return;
        }

        PostOrder(node.Left, result);
        PostOrder(node.Right, result);
        result.Add(node.Value);
    }

    public bool Delete(int value)
    {
        var result = Delete(Root, value);
        Root = result.Root;
        return result.Deleted;
    }

    private (TreeNode? Root, bool Deleted) Delete(TreeNode? node, int value)
    {
        if (node == null)
        {
            return (null, false);
        }

        if (value < node.Value)
        {
            var result = Delete(node.Left, value);
            node.Left = result.Root;
            return (node, result.Deleted);
        }

        if (value > node.Value)
        {
            var result = Delete(node.Right, value);
            node.Right = result.Root;
            return (node, result.Deleted);
        }

        if (node.Left == null && node.Right == null)
        {
            return (null, true);
        }

        if (node.Left == null)
        {
            return (node.Right, true);
        }

        if (node.Right == null)
        {
            return (node.Left, true);
        }

        var successor = FindMin(node.Right);
        node.Value = successor.Value;
        var rightResult = Delete(node.Right, successor.Value);
        node.Right = rightResult.Root;
        return (node, true);
    }

    private TreeNode FindMin(TreeNode node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }

        return node;
    }
}

public class TreeDemo
{
    public static void Run()
    {
        var tree = new BinarySearchTree();
        int[] values = { 50, 30, 70, 20, 40, 60, 80 };

        foreach (var value in values)
        {
            tree.Insert(value);
        }

        var preOrder = new List<int>();
        var inOrder = new List<int>();
        var postOrder = new List<int>();

        tree.PreOrder(preOrder);
        tree.InOrder(inOrder);
        tree.PostOrder(postOrder);

        Console.WriteLine(string.Join(" ", preOrder));
        Console.WriteLine(string.Join(" ", inOrder));
        Console.WriteLine(string.Join(" ", postOrder));
        Console.WriteLine(tree.Search(40));
        Console.WriteLine(tree.Delete(20));
    }
}
