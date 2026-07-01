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

public class BinaryTree
{
    public void InOrder(TreeNode? node, List<int> result)
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
