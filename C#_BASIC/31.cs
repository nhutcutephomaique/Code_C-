using System;

namespace HashTableExample
{
    public class HashTableNode
    {
        public string Key;
        public int Value;
        public HashTableNode? Next;

        public HashTableNode(string key, int value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
    }

    public class HashTable
    {
        private readonly HashTableNode?[] buckets;

        public HashTable(int size = 10)
        {
            buckets = new HashTableNode?[size];
        }

        private int Hash(string key)
        {
            int hash = 0;
            for (int i = 0; i < key.Length; i++)
            {
                hash = (hash * 31 + key[i]) % buckets.Length;
            }
            return hash;
        }

        public void Put(string key, int value)
        {
            int index = Hash(key);
            HashTableNode? node = buckets[index];
            if (node == null)
            {
                buckets[index] = new HashTableNode(key, value);
                return;
            }

            while (node != null)
            {
                if (node.Key == key)
                {
                    node.Value = value;
                    return;
                }

                if (node.Next == null)
                {
                    node.Next = new HashTableNode(key, value);
                    return;
                }

                node = node.Next;
            }
        }

        public bool TryGetValue(string key, out int value)
        {
            int index = Hash(key);
            HashTableNode? node = buckets[index];
            while (node != null)
            {
                if (node.Key == key)
                {
                    value = node.Value;
                    return true;
                }
                node = node.Next;
            }

            value = 0;
            return false;
        }

        public bool Remove(string key)
        {
            int index = Hash(key);
            HashTableNode? current = buckets[index];
            HashTableNode? previous = null;

            while (current != null)
            {
                if (current.Key == key)
                {
                    if (previous == null)
                    {
                        buckets[index] = current.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }
    }
}
