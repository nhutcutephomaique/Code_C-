using System;

namespace CSharpBasic25
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

        public void InsertAtEnd(int data)
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

        public void InsertAtBeginning(int data)
        {
            Node newNode = new Node(data);
            newNode.Next = Head;
            Head = newNode;
        }

        public void InsertAtPosition(int position, int data)
        {
            if (position < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }

            Node newNode = new Node(data);
            if (position == 0)
            {
                newNode.Next = Head;
                Head = newNode;
                return;
            }

            Node current = Head;
            for (int i = 0; current != null && i < position - 1; i++)
            {
                current = current.Next;
            }

            if (current == null)
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }

        public void DeleteAtBeginning()
        {
            if (Head != null)
            {
                Head = Head.Next;
            }
        }

        public void DeleteAtEnd()
        {
            if (Head == null)
            {
                return;
            }

            if (Head.Next == null)
            {
                Head = null;
                return;
            }

            Node current = Head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            current.Next = null;
        }

        public void DeleteAtPosition(int position)
        {
            if (Head == null || position < 0)
            {
                return;
            }

            if (position == 0)
            {
                Head = Head.Next;
                return;
            }

            Node current = Head;
            for (int i = 0; current != null && i < position - 1; i++)
            {
                current = current.Next;
            }

            if (current == null || current.Next == null)
            {
                return;
            }

            current.Next = current.Next.Next;
        }

        public void Traverse()
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
