using System;

namespace CSharpBasic29
{
    public class QueueArray
    {
        private int[] items;
        private int front;
        private int rear;

        public QueueArray(int capacity)
        {
            items = new int[capacity];
            front = 0;
            rear = -1;
        }

        public void Enqueue(int data)
        {
            if (rear == items.Length - 1)
            {
                throw new InvalidOperationException();
            }
            items[++rear] = data;
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return items[front++];
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return items[front];
        }

        public bool IsEmpty()
        {
            return rear < front;
        }

        public int Size()
        {
            return rear - front + 1;
        }
    }
}
