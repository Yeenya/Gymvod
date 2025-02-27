using System;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace GraphPlayground
{
    internal class Program
    {
        public static void DFS(Graph graph, Node startNode, Node targetNode = null)
        {
            /*
             * Zde naprogramuj prohledavani do hloubky.
             */
        }

        public static void BFS(Graph graph, Node startNode, Node targetNode = null)
        {
            /*
             * Zde naprogramuj prohledavani do sirky.
             */
        }

        static void Main(string[] args)
        {
            //Create and print the graph
            Graph graph = new Graph();
            graph.PrintGraph();
            graph.PrintGraphForVisualization();

            //Call both algorithms with a random starting node
            Random rng = new Random();
            DFS(graph, graph.nodes[rng.Next(0, graph.nodes.Count)]);
            BFS(graph, graph.nodes[rng.Next(0, graph.nodes.Count)]);

            Console.ReadKey();
        }
    }
}
