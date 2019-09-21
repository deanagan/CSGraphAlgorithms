using System;
using System.Linq;
using System.Collections.Generic;
using GraphAlgorithms;

namespace GraphAlgorithms
{
    public sealed class DistanceTableEntry
    {
        public DistanceTableEntry(int? distance = null, int? vertex = null)
        {
            Distance = distance;
            PreviousVertex = vertex;
        }
        public int? Distance {get; set; }
        public int? PreviousVertex {get; set; }
    }

    public abstract class BaseShortestPathAlgorithm
    {
        protected BaseGraph Graph { get; }
        public BaseShortestPathAlgorithm(BaseGraph graph) => Graph = graph;
        protected abstract Dictionary<int,DistanceTableEntry> BuildDistanceTable(int sourceVertex);
        protected Dictionary<int,DistanceTableEntry> GetInitialDistanceTable(int sourceVertex)
        {
            var distanceTable = new Dictionary<int, DistanceTableEntry>();

            foreach(var vertex in Enumerable.Range(0, Graph.NumVertices))
            {
                if (vertex == sourceVertex)
                {
                    distanceTable.Add(vertex, new DistanceTableEntry {
                        Distance = 0,
                        PreviousVertex = sourceVertex
                    });
                }
                else
                {
                    distanceTable.Add(vertex, new DistanceTableEntry());
                }
            }

            return distanceTable;
        }

        public void Path(int sourceVertex, int destinationVertex)
        {
            var distanceTable = BuildDistanceTable(sourceVertex);

            var path = new LinkedList<int?>();
            path.AddLast(destinationVertex);
            var preceedingVertex = distanceTable[destinationVertex].PreviousVertex;

            while (preceedingVertex != null && preceedingVertex != sourceVertex)
            {
                path.AddFirst(preceedingVertex);
                preceedingVertex = distanceTable[preceedingVertex.Value].PreviousVertex;
            }

            if (preceedingVertex == null)
            {
                Console.WriteLine("No path to destination!");
            }
            else
            {
                path.AddFirst(preceedingVertex);
            }

            Console.WriteLine(string.Join(", ", path));
        }
    }
}