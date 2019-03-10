using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    class Program
    {
        static decimal countOp = 0;
               
        static void Main(string[] args)
        {
            //3. ***Требуется обойти конём шахматную доску размером N × M, пройдя через все поля доски по одному разу. 
            //Здесь алгоритм решения такой же, как и в задаче о 8 ферзях.Разница только в проверке положения коня.

            //При размере доски 70 x 69 время работы алгоритма составит 6,5 секунд. Использован жадный алгоритм.
            int N = 70;
            int M = 69;
            int startN = 7;
            int startM = 7;
            int[,] bourd = new int[N + 1, M + 1];
            int[,] moves = {
            {  2,  1} , {  2, -1},
            {  1,  2} , { -1,  2},
            { -2, -1} , { -2,  1},
            { -1, -2} , {  1, -2} };
            DateTime start = DateTime.Now;
            if (SolutionToMoveHorse(startN, startM, N, M, ref bourd, ref moves)) //Проверяем, есть ли решение
            {
                //Ищем по очереди номера ходов в массиве board и выводим их на экран
                for (int i = 1; i <= N * M; i++)
                {
                    for (int j = 1; j < bourd.GetLength(0); j++)
                    {
                        for (int k = 1; k < bourd.GetLength(1); k++)
                        {
                            if (bourd[j, k] == i)
                            { Console.WriteLine($"Ход {i, 2}: {j} {k}"); j = bourd.GetLength(0); break; }
                        }
                    }
                }
            }
            else { Console.WriteLine($"Решение для доски размером {N} x {M} не существует."); }

            Console.WriteLine($"\nРазмер доски {N} x {M}.");
            Console.WriteLine($"Начальное положение коня {startN} {startM}.");
            Console.WriteLine($"\nКоличество операций = {countOp}");
            DateTime finish = DateTime.Now;
            Console.WriteLine($"Время работы алгоритма в секундах {(finish - start).TotalSeconds}");
            Console.WriteLine($"Время работы алгоритма в миллиxсекундах {(finish - start).TotalMilliseconds}");

            //2. Решить задачу о нахождении длины максимальной подпоследовательности с помощью матрицы.
            countOp = 0;
            int[] arr1 = { 5, 0, 0, 3, 0, 0, 5 };
            int[] arr2 = { 5, 6, 3, 8, 7, 3, 9, 2, 5 };
            int[,] matrix = new int[arr1.Length, arr2.Length];
            int max = MaxSequenceRecursion(ref arr1, ref arr2);
            Console.WriteLine($"\n2. Решить задачу о нахождении длины максимальной подпоследовательности с помощью матрицы.");
            Print(arr1); Console.WriteLine();
            Print(arr2); Console.WriteLine();
            Console.WriteLine($"Через рекурсию: Максимальная длина последовательности = {max}");
            Console.WriteLine($"Через рекурсию: Количество операций = {countOp}");

            Console.WriteLine($"\n\nТеперь решаем через матрицу");
            countOp = 0;
            int i1 = 0;
            int i2 = 0;
            int iCheck1 = -1;
            int iCheck2 = -1;
            int flag = 0;

            while (i1 < matrix.GetLength(0) && i2 < matrix.GetLength(1))
            {
                countOp++;
                for (int i = i1 ; i < matrix.GetLength(0); i++)
                {
                    countOp++;
                    matrix[i, i2] = matrix[i - 1 >= 0 ? i - 1 : 0, i2] > matrix[i, i2 - 1 >= 0 ? i2 - 1 : 0] ? 
                        matrix[i - 1 >= 0 ? i - 1 : 0, i2] : matrix[i, i2 - 1 >= 0 ? i2 - 1 : 0];
                    if (flag == 0 && iCheck2 != i2 && arr1[i] == arr2[i2]) {
                        matrix[i, i2]++; flag = 1; iCheck1 = i; iCheck2 = i2; }
                }
                for (int j = i2 + 1; j < matrix.GetLength(1); j++)
                {
                    countOp++;
                    matrix[i1, j] = matrix[i1, j - 1 >= 0 ? j - 1 : 0] > matrix[i1 - 1 >= 0 ? i1 - 1 : 0, j ] ? 
                        matrix[i1 , j - 1 >= 0 ? j - 1 : 0] : matrix[i1 - 1 >= 0 ? i1 - 1 : 0, j];
                    if (flag == 0 && iCheck1 != i1 && arr1[i1] == arr2[j]) {
                        matrix[i1, j]++; flag = 1; iCheck1 = i1; iCheck2 = j; }
                }
                i1++;
                i2++;
                flag = 0;
            }

            Console.Write("   ");
            foreach (var item in arr2)
            {
                Console.Write($"{item, 2} ");
            }
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write($"{arr1[i],2} ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],2} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"\nЧерез матрицу: Максимальная длина последовательности = {matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1]}");
            Console.WriteLine($"Через матрицу: Количество операций = {countOp}");

            //1. * Количество маршрутов с препятствиями.Реализовать чтение массива с препятствием и нахождение количество маршрутов.
            //Карта 3x3 для примера:
            //1 1 1
            //0 1 0
            //0 1 0
            int[,] map =
            {
                {1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 0, 1, 1, 1, 1, 1},
                {1, 1, 0, 1, 1, 1, 1, 1},
                {1, 1, 0, 1, 1, 1, 1, 1},
                {1, 1, 0, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1}
            };
            int[,] result = new int[map.GetLength(1), map.GetLength(0)];
            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    if (map[i, j] == 0) { continue; }
                    else
                    {
                        result[i, j] = result[i - 1 >= 0 ? i - 1 : 0, j] + result[i, j - 1 >= 0 ? j - 1 : 0];
                        if (result[i, j] == 0) { result[i, j]++; }
                    }
                    
                }
            }
            Console.WriteLine("\n1. * Количество маршрутов с препятствиями." +
                "\nРеализовать чтение массива с препятствием и нахождение количество маршрутов.");
            Console.WriteLine("Карта:");
            Print(map);
            Console.WriteLine("\nМатрица решений:");
            Print(result);

            Console.ReadKey();
        }

        private static void Print(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    Console.Write($"{arr[i, j], 4} ");
                }
                Console.WriteLine();
            }
        }

        private static void Print(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
        }

        private static int MaxSequenceRecursion(ref int[] arr1, ref int[] arr2, int index1 = 0, int index2 = 0)
        {
            countOp++;
            if (index1 >= arr1.Length || index2 >= arr2.Length) { return 0; }
            else if (arr1[index1] == arr2[index2])
            {
                return 1 + MaxSequenceRecursion(ref arr1, ref arr2, index1 +1, index2 + 1);
            }
            else
            {
                int a = MaxSequenceRecursion(ref arr1, ref arr2, index1 + 1, index2);
                int b = MaxSequenceRecursion(ref arr1, ref arr2, index1, index2 + 1);
                return a > b ? a : b;
            }
        }

        private static bool SolutionToMoveHorse(int startN, int startM, int n, int m, ref int[,] bourd, ref int[,] moves, int number = 1)
        {
            countOp++;
            bourd[startN, startM] = number;
            if (number >= n * m) {  return true; }
            int index;
            int[] moveList = new int[moves.GetLength(0)];
            for (int i = 0; i < moves.GetLength(0); i++)
            {
                index = GreedyAlgorithm(startN, startM, ref moveList, ref moves, ref bourd);
                if (index < 0) { break; }
                moveList[index] = -2;
                if (SolutionToMoveHorse(startN + moves[index, 0], startM + moves[index, 1], n, m, ref bourd, ref moves, number + 1))
                { return true; };
            }
            bourd[startN, startM] = 0;
            return false; 
        }

        private static int GreedyAlgorithm(int startN, int startM, ref int[] moveList, ref int[,] moves, ref int[,] bourd)
        {
            for (int i = 0; i < moveList.Length; i++)
            {
                countOp++;
                if (moveList[i] < 0) { continue; }
                if (!CheckIndexBorders(startN + moves[i, 0], startM + moves[i, 1], ref bourd)) { moveList[i] = -1; continue; }
                if (bourd[startN + moves[i, 0], startM + moves[i, 1]] != 0) { moveList[i] = -2; continue; }
                moveList[i] = CountNextMoves(startN + moves[i, 0], startM + moves[i, 1], ref moves, ref bourd);
            }

            //Ищем индекс следующего хода, из которого минимальное количество следующих ходов
            int min = moveList.Length + 1;
            int index = -1;
            for (int i = 0; i < moveList.Length; i++)
            {
                countOp++;
                if (moveList[i] < 0) { continue; }
                if (min > moveList[i]) { min = moveList[i]; index = i; }
            }
            return index;
        }

        private static int CountNextMoves(int startN, int startM, ref int[,] moves, ref int[,] bourd)
        {
            int countMoves = 0;
            bourd[startN, startM] = 1;
            for (int i = 0; i < moves.GetLength(0); i++)
            {
                countOp++;
                if (!CheckIndexBorders(startN + moves[i, 0], startM + moves[i, 1], ref bourd)) { continue; }
                if (bourd[startN + moves[i, 0], startM + moves[i, 1]] != 0) { continue; }
                countMoves++;
            }
            bourd[startN, startM] = 0;
            return countMoves;
        }

        private static bool CheckIndexBorders(int startN, int startM, ref int[,] bourd)
        {
            return startN >= 1 && startM >= 1 && startN < bourd.GetLength(0) && startM < bourd.GetLength(1);
        }
    }
}
