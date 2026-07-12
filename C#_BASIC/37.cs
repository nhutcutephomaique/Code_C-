using System;
using System.Collections.Generic;

namespace CSharpBasic;

// Bài tổng hợp DSA: tìm kiếm, sắp xếp, danh sách liên kết, ngăn xếp, hàng đợi và cây nhị phân.
public class ListNode
{
    public int Value;
    public ListNode? Next;

    public ListNode(int value)
    {
        Value = value;
        Next = null;
    }
}

public class SinglyLinkedList
{
    public ListNode? Head;

    public void AddLast(int value)
    {
        var newNode = new ListNode(value);
        if (Head == null)
        {
            Head = newNode;
            return;
        }

        var current = Head;
        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = newNode;
    }

    public bool Remove(int value)
    {
        if (Head == null)
        {
            return false;
        }

        if (Head.Value == value)
        {
            Head = Head.Next;
            return true;
        }

        var previous = Head;
        var current = Head.Next;
        while (current != null)
        {
            if (current.Value == value)
            {
                previous.Next = current.Next;
                return true;
            }
            previous = current;
            current = current.Next;
        }

        return false;
    }

    public void Reverse()
    {
        ListNode? previous = null;
        var current = Head;
        while (current != null)
        {
            var next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }

        Head = previous;
    }

    public List<int> ToList()
    {
        var result = new List<int>();
        var current = Head;
        while (current != null)
        {
            result.Add(current.Value);
            current = current.Next;
        }

        return result;
    }
}

public class Stack<T>
{
    private readonly List<T> items = new();

    public void Push(T item)
    {
        items.Add(item);
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        var index = items.Count - 1;
        var item = items[index];
        items.RemoveAt(index);
        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        return items[^1];
    }

    public bool IsEmpty()
    {
        return items.Count == 0;
    }
}

public class Queue<T>
{
    private readonly LinkedList<T> items = new();

    public void Enqueue(T item)
    {
        items.AddLast(item);
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var value = items.First!.Value;
        items.RemoveFirst();
        return value;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        return items.First!.Value;
    }

    public bool IsEmpty()
    {
        return items.Count == 0;
    }
}

public class TreeNodeExample37
{
    public int Value;
    public TreeNodeExample37? Left;
    public TreeNodeExample37? Right;

    public TreeNodeExample37(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinarySearchTreeExample37
{
    public TreeNodeExample37? Root;

    public void Insert(int value)
    {
        Root = Insert(Root, value);
    }

    private TreeNodeExample37 Insert(TreeNodeExample37? node, int value)
    {
        if (node == null)
        {
            return new TreeNodeExample37(value);
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

    private bool Search(TreeNodeExample37? node, int value)
    {
        if (node == null)
        {
            return false;
        }

        if (node.Value == value)
        {
            return true;
        }

        return value < node.Value ? Search(node.Left, value) : Search(node.Right, value);
    }

    public void InOrder(TreeNodeExample37? node, List<int> result)
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

public static class DsaAlgorithms
{
    public static int LinearSearch(int[] array, int target)
    {
        for (var i = 0; i < array.Length; i++)
        {
            if (array[i] == target)
            {
                return i;
            }
        }

        return -1;
    }

    public static int BinarySearch(int[] array, int target)
    {
        var left = 0;
        var right = array.Length - 1;

        while (left <= right)
        {
            var middle = (left + right) / 2;
            if (array[middle] == target)
            {
                return middle;
            }

            if (array[middle] < target)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return -1;
    }

    public static void BubbleSort(int[] array)
    {
        for (var i = 0; i < array.Length - 1; i++)
        {
            for (var j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(array, j, j + 1);
                }
            }
        }
    }

    public static void QuickSort(int[] array)
    {
        QuickSort(array, 0, array.Length - 1);
    }

    private static void QuickSort(int[] array, int left, int right)
    {
        if (left >= right)
        {
            return;
        }

        var pivotIndex = Partition(array, left, right);
        QuickSort(array, left, pivotIndex - 1);
        QuickSort(array, pivotIndex + 1, right);
    }

    private static int Partition(int[] array, int left, int right)
    {
        var pivot = array[right];
        var storeIndex = left;

        for (var i = left; i < right; i++)
        {
            if (array[i] < pivot)
            {
                Swap(array, i, storeIndex);
                storeIndex++;
            }
        }

        Swap(array, storeIndex, right);
        return storeIndex;
    }

    public static void MergeSort(int[] array)
    {
        if (array.Length <= 1)
        {
            return;
        }

        var middle = array.Length / 2;
        var left = new int[middle];
        var right = new int[array.Length - middle];

        Array.Copy(array, 0, left, 0, middle);
        Array.Copy(array, middle, right, 0, right.Length);

        MergeSort(left);
        MergeSort(right);
        Merge(array, left, right);
    }

    private static void Merge(int[] array, int[] left, int[] right)
    {
        var i = 0;
        var j = 0;
        var k = 0;

        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                array[k++] = left[i++];
            }
            else
            {
                array[k++] = right[j++];
            }
        }

        while (i < left.Length)
        {
            array[k++] = left[i++];
        }

        while (j < right.Length)
        {
            array[k++] = right[j++];
        }
    }

    private static void Swap(int[] array, int a, int b)
    {
        var temp = array[a];
        array[a] = array[b];
        array[b] = temp;
    }
}

public class DsaDemo
{
    public static void Run()
    {
        var numbers = new[] { 7, 3, 9, 1, 5, 2, 8 };
        Console.WriteLine("Original: " + string.Join(", ", numbers));

        var sorted = (int[])numbers.Clone();
        DsaAlgorithms.QuickSort(sorted);
        Console.WriteLine("QuickSort: " + string.Join(", ", sorted));

        var mergeSorted = (int[])numbers.Clone();
        DsaAlgorithms.MergeSort(mergeSorted);
        Console.WriteLine("MergeSort: " + string.Join(", ", mergeSorted));

        var foundIndex = DsaAlgorithms.LinearSearch(numbers, 5);
        Console.WriteLine("LinearSearch 5: " + foundIndex);

        var foundBinary = DsaAlgorithms.BinarySearch(mergeSorted, 5);
        Console.WriteLine("BinarySearch 5: " + foundBinary);

        var list = new SinglyLinkedList();
        foreach (var value in numbers)
        {
            list.AddLast(value);
        }

        Console.WriteLine("LinkedList: " + string.Join(", ", list.ToList()));
        list.Reverse();
        Console.WriteLine("Reversed LinkedList: " + string.Join(", ", list.ToList()));

        var stack = new Stack<int>();
        foreach (var value in numbers)
        {
            stack.Push(value);
        }

        Console.WriteLine("Stack Pop: " + stack.Pop());

        var queue = new Queue<int>();
        foreach (var value in numbers)
        {
            queue.Enqueue(value);
        }

        Console.WriteLine("Queue Dequeue: " + queue.Dequeue());

        var bst = new BinarySearchTree();
        foreach (var value in numbers)
        {
            bst.Insert(value);
        }

        var inOrder = new List<int>();
        bst.InOrder(bst.Root, inOrder);
        Console.WriteLine("BST InOrder: " + string.Join(", ", inOrder));
    }
}
