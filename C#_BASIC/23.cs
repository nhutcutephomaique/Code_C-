using System;

namespace CSharpBasic23
{
    public class CircularNode
    {
        public int Data;
        public CircularNode Next;

        public CircularNode(int data)
        {
            Data = data;
            Next = null;
        }
    }

    public class CircularSinglyLinkedList
    {
        public CircularNode Head;

        public void Add(int data)
        {
            CircularNode newNode = new CircularNode(data);
            if (Head == null)
            {
                Head = newNode;
                Head.Next = Head;
                return;
            }

            CircularNode current = Head;
            while (current.Next != Head)
            {
                current = current.Next;
            }

            current.Next = newNode;
            newNode.Next = Head;
        }

        public void AddAt(int index, int data)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            CircularNode newNode = new CircularNode(data);
            if (Head == null)
            {
                Head = newNode;
                Head.Next = Head;
                return;
            }

            if (index == 0)
            {
                CircularNode current = Head;
                while (current.Next != Head)
                {
                    current = current.Next;
                }

                newNode.Next = Head;
                current.Next = newNode;
                Head = newNode;
                return;
            }

            CircularNode previous = Head;
            for (int i = 0; i < index - 1; i++)
            {
                previous = previous.Next;
                if (previous == Head)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
            }

            newNode.Next = previous.Next;
            previous.Next = newNode;
        }

        public void Remove(int data)
        {
            if (Head == null)
            {
                return;
            }

            CircularNode current = Head;
            CircularNode previous = null;

            do
            {
                if (current.Data == data)
                {
                    if (previous == null)
                    {
                        if (current.Next == Head)
                        {
                            Head = null;
                        }
                        else
                        {
                            CircularNode last = Head;
                            while (last.Next != Head)
                            {
                                last = last.Next;
                            }
                            last.Next = current.Next;
                            Head = current.Next;
                        }
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }
                    return;
                }

                previous = current;
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

            CircularNode current = Head;
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

            CircularNode current = Head;
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
