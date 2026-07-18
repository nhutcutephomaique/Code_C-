using System;

namespace CSharpBasic;

public class TabulationDemo
{
    public void Run()
    {
        Console.WriteLine("Fibonacci (tabulation):");
        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine($"{i}: {Fibonacci(i)}");
        }

        Console.WriteLine();
        Console.WriteLine("Climbing stairs:");
        Console.WriteLine(ClimbingStairs(5));
    }

    private int Fibonacci(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        var dp = new int[n + 1];
        dp[0] = 0;
        dp[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[n];
    }

    private int ClimbingStairs(int n)
    {
        if (n <= 2)
        {
            return n;
        }

        var dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[n];
    }
}
