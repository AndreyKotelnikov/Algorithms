﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lesson_8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Андрей Котельников
            //5.	Проанализировать время работы каждого из вида сортировок для 100, 10000, 1000000 элементов. 
            //Заполнить таблицу.

            //Заполняем массив с количествами элементов масивов, на которых будем тестировать сортировки
            int[] numberItemsInArrays = new int[] { 5000 };

            //Заполняем массив методами, которые будем тестировать и сравнивать между собой
            MySorts.SortDelegate[] sortMethods = new MySorts.SortDelegate[] 
            {
                MySorts.Quick, //Простой алгоритм быстрой сортировки, реализованный через стену и опорный элемент
                MySorts.Quick2P, //Алгоритм быстрой сортировки, реализованный через 2 указателя, которые двигаются друг к другу
                MySorts.QuickAver, //Алгоритм быстрой сортировки с расчётом среднего значения элементов
                MySorts.Buble, //Простой алгоритм пузырьками
                MySorts.BublePlus, //Оптимизированный алгоритм пузырьками
                MySorts.Shaker, //Простой алгоритм Шейкер
                MySorts.Heap //Пиромидальная сортировка через завершённое бинарное дерево              
            };

            //Создаём класс для тестирования сортировок
            MySorts sorts = new MySorts(numberItemsInArrays, sortMethods);

            //Выводим значения массивов, на которых будем делать тест сортировок
            //sorts.Print();
            //Console.WriteLine();

            //Запускаем тест сортировок
            sorts.TestSortes();

            //Выводим сравнительные таблицы работы сортировок между сосбой по времени работы, количеству сравнений и количеству свопов.
            sorts.TestSortesСompareTable();

            Console.ReadKey();
        }
    }
}
