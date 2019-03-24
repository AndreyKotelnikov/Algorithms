using System;
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
            int[] numberItemsInArrays = new int[] { 5000 };
            MySorts.SortDelegate[] sortMethods = new MySorts.SortDelegate[] 
            {
                MySorts.Quick,
                MySorts.Quick2P,
                MySorts.QuickAver,
                MySorts.Buble,
                MySorts.BublePlus,
                MySorts.Shaker,
                MySorts.Heap               
            };
            MySorts sorts = new MySorts(numberItemsInArrays, sortMethods);
            //sorts.Print();
            //Console.WriteLine();
            sorts.TestSortes();
            sorts.TestSortesСompareTable();

            Console.ReadKey();
        }
    }
}
