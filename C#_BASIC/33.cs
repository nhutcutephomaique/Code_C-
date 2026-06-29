using System;
using System.Collections.Generic;

namespace HashMapExample
{
    public class HashMapEntry<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
        public HashMapEntry<TKey, TValue>? Next;

        public HashMapEntry(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
    }

    public class HashMap<TKey, TValue>
    {
        private readonly List<HashMapEntry<TKey, TValue>>[] buckets;

        public HashMap(int size = 10)
        {
            buckets = new List<HashMapEntry<TKey, TValue>>[size];
            for (int i = 0; i < size; i++)
            {
                buckets[i] = new List<HashMapEntry<TKey, TValue>>();
            }
        }

        private int Hash(TKey key)
        {
            int hash = key == null ? 0 : key.GetHashCode();
            int index = hash % buckets.Length;
            return index < 0 ? index + buckets.Length : index;
        }

        public void Put(TKey key, TValue value)
        {
            int index = Hash(key);
            foreach (HashMapEntry<TKey, TValue> item in buckets[index])
            {
                if (EqualityComparer<TKey>.Default.Equals(item.Key, key))
                {
                    item.Value = value;
                    return;
                }
            }

            buckets[index].Add(new HashMapEntry<TKey, TValue>(key, value));
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int index = Hash(key);
            foreach (HashMapEntry<TKey, TValue> item in buckets[index])
            {
                if (EqualityComparer<TKey>.Default.Equals(item.Key, key))
                {
                    value = item.Value;
                    return true;
                }
            }

            value = default!;
            return false;
        }

        public bool Remove(TKey key)
        {
            int index = Hash(key);
            for (int i = 0; i < buckets[index].Count; i++)
            {
                if (EqualityComparer<TKey>.Default.Equals(buckets[index][i].Key, key))
                {
                    buckets[index].RemoveAt(i);
                    return true;
                }
            }

            return false;
        }
    }
}
