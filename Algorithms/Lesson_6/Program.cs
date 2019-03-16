using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Андрей Котельников
            //2.Переписать программу, реализующее двоичное дерево поиска:
            //a.Добавить в него обход дерева различными способами.
            //b.Реализовать поиск в нём.
            Node[] nodeList1 = new Node[7];
            nodeList1[0] = new Node(4);
            nodeList1[1] = new Node(2);
            nodeList1[2] = new Node(1);
            nodeList1[3] = new Node(3);
            nodeList1[4] = new Node(6);
            nodeList1[5] = new Node(5);
            nodeList1[6] = new Node(7);

            BinaryTree tree = new BinaryTree(nodeList1[0]);
            for (int i = 1; i < nodeList1.Length; i++)
            {
                tree.AddNode(nodeList1[i]);
            }
            Console.WriteLine($"Кол-во узлов = {tree.CountNodes}, высота = {tree.Height}, корень = {tree.Root.Data}");
            tree.Print();

            Node[] nodeList2 = new Node[16];
            nodeList2[0] = new Node(8);
            nodeList2[1] = new Node(4);
            nodeList2[2] = new Node(12);
            nodeList2[3] = new Node(2);
            nodeList2[4] = new Node(6);
            nodeList2[5] = new Node(10);
            nodeList2[6] = new Node(14);
            nodeList2[7] = new Node(1);
            nodeList2[8] = new Node(3);
            nodeList2[9] = new Node(5);
            nodeList2[10] = new Node(7);
            nodeList2[11] = new Node(9);
            nodeList2[12] = new Node(11);
            nodeList2[13] = new Node(13);
            nodeList2[14] = new Node(15);
            nodeList2[15] = new Node(16);

            BinaryTree tree2 = new BinaryTree(nodeList2[0]);
            for (int i = 1; i < nodeList2.Length; i++)
            {
                tree2.AddNode(nodeList2[i]);
            }
            Console.WriteLine($"\n\nКол-во узлов = {tree2.CountNodes}, высота = {tree2.Height}, корень = {tree2.Root.Data}");
            tree2.Print();

            Console.ReadKey();
        }
    }
}
