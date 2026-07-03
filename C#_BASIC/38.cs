using System;
using System.Collections.Generic;

namespace CSharpBasic;

public class Graph
{
    private readonly Dictionary<int, List<int>> adjacency = new();

    public void AddVertex(int value)
    {
        if (!adjacency.ContainsKey(value))
        {
            adjacency[value] = new List<int>();
        }
    }

    public void AddEdge(int from, int to)
    {
        AddVertex(from);
        AddVertex(to);
        adjacency[from].Add(to);
    }

    public List<int> DFS(int start)
    {
        var result = new List<int>();
        var visited = new HashSet<int>();
        DFS(start, visited, result);
        return result;
    }

    private void DFS(int node, HashSet<int> visited, List<int> result)
    {
        if (visited.Contains(node))
        {
            return;
        }

        visited.Add(node);
        result.Add(node);

        foreach (var neighbor in adjacency[node])
        {
            DFS(neighbor, visited, result);
        }
    }

    public List<int> BFS(int start)
    {
        var result = new List<int>();
        var visited = new HashSet<int>();
        var queue = new Queue<int>();

        visited.Add(start);
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            result.Add(node);

            foreach (var neighbor in adjacency[node])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        return result;
    }

    public bool HasPath(int start, int target)
    {
        var visited = new HashSet<int>();
        var stack = new Stack<int>();

        stack.Push(start);

        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (node == target)
            {
                return true;
            }

            if (visited.Contains(node))
            {
                continue;
            }

            visited.Add(node);

            foreach (var neighbor in adjacency[node])
            {
                if (!visited.Contains(neighbor))
                {
                    stack.Push(neighbor);
                }
            }
        }

        return false;
    }
}
