using System;

namespace CSharpBasic21
{
    public class Node
    {
        public int Data;
        public Node Next;

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    public class SinglyLinkedList
    {
        public Node Head;

        public void Add(int data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
                return;
            }

            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        public void AddAt(int index, int data)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Node newNode = new Node(data);
            if (index == 0)
            {
                newNode.Next = Head;
                Head = newNode;
                return;
            }

            Node current = Head;
            for (int i = 0; current != null && i < index - 1; i++)
            {
                current = current.Next;
            }

            if (current == null)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }

        public void Remove(int data)
        {
            if (Head == null)
            {
                return;
            }

            if (Head.Data == data)
            {
                Head = Head.Next;
                return;
            }

            Node current = Head;
            while (current.Next != null && current.Next.Data != data)
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
            }
        }

        public bool Contains(int data)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.Data == data)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Print()
        {
            Node current = Head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}
