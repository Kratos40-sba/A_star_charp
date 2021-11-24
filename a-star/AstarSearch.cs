using System;
using System.Collections.Generic;

namespace a_star
{
    public class AstarSearch
    { 
        public Dictionary<Location, Location> From = new Dictionary<Location, Location>();
        public Dictionary<Location, double> To = new Dictionary<Location, double>();

        public static double H(Location a, Location b)
        {
            return Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
        }

        public AstarSearch(Graph<Location> graph, Location start, Location goal)
        {
            var fq = new PriorityQueue<Location>();
            fq.Enqueue(start,0);
            From[start] = start;
            To[start] = 0;
            while (fq.Count > 0)
            {
                var current = fq.Dequeue();
                if (current.Equals(goal))
                {
                    break;
                }

                foreach (var next in graph.Neighbors(current))
                {
                    var newCost = To[current] + graph.Cost(current, next);
                    if (!To.ContainsKey(next) || newCost < To[next])
                    {
                        To[next] = newCost;
                        var priority = newCost + H(next, goal);
                        fq.Enqueue(next,priority);
                        From[next] = current;
                    }

                }

            }
        }
    }
}