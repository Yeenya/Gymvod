using System.Collections.Generic;

namespace GraphPlayground
{
    //Simple node class, no comments needed
    internal class Node
    {
        public int index;

        public List<Node> neighbors;

        public bool visited;

        public Node(int index)
        {
            this.index = index;
            neighbors = new List<Node>();
            visited = false;
        }
    }
}
