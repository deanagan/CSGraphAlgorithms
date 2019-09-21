using System;
using System.Linq;
using System.Collections.Generic;

namespace GraphAlgorithms
{
    public abstract class BaseGraph
    {
        public BaseGraph(int numVertices, bool isDirected = false)
        {
            NumVertices = numVertices;
            IsDirected = isDirected;
        }

        public int NumVertices { get; }
        public bool IsDirected { get; }

        public abstract void AddEdge(int v1, int v2, int weight = 1);
        public abstract IEnumerable<int> AdjacentVertices(int v);
        public abstract int EdgeWeight(int v1, int v2);
        public abstract int InDegree(int v);
        public void Display()
        {
            foreach(var i in Enumerable.Range(0, NumVertices))
            {
                foreach(var v in AdjacentVertices(i))
                {
                    Console.WriteLine("{0} --> {1}", i, v);
                }
            }
        }
    }
}