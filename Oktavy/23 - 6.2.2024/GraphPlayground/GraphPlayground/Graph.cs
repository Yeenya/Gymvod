using System;
using System.Collections.Generic;

namespace GraphPlayground
{
    internal class Graph
    {
        public List<Node> nodes;

        public Graph()
        {
            Random rng = new Random();

            nodes = new List<Node>();
            for (int i = 0; i < rng.Next(5, 10); i++)
            {
                nodes.Add(new Node(i));
            }

            //Randomly add neighbors to nodes with some limitations of the amount of neighbors for each node
            foreach (Node node in nodes)
            {
                if (node.neighbors.Count >= 3) continue;
                for (int i = 0; i < rng.Next(1, 3); i++)
                {
                    int newNeighborIndex = rng.Next(nodes.Count - 1);
                    while (newNeighborIndex == node.index || node.neighbors.Contains(nodes[newNeighborIndex]))
                    {
                        newNeighborIndex = rng.Next(nodes.Count - 1);
                    }
                    if (nodes[newNeighborIndex].neighbors.Count >= 3) continue;
                    node.neighbors.Add(nodes[newNeighborIndex]);
                    if (!nodes[newNeighborIndex].neighbors.Contains(node))
                    {
                        nodes[newNeighborIndex].neighbors.Add(node);
                    }
                }
            }
        }

        //Print the graph into console node by node
        public void PrintGraph()
        {
            foreach (Node node in nodes)
            {
                Console.Write("Node " + node.index + " has neighbors: ");
                foreach (Node neighbor in node.neighbors)
                {
                    Console.Write(neighbor.index + " ");
                }
                Console.Write("\n");
            }
        }

        //Print edges to visualize the graph here: https://csacademy.com/app/graph_editor/
        public void PrintGraphForVisualization()
        {
            foreach (Node node in nodes)
            {
                foreach (Node neighbor in node.neighbors)
                {
                    Console.WriteLine(node.index + " " + neighbor.index);
                }
            }
        }
    }
}
