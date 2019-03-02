using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Андрей Котельников
            //1.	Реализовать функцию перевода чисел из десятичной системы в двоичную, используя рекурсию.
            int[] array = { 1, 10, 127, 256, 511, 512 };
            Console.WriteLine("Выводим двоичное представление нескольких чисел в диапазоне от -512 до 511:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Число {array[i]}:");
                Console.WriteLine(ConvertToBinaryRecursion(array[i]));
                Console.WriteLine($"Число {-array[i]}:");
                Console.WriteLine(ConvertToBinaryRecursion(-array[i]));
                Console.WriteLine();
            }
            

            Console.ReadKey();
        }

        public static int ConvertToBinaryRecursion(int number)
        {
            if (number >= 0 && (double)number / 2 < 1) { return number % 2; }
            else if (number >= 0) { return number % 2 + 10 * ConvertToBinaryRecursion(number / 2); }
            else { return ConvertToBinaryRecursion(1024 + number); }
        }
    }
}
