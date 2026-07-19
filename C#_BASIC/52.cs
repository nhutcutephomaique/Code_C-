using System;
using System.Collections.Generic;

namespace CSharpBasic;

public class GraphTraversalDemo
{
    private readonly Dictionary<int, List<int>> _graph = new()
    {
        [0] = new List<int> { 1, 2 },
        [1] = new List<int> { 0, 3, 4 },
        [2] = new List<int> { 0, 5 },
        [3] = new List<int> { 1 },
        [4] = new List<int> { 1, 5 },
        [5] = new List<int> { 2, 4 }
    };

    public void Run()
    {
        Console.WriteLine("Graph traversal demo\n");
        PrintGraph();

        Console.WriteLine();
        Console.WriteLine("Breadth-first search starting from node 0:");
        Console.WriteLine(string.Join(" -> ", BreadthFirstSearch(0)));

        Console.WriteLine();
        Console.WriteLine("Depth-first search starting from node 0:");
        Console.WriteLine(string.Join(" -> ", DepthFirstSearch(0)));
    }

    private void PrintGraph()
    {
        Console.WriteLine("Graph adjacency list:");
        foreach (var kvp in _graph)
        {
            Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
        }
    }

    private IEnumerable<int> BreadthFirstSearch(int start)
    {
        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        var order = new List<int>();

        visited.Add(start);
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            order.Add(node);

            foreach (var neighbor in _graph[node])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        return order;
    }

    private IEnumerable<int> DepthFirstSearch(int start)
    {
        var visited = new HashSet<int>();
        var order = new List<int>();
        DepthFirstSearchRecursive(start, visited, order);
        return order;
    }

    private void DepthFirstSearchRecursive(int node, HashSet<int> visited, List<int> order)
    {
        visited.Add(node);
        order.Add(node);

        foreach (var neighbor in _graph[node])
        {
            if (!visited.Contains(neighbor))
            {
                DepthFirstSearchRecursive(neighbor, visited, order);
            }
        }
    }
}
