using System;

class LinkedListProgram
{
    class Node
    {
        public int Value;
        public Node Next;
        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    static Node Append(Node head, int value)
    {
        Node newNode = new Node(value);
        if (head == null)
            return newNode;
        Node current = head;
        while (current.Next != null)
            current = current.Next;
        current.Next = newNode;
        return head;
    }

    static void PrintList(Node head)
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Value + (current.Next != null ? " " : ""));
            current = current.Next;
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Node head = null;
        head = Append(head, 3);
        head = Append(head, 7);
        head = Append(head, 9);
        head = Append(head, 1);
        head = Append(head, 5);
        PrintList(head);
    }
}
