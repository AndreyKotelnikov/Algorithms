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

            Console.SetBufferSize(300, 200); //Расширяем буфер вывода в консоль, чтобы поместилось отображение дерева с большой высотой. 

            //Теперь создаём узлы для дерева
            Random rand = new Random(30);
            Node[] nodeList = new Node[7];
            for (int i = 0; i < nodeList.Length; i++)
            {
                nodeList[i] = new Node(rand.Next(100));
            }

            //Создаём новое дерево и включаем в него все узлы
            BinaryTree tree = new BinaryTree(nodeList[0]);
            for (int i = 1; i < nodeList.Length; i++)
            {
                tree.AddNode(nodeList[i]);
            }

            //Выводим основные характеристики дерева и его структуру на экран
            Console.WriteLine($"Кол-во узлов = {tree.CountNodes}, высота = {tree.Height}, корень = {tree.Root.Data}\n");
            tree.Print();

            //Теперь балансируем дерево и выводим его основные характеристики и структуру на экран
            Console.WriteLine("\n\nТеперь балансируем дерево:");
            tree.BalanceTree();
            Console.WriteLine($"Кол-во узлов = {tree.CountNodes}, высота = {tree.Height}, корень = {tree.Root.Data}\n");
            tree.Print();

            //Теперь предлагаем пользователю указать значение, которое нужно найти в дереве
            Console.WriteLine("\n\n");
            tree.SearchInterface();
            

            Console.ReadKey();
        }
    }
}
