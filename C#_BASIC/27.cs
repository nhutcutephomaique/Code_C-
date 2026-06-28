using System;

namespace CSharpBasic27
{
    public class StackArray
    {
        private int[] items;
        private int top;

        public StackArray(int capacity)
        {
            items = new int[capacity];
            top = -1;
        }

        public void Push(int data)
        {
            if (top == items.Length - 1)
            {
                throw new InvalidOperationException();
            }
            items[++top] = data;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return items[top--];
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return items[top];
        }

        public bool IsEmpty()
        {
            return top < 0;
        }

        public int Size()
        {
            return top + 1;
        }
    }
}
