using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    class BinaryTree
    {
        public Node Root { get; private set; }
        public int CountNodes { get; private set; }
        public int Height { get; private set; } // Считает по максимальному количеству узлов в глубину 

        public BinaryTree(Node root)
        {
            Root = root;
            CountNodes = 1;
            Height = 1;
        }

        public void AddNode(Node newNode, Node nodeInTree = null, int depth = 2)
        {
            if (nodeInTree == null) { nodeInTree = Root; CountNodes++; }
            if (newNode.Data > nodeInTree.Data)
            {
                if (nodeInTree.Right != null) { AddNode(newNode, nodeInTree.Right, depth + 1); }
                else
                {
                    nodeInTree.Right = newNode;
                    newNode.Parent = nodeInTree;
                    if (depth > Height) { Height = depth; }
                }
            }
            if (newNode.Data <= nodeInTree.Data)
            {
                if (nodeInTree.Left != null) { AddNode(newNode, nodeInTree.Left, depth + 1); }
                else
                {
                    nodeInTree.Left = newNode;
                    newNode.Parent = nodeInTree;
                    if (depth > Height) { Height = depth; }
                }
            }
        }

        public void Print(Node node = null, int depth = 1, int count = 1, int xCursor = 0, int yCursor = 0)
        {
            if (node == null)
            {
                node = Root;
                depth = 1;
                count = 1;
                xCursor = Console.CursorLeft;
                yCursor = Console.CursorTop;
            }
            Console.CursorTop = yCursor + depth - 1;
            // Для вывода значения каждого узла выделяем длину в 4 позиций.
            if (Height == depth)
            {
                Console.CursorLeft = (count - (1 << (depth - 1))) * 4;
            }
            else
            {
                Console.CursorLeft = xCursor + (int)(((double)(1<<(Height - depth - 1)) - 0.5) * 4)
                    + (1 << (Height - depth)) * (count - (1 << (depth - 1))) * 4;
            }
            Console.Write($"[{node.Data, 2}]");
            
            if (node.Left != null) { Print(node.Left, depth + 1, count * 2 , xCursor, yCursor); }
            if (node.Right != null) { Print(node.Right, depth + 1, count * 2 + 1, xCursor, yCursor); }
        }
    }
}
