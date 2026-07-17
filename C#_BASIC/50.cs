using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpBasic;

public class GreedyDemo
{
    public void Run()
    {
        var activities = new[]
        {
            new Activity(1, 3),
            new Activity(2, 5),
            new Activity(4, 6),
            new Activity(6, 7),
            new Activity(5, 8),
            new Activity(7, 9)
        };

        var selected = GetMaximumActivities(activities);
        Console.WriteLine("Selected activities:");
        foreach (var activity in selected)
        {
            Console.WriteLine($"({activity.Start}, {activity.Finish})");
        }
    }

    private List<Activity> GetMaximumActivities(Activity[] activities)
    {
        var sorted = activities.OrderBy(a => a.Finish).ToList();
        var result = new List<Activity>();
        var lastFinish = -1;

        foreach (var activity in sorted)
        {
            if (activity.Start >= lastFinish)
            {
                result.Add(activity);
                lastFinish = activity.Finish;
            }
        }

        return result;
    }

    private sealed class Activity
    {
        public int Start { get; }
        public int Finish { get; }

        public Activity(int start, int finish)
        {
            Start = start;
            Finish = finish;
        }
    }
}
