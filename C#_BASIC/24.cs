using System;

namespace CSharpBasic24
{
    public class CircularDoublyNode
    {
        public int Data;
        public CircularDoublyNode Prev;
        public CircularDoublyNode Next;

        public CircularDoublyNode(int data)
        {
            Data = data;
            Prev = null;
            Next = null;
        }
    }

    public class CircularDoublyLinkedList
    {
        public CircularDoublyNode Head;

        public void Add(int data)
        {
            CircularDoublyNode newNode = new CircularDoublyNode(data);
            if (Head == null)
            {
                Head = newNode;
                Head.Prev = Head;
                Head.Next = Head;
                return;
            }

            CircularDoublyNode tail = Head.Prev;
            tail.Next = newNode;
            newNode.Prev = tail;
            newNode.Next = Head;
            Head.Prev = newNode;
        }

        public void AddAt(int index, int data)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            CircularDoublyNode newNode = new CircularDoublyNode(data);
            if (Head == null)
            {
                Head = newNode;
                Head.Prev = Head;
                Head.Next = Head;
                return;
            }

            if (index == 0)
            {
                CircularDoublyNode tail = Head.Prev;
                newNode.Next = Head;
                newNode.Prev = tail;
                tail.Next = newNode;
                Head.Prev = newNode;
                Head = newNode;
                return;
            }

            CircularDoublyNode current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
                if (current == Head)
                {
                    break;
                }
            }

            if (current == Head && index > 0)
            {
                Add(data);
                return;
            }

            CircularDoublyNode prevNode = current.Prev;
            prevNode.Next = newNode;
            newNode.Prev = prevNode;
            newNode.Next = current;
            current.Prev = newNode;
        }

        public void Remove(int data)
        {
            if (Head == null)
            {
                return;
            }

            CircularDoublyNode current = Head;
            do
            {
                if (current.Data == data)
                {
                    if (current.Next == current)
                    {
                        Head = null;
                        return;
                    }

                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                    if (current == Head)
                    {
                        Head = current.Next;
                    }
                    return;
                }
                current = current.Next;
            }
            while (current != Head);
        }

        public bool Contains(int data)
        {
            if (Head == null)
            {
                return false;
            }

            CircularDoublyNode current = Head;
            do
            {
                if (current.Data == data)
                {
                    return true;
                }
                current = current.Next;
            }
            while (current != Head);

            return false;
        }

        public void Print()
        {
            if (Head == null)
            {
                Console.WriteLine();
                return;
            }

            CircularDoublyNode current = Head;
            do
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            while (current != Head);
            Console.WriteLine();
        }
    }
}
