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
            Console.WriteLine("1. Реализовать функцию перевода чисел из десятичной системы в двоичную, используя рекурсию.");
            Console.WriteLine("Выводим двоичное представление нескольких чисел в диапазоне от -512 до 511:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Число {array[i]}:");
                Console.WriteLine(ConvertToBinaryRecursion(array[i]));
                Console.WriteLine($"Число {-array[i]}:");
                Console.WriteLine(ConvertToBinaryRecursion(-array[i]));
                Console.WriteLine();
            }

            //2.	Реализовать функцию возведения числа a в степень b:
            //a.Без рекурсии.
            Console.WriteLine("\n\n2. Реализовать функцию возведения числа a в степень b:");
            int a = 2, b = 8;
            Console.WriteLine($"a = {a}, b = {b}");
            Console.WriteLine("a.Без рекурсии.");
            Console.WriteLine(Power(a, b));

            //b.Рекурсивно.
            Console.WriteLine("\nb.Рекурсивно.");
            Console.WriteLine(PowerRecursion(a, b));

            //c.  * Рекурсивно, используя свойство чётности степени.
            Console.WriteLine("\nc. * Рекурсивно, используя свойство чётности степени.");
            Console.WriteLine(PowerRecursionEven(a, b));
            Console.WriteLine($"a = {a}, b = {b + 1}");
            Console.WriteLine(PowerRecursionEven(a, b + 1));

            Console.ReadKey();
        }
        
        public static int ConvertToBinaryRecursion(int number)
        {
            if (number >= 0 && (double)number / 2 < 1) { return number % 2; }
            else if (number >= 0) { return number % 2 + 10 * ConvertToBinaryRecursion(number / 2); }
            else { return ConvertToBinaryRecursion(1024 + number); }
        }

        public static int Power(int number, int power)
        {
            for (int i = 2; i <= power; i++) { number += number; }
            return number;
        }

        public static int PowerRecursion(int number, int power)
        {
            if (power < 2) { return number; }
            return number * PowerRecursion(number, power - 1);
        }

        public static int PowerRecursionEven(int number, int power)
        {
            if (power < 2) { return number; }
            return PowerRecursion(number, (power - power % 2) / 2) * PowerRecursion(number, (power - power % 2) / 2) * number / (power % 2 == 0 ? number : 1);
        }
    }
}
