using System;

class LinkedListMemoryProgram
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

    static void PrintMemory(Node head)
    {
        Node current = head;
        while (current != null)
        {
            Console.WriteLine($"Node {current.GetHashCode()}: Value={current.Value}, Next={(current.Next != null ? current.Next.GetHashCode().ToString() : "null")}");
            current = current.Next;
        }
    }

    static void Main()
    {
        Node head = null;
        head = Append(head, 10);
        head = Append(head, 20);
        head = Append(head, 30);
        head = Append(head, 40);
        PrintMemory(head);
    }
}
