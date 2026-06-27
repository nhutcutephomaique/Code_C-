using System;

namespace CSharpBasic22
{
    public class DoublyNode
    {
        public int Data;
        public DoublyNode Prev;
        public DoublyNode Next;

        public DoublyNode(int data)
        {
            Data = data;
            Prev = null;
            Next = null;
        }
    }

    public class DoublyLinkedList
    {
        public DoublyNode Head;
        public DoublyNode Tail;

        public void Add(int data)
        {
            DoublyNode newNode = new DoublyNode(data);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }

            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
        }

        public void AddAt(int index, int data)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            DoublyNode newNode = new DoublyNode(data);
            if (index == 0)
            {
                if (Head == null)
                {
                    Head = newNode;
                    Tail = newNode;
                }
                else
                {
                    newNode.Next = Head;
                    Head.Prev = newNode;
                    Head = newNode;
                }
                return;
            }

            DoublyNode current = Head;
            for (int i = 0; current != null && i < index; i++)
            {
                current = current.Next;
            }

            if (current == null)
            {
                Add(data);
                return;
            }

            DoublyNode prevNode = current.Prev;
            newNode.Next = current;
            newNode.Prev = prevNode;
            if (prevNode != null)
            {
                prevNode.Next = newNode;
            }
            else
            {
                Head = newNode;
            }
            current.Prev = newNode;
        }

        public void Remove(int data)
        {
            DoublyNode current = Head;
            while (current != null)
            {
                if (current.Data == data)
                {
                    if (current.Prev != null)
                    {
                        current.Prev.Next = current.Next;
                    }
                    else
                    {
                        Head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Prev = current.Prev;
                    }
                    else
                    {
                        Tail = current.Prev;
                    }
                    return;
                }
                current = current.Next;
            }
        }

        public bool Contains(int data)
        {
            DoublyNode current = Head;
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
            DoublyNode current = Head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}
