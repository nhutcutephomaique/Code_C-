using System;
using System.Collections.Generic;

namespace CSharpBasic;

public class AdvancedGraph
{
    private readonly Dictionary<int, List<(int node, int weight)>> adjacency = new();

    public void AddVertex(int value)
    {
        if (!adjacency.ContainsKey(value))
        {
            adjacency[value] = new List<(int node, int weight)>();
        }
    }

    public void AddEdge(int from, int to, int weight)
    {
        AddVertex(from);
        AddVertex(to);
        adjacency[from].Add((to, weight));
    }

    public Dictionary<int, int> Dijkstra(int start)
    {
        var distance = new Dictionary<int, int>();
        var visited = new HashSet<int>();
        var queue = new PriorityQueue<int, int>();

        foreach (var vertex in adjacency.Keys)
        {
            distance[vertex] = int.MaxValue;
        }

        distance[start] = 0;
        queue.Enqueue(start, 0);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (visited.Contains(node))
            {
                continue;
            }

            visited.Add(node);

            foreach (var (neighbor, weight) in adjacency[node])
            {
                var newDistance = distance[node] + weight;
                if (newDistance < distance[neighbor])
                {
                    distance[neighbor] = newDistance;
                    queue.Enqueue(neighbor, newDistance);
                }
            }
        }

        return distance;
    }

    public Dictionary<int, int> BellmanFord(int start)
    {
        var distance = new Dictionary<int, int>();

        foreach (var vertex in adjacency.Keys)
        {
            distance[vertex] = int.MaxValue;
        }

        distance[start] = 0;

        for (var i = 0; i < adjacency.Count - 1; i++)
        {
            var updated = false;
            foreach (var vertex in adjacency.Keys)
            {
                if (distance[vertex] == int.MaxValue)
                {
                    continue;
                }

                foreach (var (neighbor, weight) in adjacency[vertex])
                {
                    var newDistance = distance[vertex] + weight;
                    if (newDistance < distance[neighbor])
                    {
                        distance[neighbor] = newDistance;
                        updated = true;
                    }
                }
            }

            if (!updated)
            {
                break;
            }
        }

        return distance;
    }

    public List<int> TopologicalSort()
    {
        var order = new List<int>();
        var inDegree = new Dictionary<int, int>();
        var queue = new Queue<int>();

        foreach (var vertex in adjacency.Keys)
        {
            inDegree[vertex] = 0;
        }

        foreach (var vertex in adjacency.Keys)
        {
            foreach (var (neighbor, _) in adjacency[vertex])
            {
                inDegree[neighbor]++;
            }
        }

        foreach (var vertex in inDegree.Keys)
        {
            if (inDegree[vertex] == 0)
            {
                queue.Enqueue(vertex);
            }
        }

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            order.Add(node);

            foreach (var (neighbor, _) in adjacency[node])
            {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0)
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        return order;
    }

    public List<List<int>> StronglyConnectedComponents()
    {
        var stack = new Stack<int>();
        var visited = new HashSet<int>();
        var components = new List<List<int>>();

        foreach (var vertex in adjacency.Keys)
        {
            if (!visited.Contains(vertex))
            {
                FillOrder(vertex, visited, stack);
            }
        }

        var transpose = GetTranspose();
        visited.Clear();

        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (!visited.Contains(node))
            {
                var component = new List<int>();
                transpose.DFSCollect(node, visited, component);
                components.Add(component);
            }
        }

        return components;
    }

    private void FillOrder(int node, HashSet<int> visited, Stack<int> stack)
    {
        visited.Add(node);

        foreach (var (neighbor, _) in adjacency[node])
        {
            if (!visited.Contains(neighbor))
            {
                FillOrder(neighbor, visited, stack);
            }
        }

        stack.Push(node);
    }

    private AdvancedGraph GetTranspose()
    {
        var transpose = new AdvancedGraph();

        foreach (var vertex in adjacency.Keys)
        {
            transpose.AddVertex(vertex);
        }

        foreach (var vertex in adjacency.Keys)
        {
            foreach (var (neighbor, weight) in adjacency[vertex])
            {
                transpose.AddEdge(neighbor, vertex, weight);
            }
        }

        return transpose;
    }

    private void DFSCollect(int node, HashSet<int> visited, List<int> component)
    {
        visited.Add(node);
        component.Add(node);

        foreach (var (neighbor, _) in adjacency[node])
        {
            if (!visited.Contains(neighbor))
            {
                DFSCollect(neighbor, visited, component);
            }
        }
    }
}
