using System.Collections.Generic;

namespace DFS
{
    internal class Node
    {
        public int index;
        public List<Node> children;
        public List<Node> visitedChildren; // Use this to remember which children you already explored
        public Node parent;

        public Node(int index, Node parent)
        {
            this.index = index;
            children = new List<Node>();
            visitedChildren = new List<Node>();
            this.parent = parent;
        }
    }
}
