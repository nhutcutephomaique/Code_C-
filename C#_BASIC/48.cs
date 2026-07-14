using System;

class Program
{
    static void Main()
    {
        string a = Console.ReadLine() ?? "";
        string b = Console.ReadLine() ?? "";
        int m = a.Length, n = b.Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (a[i - 1] == b[j - 1]) dp[i, j] = dp[i - 1, j - 1] + 1;
                else dp[i, j] = dp[i - 1, j] > dp[i, j - 1] ? dp[i - 1, j] : dp[i, j - 1];
            }
        }
        Console.WriteLine(dp[m, n]);
    }
}
