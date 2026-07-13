using System;
using System.Collections.Generic;

namespace CSharpBasic;

public class MaximumFlowDemo
{
    private class Edge
    {
        public int To { get; }
        public int Capacity { get; set; }
        public int ReverseIndex { get; }

        public Edge(int to, int capacity, int reverseIndex)
        {
            To = to;
            Capacity = capacity;
            ReverseIndex = reverseIndex;
        }
    }

    private readonly List<Edge>[] _graph;
    private int[] _level;
    private int[] _next;

    public MaximumFlowDemo()
    {
        _graph = new List<Edge>[7];
        for (var i = 0; i < _graph.Length; i++)
        {
            _graph[i] = new List<Edge>();
        }
    }

    public void Run()
    {
        AddEdge(1, 2, 10);
        AddEdge(1, 3, 10);
        AddEdge(2, 4, 25);
        AddEdge(3, 5, 15);
        AddEdge(4, 3, 4);
        AddEdge(4, 6, 10);
        AddEdge(5, 6, 10);

        var source = 1;
        var sink = 6;
        var maxFlow = GetMaxFlow(source, sink);

        Console.WriteLine($"Maximum flow from {source} to {sink}: {maxFlow}");
    }

    private void AddEdge(int from, int to, int capacity)
    {
        _graph[from].Add(new Edge(to, capacity, _graph[to].Count));
        _graph[to].Add(new Edge(from, 0, _graph[from].Count - 1));
    }

    private bool BuildLevelGraph(int source, int sink)
    {
        _level = new int[_graph.Length];
        Array.Fill(_level, -1);
        var queue = new Queue<int>();
        queue.Enqueue(source);
        _level[source] = 0;

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            foreach (var edge in _graph[node])
            {
                if (edge.Capacity > 0 && _level[edge.To] < 0)
                {
                    _level[edge.To] = _level[node] + 1;
                    queue.Enqueue(edge.To);
                }
            }
        }

        return _level[sink] >= 0;
    }

    private int SendFlow(int node, int sink, int flow)
    {
        if (node == sink)
        {
            return flow;
        }

        for (; _next[node] < _graph[node].Count; _next[node]++)
        {
            var edge = _graph[node][_next[node]];

            if (edge.Capacity > 0 && _level[edge.To] == _level[node] + 1)
            {
                var currentFlow = Math.Min(flow, edge.Capacity);
                var tempFlow = SendFlow(edge.To, sink, currentFlow);

                if (tempFlow > 0)
                {
                    edge.Capacity -= tempFlow;
                    _graph[edge.To][edge.ReverseIndex].Capacity += tempFlow;
                    return tempFlow;
                }
            }
        }

        return 0;
    }

    private int GetMaxFlow(int source, int sink)
    {
        if (source == sink)
        {
            return 0;
        }

        var maxFlow = 0;

        while (BuildLevelGraph(source, sink))
        {
            _next = new int[_graph.Length];
            var flow = SendFlow(source, sink, int.MaxValue);
            while (flow > 0)
            {
                maxFlow += flow;
                flow = SendFlow(source, sink, int.MaxValue);
            }
        }

        return maxFlow;
    }
}
