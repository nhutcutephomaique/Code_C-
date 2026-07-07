using System;
using System.Collections.Generic;

namespace CSharpBasic;

public class BigOExample
{
    public void Run()
    {
        var values = GenerateNumbers(10);
        Console.WriteLine($"Constant time result: {GetFirst(values)}");
        Console.WriteLine($"Linear time sum: {Sum(values)}");
        Console.WriteLine($"Quadratic time pair count: {CountPairs(values)}");
        Console.WriteLine($"Logarithmic time search result: {BinarySearch(values, 7)}");
    }

    public int GetFirst(List<int> items)
    {
        return items.Count > 0 ? items[0] : -1;
    }

    public int Sum(List<int> items)
    {
        var total = 0;
        for (var i = 0; i < items.Count; i++)
        {
            total += items[i];
        }
        return total;
    }

    public int CountPairs(List<int> items)
    {
        var count = 0;
        for (var i = 0; i < items.Count; i++)
        {
            for (var j = 0; j < items.Count; j++)
            {
                if (items[i] == items[j])
                {
                    count++;
                }
            }
        }
        return count;
    }

    public int BinarySearch(List<int> items, int target)
    {
        var left = 0;
        var right = items.Count - 1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (items[mid] == target)
            {
                return mid;
            }

            if (items[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }

    public List<int> GenerateNumbers(int count)
    {
        var result = new List<int>();
        for (var i = 1; i <= count; i++)
        {
            result.Add(i);
        }
        return result;
    }
}
