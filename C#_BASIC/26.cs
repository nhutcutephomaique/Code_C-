using System;

namespace CSharpBasic26
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

        public void InsertAtBeginning(int data)
        {
            DoublyNode newNode = new DoublyNode(data);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }

            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
        }

        public void InsertAtEnd(int data)
        {
            DoublyNode newNode = new DoublyNode(data);
            if (Tail == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }

            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
        }

        public void InsertAtPosition(int position, int data)
        {
            if (position <= 0)
            {
                InsertAtBeginning(data);
                return;
            }

            DoublyNode current = Head;
            int index = 0;
            while (current != null && index < position - 1)
            {
                current = current.Next;
                index++;
            }

            if (current == null)
            {
                InsertAtEnd(data);
                return;
            }

            DoublyNode newNode = new DoublyNode(data);
            newNode.Next = current.Next;
            if (current.Next != null)
            {
                current.Next.Prev = newNode;
            }
            else
            {
                Tail = newNode;
            }
            current.Next = newNode;
            newNode.Prev = current;
        }

        public void DeleteAtBeginning()
        {
            if (Head == null)
            {
                return;
            }

            Head = Head.Next;
            if (Head != null)
            {
                Head.Prev = null;
            }
            else
            {
                Tail = null;
            }
        }

        public void DeleteAtEnd()
        {
            if (Tail == null)
            {
                return;
            }

            Tail = Tail.Prev;
            if (Tail != null)
            {
                Tail.Next = null;
            }
            else
            {
                Head = null;
            }
        }

        public void DeleteAtPosition(int position)
        {
            if (Head == null || position < 0)
            {
                return;
            }

            if (position == 0)
            {
                DeleteAtBeginning();
                return;
            }

            DoublyNode current = Head;
            int index = 0;
            while (current != null && index < position)
            {
                current = current.Next;
                index++;
            }

            if (current == null)
            {
                return;
            }

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
        }

        public void Traverse()
        {
            DoublyNode current = Head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
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
    }
}
