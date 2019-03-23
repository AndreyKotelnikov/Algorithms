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
            int[] numberItemsInArrays = new int[] { 10000, 100000};
            MySorts.SortDelegate[] sortMethods = new MySorts.SortDelegate[] 
            {
                MySorts.Quick,
                MySorts.QuickPlus,
                MySorts.Buble,
                MySorts.BublePlus,
                MySorts.Shaker
            };
            MySorts sorts = new MySorts(numberItemsInArrays, sortMethods);
            //sorts.Print();
            //Console.WriteLine();
            sorts.TestSortes();

            Console.ReadKey();
        }
    }
}
