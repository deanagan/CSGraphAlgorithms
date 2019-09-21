using System;
using System.Linq;
using System.Collections.Generic;

namespace GraphAlgorithms
{
    public class AdjacencySetGraph : BaseGraph
    {
        private sealed class Node
        {
            private int vertex;
            private HashSet<int> adjacencySet = new HashSet<int>();
            public Node(int vertex) => this.vertex = vertex;

            public void AddEdge(int v)
            {
                if (vertex == v)
                {
                    throw new ArgumentException("Self assigned vertex");
                }

                adjacencySet.Add(v);
            }

            public HashSet<int> AdjacentVertices()
            {
                return adjacencySet;
            }
        }
        private List<Node> nodeList = new List<Node>();
        public AdjacencySetGraph(int numVertices, bool isDirected = false) : base(numVertices, isDirected)
        {
            foreach(var vertex in Enumerable.Range(0, numVertices))
            {
                nodeList.Add(new Node(vertex));
            }
        }

        public override void AddEdge(int v1, int v2, int weight = 1)
        {
            if (v1 < 0 || v2 < 0 || v1 >= NumVertices || v2 >= NumVertices)
            {
                throw new ArgumentOutOfRangeException("Invalid Vertices");
            }

            if (weight != 1)
            {
                throw new ArgumentOutOfRangeException("Invalid Weight");
            }

            nodeList[v1].AddEdge(v2);

            if (!IsDirected)
            {
                nodeList[v2].AddEdge(v1);
            }
        }

        public override IEnumerable<int> AdjacentVertices(int v)
        {
            if (v >= NumVertices)
            {
                throw new ArgumentOutOfRangeException("Cannot access vertex");
            }

            return nodeList[v].AdjacentVertices();
        }

        public override int EdgeWeight(int v1, int v2)
        {
            return 1;
        }

        public override int InDegree(int v)
        {
            if (v < 0 || v >= NumVertices)
            {
                throw new ArgumentOutOfRangeException("Cannot access vertex");
            }

            return nodeList.Where(node => node.AdjacentVertices().Contains(v)).Count();
        }
    }
}