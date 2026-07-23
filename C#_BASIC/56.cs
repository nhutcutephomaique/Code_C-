using System;

namespace CSharpBasic;

public class ZeroOneKnapsackDemo
{
    public void Run()
    {
        var values = new[] { 60, 100, 120 };
        var weights = new[] { 10, 20, 30 };
        var capacity = 50;
        var n = values.Length;
        var dp = new int[n + 1, capacity + 1];

        for (var i = 1; i <= n; i++)
        {
            for (var w = 0; w <= capacity; w++)
            {
                dp[i, w] = dp[i - 1, w];

                if (weights[i - 1] <= w)
                {
                    var candidate = dp[i - 1, w - weights[i - 1]] + values[i - 1];

                    if (candidate > dp[i, w])
                    {
                        dp[i, w] = candidate;
                    }
                }
            }
        }

        Console.WriteLine($"Maximum value: {dp[n, capacity]}");
    }
}
