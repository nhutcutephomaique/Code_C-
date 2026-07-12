using System;
using System.Collections.Generic;

namespace CSharpBasic;

public class ShortestPathDemo
{
    private class Edge
    {
        public int To { get; }
        public int Weight { get; }

        public Edge(int to, int weight)
        {
            To = to;
            Weight = weight;
        }
    }

    public void Run()
    {
        var graph = new Dictionary<int, List<Edge>>
        {
            [1] = new List<Edge> { new(2, 4), new(3, 2) },
            [2] = new List<Edge> { new(4, 5), new(5, 1) },
            [3] = new List<Edge> { new(2, 1), new(5, 8) },
            [4] = new List<Edge> { new(6, 3) },
            [5] = new List<Edge> { new(4, 2), new(6, 6) },
            [6] = new List<Edge>()
        };

        var distances = Dijkstra(graph, 1);

        foreach (var item in distances)
        {
            Console.WriteLine($"Node {item.Key}: {item.Value}");
        }
    }

    private Dictionary<int, int> Dijkstra(Dictionary<int, List<Edge>> graph, int start)
    {
        var distances = new Dictionary<int, int>();
        var priorityQueue = new PriorityQueue<int, int>();

        foreach (var node in graph.Keys)
        {
            distances[node] = int.MaxValue;
        }

        distances[start] = 0;
        priorityQueue.Enqueue(start, 0);

        while (priorityQueue.Count > 0)
        {
            var current = priorityQueue.Dequeue();

            if (distances[current] == int.MaxValue)
            {
                continue;
            }

            foreach (var edge in graph[current])
            {
                var newDistance = distances[current] + edge.Weight;

                if (newDistance < distances[edge.To])
                {
                    distances[edge.To] = newDistance;
                    priorityQueue.Enqueue(edge.To, newDistance);
                }
            }
        }

        return distances;
    }
}
