using System;

namespace CSharpBasic28
{
    public class StackNode
    {
        public int Data;
        public StackNode Next;

        public StackNode(int data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedListStack
    {
        private StackNode top;

        public void Push(int data)
        {
            StackNode newNode = new StackNode(data);
            newNode.Next = top;
            top = newNode;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            int value = top.Data;
            top = top.Next;
            return value;
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return top.Data;
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        public int Size()
        {
            int count = 0;
            StackNode current = top;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}
