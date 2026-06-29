using System;
using System.Collections.Generic;

namespace HashSetExample
{
    public class HashSet
    {
        private readonly List<int>[] buckets;

        public HashSet(int size = 10)
        {
            buckets = new List<int>[size];
            for (int i = 0; i < size; i++)
            {
                buckets[i] = new List<int>();
            }
        }

        private int Hash(int value)
        {
            return Math.Abs(value) % buckets.Length;
        }

        public void Add(int value)
        {
            int index = Hash(value);
            if (!Contains(value))
            {
                buckets[index].Add(value);
            }
        }

        public bool Contains(int value)
        {
            int index = Hash(value);
            return buckets[index].Contains(value);
        }

        public bool Remove(int value)
        {
            int index = Hash(value);
            return buckets[index].Remove(value);
        }
    }
}
