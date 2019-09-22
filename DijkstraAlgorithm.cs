using System;
using System.Linq;
using System.Collections.Generic;
using GraphAlgorithms;

namespace GraphAlgorithms
{
    public class DijkstraAlgorithm : BaseShortestPathAlgorithm
    {
        private sealed class PriorityQueue<T>
        {
            private SortedDictionary<T, Queue<T>> dictOfQueues = new SortedDictionary<T, Queue<T>>();

            public void Enqueue(T distance, T value)
            {
                Queue<T> q;
                if (!dictOfQueues.TryGetValue(distance, out q))
                {
                    q = new Queue<T>();
                    dictOfQueues.Add(distance, q);
                }
                q.Enqueue(value);
            }

            public T Dequeue()
            {
                // will throw if empty!
                var pair = dictOfQueues.First();
                var queueAsValue = pair.Value.Dequeue();
                if (!pair.Value.Any())
                {
                    dictOfQueues.Remove(pair.Key);
                }
                return queueAsValue;
            }

            public bool Any
            {
                get { return dictOfQueues.Any(); }
            }
        }

        public DijkstraAlgorithm(BaseGraph graph) : base(graph){}

        protected override Dictionary<int,DistanceTableEntry> BuildDistanceTable(int sourceVertex)
        {
            var q = new Queue<int>();
            var distanceTable = GetInitialDistanceTable(sourceVertex);

            var priorityQueue = new PriorityQueue<int>();
            priorityQueue.Enqueue(0, sourceVertex);

            while (priorityQueue.Any)
            {
                var currentVertex = priorityQueue.Dequeue();
                var distance = distanceTable[currentVertex].Distance;
                foreach(var adjacentVertex in Graph.AdjacentVertices(currentVertex))
                {
                    var newDistanceFromOrigin = distance + Graph.EdgeWeight(currentVertex, adjacentVertex);
                    var currentDistanceFromOrigin = distanceTable[adjacentVertex].Distance;

                    if (currentDistanceFromOrigin == null || newDistanceFromOrigin < currentDistanceFromOrigin)
                    {
                        distanceTable[adjacentVertex].Distance = newDistanceFromOrigin;
                        distanceTable[adjacentVertex].PreviousVertex = currentVertex;
                        priorityQueue.Enqueue(newDistanceFromOrigin.Value, adjacentVertex);
                    }
                }
            }

            return distanceTable;
        }
    }
}
