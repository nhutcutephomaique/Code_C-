using System;
using System.Collections.Generic;

namespace CSharpBasic;

public class GraphAdvanced
{
    public void Run()
    {
        var weightedGraph = new Dictionary<string, List<(string node, int weight)>>
        {
            ["A"] = new List<(string, int)> { ("B", 2), ("C", 5) },
            ["B"] = new List<(string, int)> { ("C", 1), ("D", 4) },
            ["C"] = new List<(string, int)> { ("D", 2) },
            ["D"] = new List<(string, int)> { ("E", 1) },
            ["E"] = new List<(string, int)>()
        };

        var directedGraph = new Dictionary<string, List<string>>
        {
            ["A"] = new List<string> { "B", "C" },
            ["B"] = new List<string> { "D" },
            ["C"] = new List<string> { "D" },
            ["D"] = new List<string> { "E" },
            ["E"] = new List<string>()
        };

        var distances = Dijkstra(weightedGraph, "A");
        var topoOrder = TopologicalSort(directedGraph);
        Console.WriteLine(string.Join(", ", distances.Select(kvp => $"{kvp.Key}:{kvp.Value}")));
        Console.WriteLine(string.Join(" -> ", topoOrder));
    }

    public Dictionary<string, int> Dijkstra(Dictionary<string, List<(string node, int weight)>> graph, string source)
    {
        var dist = new Dictionary<string, int>();
        var queue = new PriorityQueue<(string node, int cost), int>();

        foreach (var node in graph.Keys)
        {
            dist[node] = int.MaxValue;
        }

        dist[source] = 0;
        queue.Enqueue((source, 0), 0);

        while (queue.Count > 0)
        {
            var (node, cost) = queue.Dequeue();
            if (cost > dist[node])
            {
                continue;
            }

            foreach (var edge in graph[node])
            {
                var nextCost = cost + edge.weight;
                if (nextCost < dist[edge.node])
                {
                    dist[edge.node] = nextCost;
                    queue.Enqueue((edge.node, nextCost), nextCost);
                }
            }
        }

        return dist;
    }

    public List<string> TopologicalSort(Dictionary<string, List<string>> graph)
    {
        var indegree = new Dictionary<string, int>();

        foreach (var node in graph.Keys)
        {
            indegree[node] = 0;
        }

        foreach (var edges in graph.Values)
        {
            foreach (var node in edges)
            {
                if (!indegree.ContainsKey(node))
                {
                    indegree[node] = 0;
                }
                indegree[node]++;
            }
        }

        var queue = new Queue<string>();
        foreach (var kvp in indegree)
        {
            if (kvp.Value == 0)
            {
                queue.Enqueue(kvp.Key);
            }
        }

        var order = new List<string>();
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            order.Add(node);
            if (!graph.ContainsKey(node))
            {
                continue;
            }

            foreach (var next in graph[node])
            {
                indegree[next]--;
                if (indegree[next] == 0)
                {
                    queue.Enqueue(next);
                }
            }
        }

        return order;
    }
}
