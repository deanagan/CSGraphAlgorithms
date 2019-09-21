using System;
using System.Linq;
using System.Collections.Generic;

namespace GraphAlgorithms
{
    public class TopologicalSort
    {
        public static void Sort(BaseGraph graph)
        {
            var queue = new Queue<int>();
            var indegree = new Dictionary<int, int>();

            for(var index = 0; index < graph.NumVertices; index++)
            {
                indegree[index] = graph.InDegree(index);
                if (indegree[index] == 0)
                {
                    queue.Enqueue(index);
                }
            }

            var result = new List<int>();

            while (queue.Any())
            {
                var vertex = queue.Dequeue();

                result.Add(vertex);

                foreach(var nextVertex in graph.AdjacentVertices(vertex))
                {
                    indegree[nextVertex] -= 1;
                    if (indegree[nextVertex] == 0)
                    {
                        queue.Enqueue(nextVertex);
                    }
                }
            }

            if (result.Count != graph.NumVertices)
            {
                Console.WriteLine("Cycle Detected");
            }
            else
            {
                Console.WriteLine(string.Join(", ", result));
            }

        }
    }
}