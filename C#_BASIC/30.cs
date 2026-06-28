using System;

namespace CSharpBasic30
{
    public class QueueNode
    {
        public int Data;
        public QueueNode Next;

        public QueueNode(int data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedListQueue
    {
        private QueueNode front;
        private QueueNode rear;

        public void Enqueue(int data)
        {
            QueueNode newNode = new QueueNode(data);
            if (rear == null)
            {
                front = newNode;
                rear = newNode;
                return;
            }

            rear.Next = newNode;
            rear = newNode;
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            int value = front.Data;
            front = front.Next;
            if (front == null)
            {
                rear = null;
            }
            return value;
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return front.Data;
        }

        public bool IsEmpty()
        {
            return front == null;
        }

        public int Size()
        {
            int count = 0;
            QueueNode current = front;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}
