using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Program
    {
        static int countOp;

        static void Main(string[] args)
        {
            //Андрей Котельников
            //1.	Реализовать функцию перевода чисел из десятичной системы в двоичную, используя рекурсию.
            int[] array = { 1, 10, 127, 256, 511, 512 };
            Console.WriteLine("1. Реализовать функцию перевода чисел из десятичной системы в двоичную, используя рекурсию.");
            Console.WriteLine("Выводим двоичное представление нескольких чисел в диапазоне от -512 до 511:");
            for (int i = 0; i < array.Length; i++)
            {
                countOp = 0;
                Console.WriteLine($"Число {array[i]}:");
                Console.WriteLine($"{ConvertToBinaryRecursion(array[i])} (кол-во операций = {countOp})");
                countOp = 0;
                Console.WriteLine($"Число {-array[i]}:");
                Console.WriteLine($"{ConvertToBinaryRecursion(-array[i])} (кол-во операций = {countOp})");
                Console.WriteLine();
            }

            //2.	Реализовать функцию возведения числа a в степень b:
            //a.Без рекурсии.
            Console.WriteLine("\n\n2. Реализовать функцию возведения числа a в степень b:");
            int a = 2, b = 8;
            countOp = 0;
            Console.WriteLine($"a = {a}, b = {b}");
            Console.WriteLine("a.Без рекурсии.");
            Console.WriteLine($"{Power(a, b)} (кол-во операций = {countOp})");

            //b.Рекурсивно.
            countOp = 0;
            Console.WriteLine("\nb.Рекурсивно.");
            Console.WriteLine($"{PowerRecursion(a, b)} (кол-во операций = {countOp})");

            //c.  * Рекурсивно, используя свойство чётности степени.
            countOp = 0;
            Console.WriteLine("\nc. * Рекурсивно, используя свойство чётности степени.");
            Console.WriteLine($"{PowerRecursionEven(a, b)} (кол-во операций = {countOp})");
            countOp = 0;
            Console.WriteLine($"a = {a}, b = {b + 1}");
            Console.WriteLine($"{PowerRecursionEven(a, b + 1)} (кол-во операций = {countOp})");

            //3.  * *Исполнитель «Калькулятор» преобразует целое число, записанное на экране.У исполнителя две команды, 
            //каждой присвоен номер: 
            //1.Прибавь 1.
            //2.Умножь на 2.
            //Первая команда увеличивает число на экране на 1, вторая увеличивает его в 2 раза.Определить, 
            //сколько существует программ, которые преобразуют число 3 в число 20:
            Console.WriteLine("\n\nПервая команда увеличивает число на экране на 1, вторая увеличивает его в 2 раза." +
                "\nОпределить, сколько существует программ, которые преобразуют число 3 в число 20:");
            //а.С использованием массива.
            List<int> list = new List<int>();
            countOp = 0;
            int startNumber = 3;
            int endNumber = 20;
            int increment = 1;
            int multiple = 2;
            int count = 0;
            list.Add(startNumber);
            while (count == 0)
            {
                count = list.Count;
                for (int i = 0; i < count; i++)
                {
                    countOp++;
                    if (list[i] < endNumber) { list.Add(list[i] * multiple); count = 0; }
                    if (list[i] < endNumber) { list[i] += increment; count = 0; } 
                    if (list[i] > endNumber) { list.RemoveAt(i); }
                    if (list[list.Count - 1] > endNumber) { list.RemoveAt(list.Count - 1); }
                }
            }
            count = 0;
            foreach (var item in list)
            {
                countOp++;
                if (item == endNumber) { count++;   }
            }
            Console.WriteLine("\nа.С использованием массива:");
            Console.WriteLine($"{count} (кол-во операций = {countOp})");

            //b. * С использованием рекурсии.
            countOp = 0;
            Console.WriteLine("\nb. *С использованием рекурсии:");
            Console.WriteLine($"{CulcRecursion(3, 20, 1, 2)} (кол-во операций = {countOp})");


            Console.ReadKey();
        }
        
        public static int ConvertToBinaryRecursion(int number)
        {
            countOp++;
            if (number >= 0 && (double)number / 2 < 1) { return number % 2; }
            else if (number >= 0) { return number % 2 + 10 * ConvertToBinaryRecursion(number / 2); }
            else { return ConvertToBinaryRecursion(1024 + number); }
        }

        public static int Power(int number, int power)
        {
            for (int i = 2; i <= power; i++) { number += number; countOp++; }
            return number;
        }

        public static int PowerRecursion(int number, int power)
        {
            countOp++;
            if (power < 2) { return number; }
            return number * PowerRecursion(number, power - 1);
        }

        public static int PowerRecursionEven(int number, int power)
        {
            countOp++;
            if (power < 2) { return number; }
            return PowerRecursion(number, (power - power % 2) / 2) * PowerRecursion(number, (power - power % 2) / 2) 
                * number / (power % 2 == 0 ? number : 1);
        }

        public static int CulcRecursion(int startNumber, int endNumber, int increment, int multipler)
        {
            countOp++;
            if (startNumber == endNumber) { return 1; }
            if (startNumber > endNumber) { return 0; }
            return CulcRecursion(startNumber + increment, endNumber, increment, multipler) +
                CulcRecursion(startNumber * multipler, endNumber, increment, multipler);
        }
    }
}
