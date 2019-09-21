using System;
using System.Linq;
using GraphAlgorithms;

namespace CSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var g1 = new AdjacencyMatrixGraph(4, true);

            g1.AddEdge(0, 1, 12);
            g1.AddEdge(0, 2, 17);
            g1.AddEdge(2, 3, 26);

            foreach(var vertex in Enumerable.Range(0, 4))
            {
                Console.WriteLine("Adjacent to: {0}: [{1}]", vertex, string.Join(", ", g1.AdjacentVertices(vertex)));
            }

            foreach(var vertex in Enumerable.Range(0, 4))
            {
                Console.WriteLine("In-degree: {0}: {1}", vertex, g1.InDegree(vertex));
            }

            foreach(var vertex in Enumerable.Range(0, 4))
            {
                foreach(var adjv in g1.AdjacentVertices(vertex))
                {
                    Console.WriteLine("Edge Weight: {0} -> {1} = {2}", vertex, adjv, g1.EdgeWeight(vertex, adjv));
                }
            }

            g1.Display();


            var g2 = new AdjacencySetGraph(4, true);

            g2.AddEdge(0, 1);
            g2.AddEdge(0, 2);
            g2.AddEdge(2, 3);

            foreach(var vertex in Enumerable.Range(0, 4))
            {
                Console.WriteLine("Adjacent to: {0}: [{1}]", vertex, string.Join(", ", g2.AdjacentVertices(vertex)));
            }

            foreach(var vertex in Enumerable.Range(0, 4))
            {
                Console.WriteLine("In-degree: {0}: {1}", vertex, g2.InDegree(vertex));
            }

            foreach(var vertex in Enumerable.Range(0, 4))
            {
                foreach(var adjv in g2.AdjacentVertices(vertex))
                {
                    Console.WriteLine("Edge Weight: {0} -> {1} = {2}", vertex, adjv, g2.EdgeWeight(vertex, adjv));
                }
            }

            g2.Display();



            var g3 = new AdjacencyMatrixGraph(9, true);
            g3.AddEdge(0,1);
            g3.AddEdge(1,2);
            g3.AddEdge(2,7);
            g3.AddEdge(2,4);
            g3.AddEdge(2,3);
            g3.AddEdge(1,5);
            g3.AddEdge(5,6);
            g3.AddEdge(3,6);
            g3.AddEdge(3,4);
            g3.AddEdge(6,8);

            TopologicalSort.Sort(g3);

            var g4 = new AdjacencyMatrixGraph(8);
            g4.AddEdge(0,1);
            g4.AddEdge(1,2);
            g4.AddEdge(1,3);
            g4.AddEdge(2,3);
            g4.AddEdge(1,4);
            g4.AddEdge(3,5);
            g4.AddEdge(5,4);
            g4.AddEdge(3,6);
            g4.AddEdge(6,7);
            g4.AddEdge(0,7);

            var usp = new UnweightedShortestPathAlgorithm(g4);
            usp.Path(0, 5);
            usp.Path(0, 6);
            usp.Path(7, 4);

            var g5 = new AdjacencyMatrixGraph(8);
            g5.AddEdge(0,1);
            g5.AddEdge(1,2);
            g5.AddEdge(1,3);
            g5.AddEdge(2,3);
            g5.AddEdge(1,4);
            g5.AddEdge(3,5);
            g5.AddEdge(5,4);
            g5.AddEdge(3,6);
            g5.AddEdge(6,7);
            g5.AddEdge(0,7);

            var da = new DijkstraAlgorithm(g5);
            da.Path(0, 5);
            da.Path(0, 6);
            da.Path(7, 4);

            var g6 = new AdjacencyMatrixGraph(6, true);
            g6.AddEdge(0,1,1);
            g6.AddEdge(0,5,7);
            g6.AddEdge(1,2,1);
            g6.AddEdge(1,3,3);
            g6.AddEdge(1,4,1);
            g6.AddEdge(2,3,1);
            g6.AddEdge(3,5,2);
            g6.AddEdge(5,4,1);

            var best_path_to_5_is_01235 = new DijkstraAlgorithm(g6);
            best_path_to_5_is_01235.Path(0,5);
        }
    }
}
