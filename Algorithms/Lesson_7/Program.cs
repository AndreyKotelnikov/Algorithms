using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson_5;

namespace Lesson_7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Андрей Котельников
            //Реализовать алгоритм Дейкстры по обходу графа
            //Создаём граф
            Graf graf = new Graf(8);
            
            //Для примера взял граф, который обсуждали на вебинаре по алгоритму Дейкстры
            graf.SetEdge(0, 1, 4);
            graf.SetEdge(0, 2, 8);
            graf.SetEdge(0, 3, 3);
            graf.SetEdge(1, 5, 6);
            graf.SetEdge(1, 4, 8);
            graf.SetEdge(1, 2, 1);
            graf.SetEdge(2, 4, 2);
            graf.SetEdge(2, 3, 8);
            graf.SetEdge(3, 6, 4);
            graf.SetEdge(4, 5, 2);
            graf.SetEdge(4, 7, 5);
            graf.SetEdge(5, 7, 3);
            graf.SetEdge(6, 7, 2);

            //Выводим матрицу смежности в консоль
            graf.PrintMatrix();
            
            //Проверяем вершины графа на связанность
            int startVertice = 6;
            int endVertice = 1;
            Console.WriteLine($"\nПроверка связанности {startVertice} и {endVertice} = {graf.CheckConnection(startVertice, endVertice)}");
            
            //Вычисляем минимальный путь между двумя вершинами по алгоритму Дейкстры
            Console.WriteLine($"\nВычисляем кротчайший путь из вершины {startVertice} в вершину {endVertice}");
            int[] minWeightRoute = graf.MinWeightRoute(startVertice, endVertice);

            //Выводим получившийся порядок вершин маршрута в консоль
            if (minWeightRoute.Length == 0) { Console.WriteLine("Вершины не связаны между собой."); }
            foreach (var item in minWeightRoute)
            {
                Console.Write($"{item} ");
            }

            Console.ReadKey();
        }
    }
}
