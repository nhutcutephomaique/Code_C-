using System;
using System.Collections.Generic;

namespace CSharpBasic;

public class MemoizationDemo
{
    private readonly Dictionary<int, long> _memo = new();

    public void Run()
    {
        Console.WriteLine("Memoization demo");
        Console.WriteLine($"Fibonacci(10) = {Fibonacci(10)}");
        Console.WriteLine($"Fibonacci(20) = {Fibonacci(20)}");
        Console.WriteLine($"Fibonacci(30) = {Fibonacci(30)}");
    }

    private long Fibonacci(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        if (_memo.ContainsKey(n))
        {
            return _memo[n];
        }

        var result = Fibonacci(n - 1) + Fibonacci(n - 2);
        _memo[n] = result;
        return result;
    }
}
