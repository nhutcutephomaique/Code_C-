using System;
using System.Collections.Generic;

namespace CSharpBasic;

public class TreeNodeExample36
{
    public int Value;
    public TreeNodeExample36? Left;
    public TreeNodeExample36? Right;

    public TreeNodeExample36(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinaryTreeExample36
{
    public void InOrder(TreeNodeExample36? node, List<int> result)
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
