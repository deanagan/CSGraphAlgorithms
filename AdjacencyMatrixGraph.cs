using System;
using System.Linq;
using System.Collections.Generic;

namespace GraphAlgorithms
{
    public class AdjacencyMatrixGraph : BaseGraph
    {
        private int[,] matrix;
        public AdjacencyMatrixGraph(int numVertices, bool isDirected = false)
            : base(numVertices, isDirected)
        {
            matrix = new int[numVertices, numVertices];
        }

        public override void AddEdge(int v1, int v2, int weight = 1)
        {
            if (v1 < 0 || v2 < 0 || v1 >= NumVertices || v2 >= NumVertices)
            {
                throw new ArgumentOutOfRangeException("Invalid Vertices");
            }

            matrix[v1,v2] = weight;

            if (!IsDirected)
            {
                matrix[v2,v1] = weight;
            }
        }

        public override IEnumerable<int> AdjacentVertices(int v)
        {
            if (v >= NumVertices)
            {
                throw new ArgumentOutOfRangeException("Cannot access vertex");
            }
            var adjacentVertices = Enumerable.Range(0,Convert.ToInt32(NumVertices))
                                    .Where(i => matrix[v,i] > 0);

            foreach(var adjacentVertex in adjacentVertices)
            {
                yield return adjacentVertex;
            }
        }

        public override int EdgeWeight(int v1, int v2)
        {
            return matrix[v1,v2];
        }

        public override int InDegree(int v)
        {
            if (v < 0 || v >= NumVertices)
            {
                throw new ArgumentOutOfRangeException("Cannot access vertex");
            }
            return Enumerable.Range(0, NumVertices)
                                    .Select(i=> matrix[i,v])
                                    .Where(res => res > 0)
                                    .Count();
        }

    }
}