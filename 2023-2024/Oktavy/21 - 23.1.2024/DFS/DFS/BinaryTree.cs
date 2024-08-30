using System;

namespace DFS
{
    internal class BinaryTree
    {
        public Node root;

        public BinaryTree(int depth)
        {
            if (depth < 0)
            {
                throw new ArgumentException("Depth must be a positive integer.");
            }

            root = GenerateBinaryTree(depth, 1, null);
        }

        // Recursive function for creating a binary tree
        private Node GenerateBinaryTree(int depth, int currentIndex, Node parent)
        {
            if (depth == 0)
            {
                return null;
            }

            Node currentNode = new Node(currentIndex, parent);

            int leftChildIndex = 2 * currentIndex;
            int rightChildIndex = 2 * currentIndex + 1;

            currentNode.children.Add(GenerateBinaryTree(depth - 1, leftChildIndex, currentNode));
            currentNode.children.Add(GenerateBinaryTree(depth - 1, rightChildIndex, currentNode));

            return currentNode;
        }

        // Calling the print on the root
        public void PrintTree()
        {
            PrintTree(root, 0);
        }

        // Recursive calling to the rest of the tree. Notice the root of the tree is on the left and the tree is "deepening" to the right
        private void PrintTree(Node node, int level)
        {
            if (node != null)
            {
                PrintTree(node.children[1], level + 1); // Print right subtree

                for (int i = 0; i < level; i++)
                {
                    Console.Write("    "); // Spacing based on the depth of the node
                }

                if (node.parent != null)
                {
                    int indexInParentChildren = node.parent.children.IndexOf(node);
                    if (indexInParentChildren == 0)
                    {
                        Console.Write("\\ ");
                    }
                    else if (indexInParentChildren == 1)
                    {
                        Console.Write("/ ");
                    }
                }

                Console.WriteLine(node.index);

                PrintTree(node.children[0], level + 1); // Print left subtree
            }
        }
    }
}
