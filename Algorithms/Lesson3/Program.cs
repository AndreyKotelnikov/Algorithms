using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    class Program
    {
        static int countOp = 0;
        static int countSwap = 0;

        static void Main(string[] args)
        {
            //Андрей Котельников
            //1. Попробовать оптимизировать пузырьковую сортировку. 
            //Сравнить количество операций сравнения оптимизированной и неоптимизированной программы. 
            //Написать функции сортировки, которые возвращают количество операций.

            //Создаём массив и заполняем его случайными числами
            const int N = 10000;
            const bool print = false;
            int[] arr = new int[N];
            Random rand = new Random(N);
            DateTime start, finish;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(N * 10 + 1);
            }
            int[] etalon = arr.Clone() as int[];
            Console.WriteLine($"\nВывод первоначального массива (кол-во элементов {N}):");
            if (print) { Print(arr); }
            Console.WriteLine($"\nВывод эталонного массива (кол-во элементов {N}):");
            if (print) { Print(arr); }

            start = DateTime.Now;
            SortBubleSimple(ref arr);
            finish = DateTime.Now;
            Console.WriteLine("\n\n1. Попробовать оптимизировать пузырьковую сортировку" +
                "\nСравнить количество операций сравнения оптимизированной и неоптимизированной программы." +
                "\nНаписать функции сортировки, которые возвращают количество операций.");
            Console.WriteLine($"\nВыводим отсортированный массив(кол-во перемещений указателя = {countOp}, кол-во свопов = {countSwap}, " +
                $" время миллисекунд = {(finish - start).TotalMilliseconds}):");
            if (print) { Print(arr); }

            //Оптимизируем алгоритм
            Console.WriteLine("\n\nЗапускаем оптимизированный алгоритм пузырьков...");
            arr = etalon.Clone() as int[];
            if (print) { Print(arr); }
            start = DateTime.Now;
            SortBubleOptimal(ref arr);
            finish = DateTime.Now;
            Console.WriteLine($"\nВыводим отсортированный массив(кол-во перемещений указателя = {countOp}, кол-во свопов = {countSwap}, " +
                $"время миллисекунд = {(finish - start).TotalMilliseconds}):");
            if (print) { Print(arr); }

            //2. *Реализовать шейкерную сортировку
            Console.WriteLine("\n\n2. *Делаем шейкерную сортировку:");
            arr = etalon.Clone() as int[];
            start = DateTime.Now;
            SortShaker(ref arr);
            finish = DateTime.Now;
            Console.WriteLine($"Выводим отсортированный массив(кол-во перемещений указателя = {countOp}, кол-во свопов = {countSwap}, " +
                $"время миллисекунд = {(finish - start).TotalMilliseconds}):");
            if (print) { Print(arr); }

            //3. Реализовать бинарный алгоритм поиска в виде функции, которой передаётся отсортированный массив. 
            //Функция возвращает индекс найденного элемента или –1, если элемент не найден.
            Console.WriteLine("\n\n3. Реализовать бинарный алгоритм поиска в виде функции, которой передаётся отсортированный массив. " +
                "\nФункция возвращает индекс найденного элемента или –1, если элемент не найден.");
            Console.WriteLine("Передаём массив, отсортированный на предыдущем этапе" +
                $"\nИщем первое включение элемента {arr[N - 2]}");
            int index = -2;
            start = DateTime.Now;
            index = BinarySearch(arr[N - 2], ref arr);
            finish = DateTime.Now;
            Console.WriteLine($"Выводим найденный индекс(кол-во перемещений указателя = {countOp}, " +
                $"время миллисекунд = {(finish - start).TotalMilliseconds}):");
            Console.WriteLine(index);

            Console.WriteLine("\nТеперь ищем элемент, которого нет в массиве: -10");
            start = DateTime.Now;
            index = BinarySearch(-10, ref arr);
            finish = DateTime.Now;
            Console.WriteLine($"Выводим найденный индекс(кол-во перемещений указателя = {countOp}, " +
                $"время миллисекунд = {(finish - start).TotalMilliseconds}):");
            Console.WriteLine(index);

            Console.ReadKey();
        }

        public static int BinarySearch(int item, ref int[] arr)
        {
            countOp = 0;
            int L = 0;
            int R = arr.Length - 1;
            int index;
            while (L != R)
            {
                countOp++;
                index = L + (R - L) / 2;
                if (arr[index] == item) { return index; }
                if (arr[index] > item) { R = index - 1; }
                else { L = index + 1; }
            }
            return -1;
        }

        public static void SortShaker(ref int[] arr)
        {
            countOp = 0;
            countSwap = 0;
            int flagSwap = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                countOp++;
                for (int j = i + 1; j < arr.Length - i; j++)
                {
                    countOp++;
                    if (arr[j - 1] > arr[j])
                    {
                        countSwap++; arr[j - 1] ^= arr[j]; arr[j] ^= arr[j - 1]; arr[j - 1] ^= arr[j];
                        flagSwap = 1;
                    }
                }
                if (flagSwap == 0) { break; } else { flagSwap = 0; }
                for (int j = arr.Length - 2 - i; j > i; j--)
                {
                    countOp++;
                    if (arr[j - 1] > arr[j])
                    {
                        countSwap++; arr[j - 1] ^= arr[j]; arr[j] ^= arr[j - 1]; arr[j - 1] ^= arr[j];
                        flagSwap = 1;
                    }
                }
                if (flagSwap == 0) { break; } else { flagSwap = 0; }
            }
        }

        public static void SortBubleSimple(ref int[] arr)
        {
            countOp = 0;
            countSwap = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                countOp++;
                for (int j = 1; j < arr.Length; j++)
                {
                    countOp++;
                    if (arr[j - 1] > arr[j]) { countSwap++; arr[j - 1] ^= arr[j]; arr[j] ^= arr[j - 1]; arr[j - 1] ^= arr[j]; }
                }
            }
        }

        public static void SortBubleOptimal(ref int[] arr)
        {
            countOp = 0;
            countSwap = 0;
            int flagSwap = 0;
            int indexJamp = 0;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                countOp++;
                for (int j = 1; j < arr.Length - count; j++)
                {
                    countOp++;
                    if (arr[j - 1] > arr[j])
                    {
                        countSwap++;
                        arr[j - 1] ^= arr[j]; arr[j] ^= arr[j - 1]; arr[j - 1] ^= arr[j];
                        if (flagSwap == 0) { indexJamp = j + 1; }
                        flagSwap = 1;
                    }

                }
                count++;
                i = indexJamp - 1;
                if (flagSwap == 0) { break; }
                else flagSwap = 0;
            }
        }

        public static void Print(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
