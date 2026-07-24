using System;
using System.Collections.Generic;

namespace CSharpBasic;

public class PrimDemo
{
    public void Run()
    {
        var graph = new[,]
        {
            { 0, 2, 0, 6, 0 },
            { 2, 0, 3, 8, 5 },
            { 0, 3, 0, 0, 7 },
            { 6, 8, 0, 0, 9 },
            { 0, 5, 7, 9, 0 }
        };

        var mst = Prim(graph);
        Console.WriteLine("Prim's MST edges:");
        foreach (var edge in mst)
        {
            Console.WriteLine($"{edge.From} - {edge.To} : {edge.Weight}");
        }
    }

    private List<Edge> Prim(int[,] graph)
    {
        var n = graph.GetLength(0);
        var inMst = new bool[n];
        var minWeight = new int[n];
        var parent = new int[n];
        var result = new List<Edge>();

        Array.Fill(minWeight, int.MaxValue);
        Array.Fill(parent, -1);
        minWeight[0] = 0;

        for (int i = 0; i < n; i++)
        {
            var u = -1;

            for (int j = 0; j < n; j++)
            {
                if (!inMst[j] && (u == -1 || minWeight[j] < minWeight[u]))
                {
                    u = j;
                }
            }

            inMst[u] = true;

            if (parent[u] != -1)
            {
                result.Add(new Edge(parent[u], u, graph[parent[u], u]));
            }

            for (int v = 0; v < n; v++)
            {
                if (!inMst[v] && graph[u, v] != 0 && graph[u, v] < minWeight[v])
                {
                    minWeight[v] = graph[u, v];
                    parent[v] = u;
                }
            }
        }

        return result;
    }

    private sealed class Edge
    {
        public int From { get; }
        public int To { get; }
        public int Weight { get; }

        public Edge(int from, int to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }
    }
}
