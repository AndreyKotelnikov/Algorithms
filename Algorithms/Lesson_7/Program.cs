using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            graf.PrintMatrix();

            //Проверяем граф на связанность
            //Вычисляем минимальный путь между двумя вершинами по алгоритму Дейкстры
            Console.ReadKey();
        }
    }
}
