using System;
using System.Linq;
using System.Collections.Generic;
using GraphAlgorithms;

namespace GraphAlgorithms
{
    public class UnweightedShortestPathAlgorithm : BaseShortestPathAlgorithm
    {
        public UnweightedShortestPathAlgorithm(BaseGraph graph) : base(graph){}

        protected override Dictionary<int,DistanceTableEntry> BuildDistanceTable(int sourceVertex)
        {
            var queue = new Queue<int>();
            var distanceTable = GetInitialDistanceTable(sourceVertex);

            queue.Enqueue(sourceVertex);

            while (queue.Any())
            {
                var vertex = queue.Dequeue();
                var distance = distanceTable[vertex].Distance;

                foreach(var adjacentVertex in Graph.AdjacentVertices(vertex))
                {
                    if (distanceTable[adjacentVertex].Distance == null)
                    {
                        distanceTable[adjacentVertex].Distance = distance + 1;
                        distanceTable[adjacentVertex].PreviousVertex = vertex;

                        if (Graph.AdjacentVertices(adjacentVertex).Any())
                        {
                            queue.Enqueue(adjacentVertex);
                        }
                    }
                }
            }

            return distanceTable;
        }
    }
}