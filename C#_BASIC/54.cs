using System;
using System.Collections.Generic;

namespace CSharpBasic;

public class BellmanFordDemo
{
    public void Run()
    {
        var vertices = 5;
        var edges = new List<(int From, int To, int Weight)>
        {
            (0, 1, 4),
            (0, 2, 1),
            (2, 1, 2),
            (1, 3, 2),
            (2, 3, 5),
            (3, 4, 1),
            (2, 4, 10)
        };

        var distances = new int[vertices];
        Array.Fill(distances, int.MaxValue);
        distances[0] = 0;

        for (var i = 0; i < vertices - 1; i++)
        {
            var updated = false;

            foreach (var edge in edges)
            {
                if (distances[edge.From] != int.MaxValue && distances[edge.From] + edge.Weight < distances[edge.To])
                {
                    distances[edge.To] = distances[edge.From] + edge.Weight;
                    updated = true;
                }
            }

            if (!updated)
            {
                break;
            }
        }

        Console.WriteLine("Shortest distances from source 0:");

        foreach (var distance in distances)
        {
            Console.WriteLine(distance == int.MaxValue ? "INF" : distance.ToString());
        }
    }
}
