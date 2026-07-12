using System;
using System.Collections.Generic;

namespace CSharpBasic;

public class TreeNodeExample35
{
    public int Value;
    public TreeNodeExample35? Left;
    public TreeNodeExample35? Right;

    public TreeNodeExample35(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinaryTreeExample35
{
    public void PreOrder(TreeNodeExample35? node, List<int> result)
    {
        if (node == null)
        {
            return;
        }

        result.Add(node.Value);
        PreOrder(node.Left, result);
        PreOrder(node.Right, result);
    }
}
